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

MYAPI void NativeTestUnicodeString(UNICODE_STRING *str)
{
    //WCHAR buffer[512];
    printf("String @ %p\n", str);
    printf("Length = %d\n", str->Length);
    printf("MaximumLength = %d\n", str->MaximumLength);
    printf("Buffer @ %p\n", str->Buffer);
    //memcpy(buffer, str->Buffer, str->Length);
    printf("String is %wZ\n", str);

    return;
}

MYAPI void NativeTestIoStatusBlock(IO_STATUS_BLOCK* iosb)
{
    const int STATUS_BUFFER_OVERFLOW = (int)0x80000005;
    printf("IoStatusBlock at 0x%p\n", iosb);
    printf("\tStatus = %d (0x%x)\n", iosb->Status, iosb->Status);
    printf("\tInformation = %d (0x%x)\n", (int)iosb->Information, (unsigned)iosb->Information);
    iosb->Status = STATUS_BUFFER_OVERFLOW;
    iosb->Information = 0x10000;

    return;
}

MYAPI void NativeTestObjectAttributes(OBJECT_ATTRIBUTES* ObjectAttributes)
{
    printf("Object Attributes @ 0x%p\n", ObjectAttributes);
    printf("\t                  Length: %lu\n", ObjectAttributes->Length);
    printf("\t           RootDirectory: 0x%p\n", ObjectAttributes->RootDirectory);
    printf("\t              ObjectName: %wZ\n", ObjectAttributes->ObjectName);
    printf("\t              Attributes: %lu\n", ObjectAttributes->Attributes);
    printf("\t      SecurityDescriptor: 0x%p\n", ObjectAttributes->SecurityDescriptor);
    printf("\tSecurityQualityOfService: 0x%p\n", ObjectAttributes->SecurityQualityOfService);
}

MYAPI void NativeTestLargeInteger(LARGE_INTEGER* LargeInteger)
{
    printf("Large Integer @ 0x%p\n", LargeInteger);
    printf("\t     QuadPart: %llu\n", LargeInteger->QuadPart);
    printf("\t      LowPart: 0x%x (%u)\n", LargeInteger->LowPart, LargeInteger->LowPart);
    printf("\t     HighPart: 0x%x (%d)\n", LargeInteger->HighPart, LargeInteger->HighPart);

    if (0 == LargeInteger->QuadPart) {
        LargeInteger->LowPart = 1;
        LargeInteger->HighPart = 3;
    }
}

