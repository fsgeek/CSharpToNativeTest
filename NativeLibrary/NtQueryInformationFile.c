#include "native-internal.h"

typedef NTSTATUS(*NtQueryInformationFile_t)(
    _In_ HANDLE FileHandle,
    _Out_ PIO_STATUS_BLOCK IoStatusBlock,
    _Out_writes_bytes_(Length) PVOID FileInformation,
    _In_ ULONG Length,
    _In_ FILE_INFORMATION_CLASS FileInformationClass
    );


NATIVEAPI
NTSTATUS
NtQueryInformationFile(
    _In_ HANDLE FileHandle,
    _Out_ PIO_STATUS_BLOCK IoStatusBlock,
    _Out_writes_bytes_(Length) PVOID FileInformation,
    _In_ ULONG Length,
    _In_ FILE_INFORMATION_CLASS FileInformationClass
)
{
    static NtQueryInformationFile_t native = NULL;

    if (NULL == native)
    {
        native = (NtQueryInformationFile_t)GetNativeRoutine("NtQueryInformationFile");
        printf("Mapped NtQueryInformationFile to 0x%p\n", native);
    }

    return native(FileHandle, IoStatusBlock, FileInformation, Length, FileInformationClass);
}

