#include <stdio.h>
#include <Windows.h>
#include <libloaderapi.h>
#include <assert.h>


typedef struct _UNICODE_STRING {
    USHORT Length;
    USHORT MaximumLength;
    PWSTR  Buffer;
} UNICODE_STRING;
typedef UNICODE_STRING* PUNICODE_STRING;
typedef const UNICODE_STRING* PCUNICODE_STRING;

typedef struct _OBJECT_ATTRIBUTES {
    ULONG Length;
    HANDLE RootDirectory;
    PUNICODE_STRING ObjectName;
    ULONG Attributes;
    PVOID SecurityDescriptor;        // Points to type SECURITY_DESCRIPTOR
    PVOID SecurityQualityOfService;  // Points to type SECURITY_QUALITY_OF_SERVICE
} OBJECT_ATTRIBUTES, *POBJECT_ATTRIBUTES;

typedef struct _IO_STATUS_BLOCK {
    union {
        NTSTATUS Status;
        PVOID Pointer;
    };

    ULONG_PTR Information;
} IO_STATUS_BLOCK, * PIO_STATUS_BLOCK;


typedef
NTSTATUS
(*NtCreateFile_t)(
    _Out_ PHANDLE FileHandle,
    _In_ ACCESS_MASK DesiredAccess,
    _In_ POBJECT_ATTRIBUTES ObjectAttributes,
    _Out_ PIO_STATUS_BLOCK IoStatusBlock,
    _In_opt_ PLARGE_INTEGER AllocationSize,
    _In_ ULONG FileAttributes,
    _In_ ULONG ShareAccess,
    _In_ ULONG CreateDisposition,
    _In_ ULONG CreateOptions,
    _In_reads_bytes_opt_(EaLength) PVOID EaBuffer,
    _In_ ULONG EaLength
    );

typedef
NTSTATUS
(*NtCreateFile_t)(
    _Out_ PHANDLE FileHandle,
    _In_ ACCESS_MASK DesiredAccess,
    _In_ POBJECT_ATTRIBUTES ObjectAttributes,
    _Out_ PIO_STATUS_BLOCK IoStatusBlock,
    _In_opt_ PLARGE_INTEGER AllocationSize,
    _In_ ULONG FileAttributes,
    _In_ ULONG ShareAccess,
    _In_ ULONG CreateDisposition,
    _In_ ULONG CreateOptions,
    _In_reads_bytes_opt_(EaLength) PVOID EaBuffer,
    _In_ ULONG EaLength
    );

static void* GetNativeRoutine(_In_ PCSTR RoutineName)
{
    static HMODULE ntdll = NULL;

    if (NULL == ntdll) {
        ntdll = LoadLibraryW(L"ntdll.dll");
        assert(NULL != ntdll);
    }

    return (void*)GetProcAddress(ntdll, RoutineName);

}

MYAPI
NTSTATUS
NtCreateFile(
    _Out_ PHANDLE FileHandle,
    _In_ ACCESS_MASK DesiredAccess,
    _In_ POBJECT_ATTRIBUTES ObjectAttributes,
    _Out_ PIO_STATUS_BLOCK IoStatusBlock,
    _In_opt_ PLARGE_INTEGER AllocationSize,
    _In_ ULONG FileAttributes,
    _In_ ULONG ShareAccess,
    _In_ ULONG CreateDisposition,
    _In_ ULONG CreateOptions,
    _In_reads_bytes_opt_(EaLength) PVOID EaBuffer,
    _In_ ULONG EaLength
)
{
    static NtCreateFile_t native = NULL;

    if (NULL == native) {
        native = (NtCreateFile_t)GetNativeRoutine("NtCreateFile");
        printf("Mapped NtCreateFile to 0x%p\n", native);
    }
    assert(NULL != native);

    *FileHandle = INVALID_HANDLE_VALUE;


    // Debug for now
    // return native(FileHandle, DesiredAccess, ObjectAttributes, IoStatusBlock, AllocationSize, FileAttributes, ShareAccess, CreateDisposition, CreateOptions, EaBuffer, EaLength);
    return (NTSTATUS) 0xC0000001;
}

MYAPI void print_line(const char* str)
{
    printf("%s\n", str);
    
    NtCreateFile_t native = (NtCreateFile_t)GetNativeRoutine("NtCreateFile");
    printf("Mapped NtCreateFile to 0x%p\n", native);
}

MYAPI int NativeTestUnicodeString(UNICODE_STRING *str)
{
    //WCHAR buffer[512];
    printf("String @ %p\n", str);
    printf("Length = %d\n", str->Length);
    printf("MaximumLength = %d\n", str->MaximumLength);
    printf("Buffer @ %p\n", str->Buffer);
    //memcpy(buffer, str->Buffer, str->Length);
    //printf("String is %wZ\n", &str);

}

