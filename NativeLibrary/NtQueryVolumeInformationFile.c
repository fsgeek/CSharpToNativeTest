
#include "native-internal.h"

typedef NTSTATUS (*NtQueryVolumeInformationFile_t)(
    _In_ HANDLE FileHandle,
    _Out_ PIO_STATUS_BLOCK IoStatusBlock,
    _Out_writes_bytes_(Length) PVOID FsInformation,
    _In_ ULONG Length,
    _In_ FS_INFORMATION_CLASS FsInformationClass
    );


NATIVEAPI
NTSTATUS 
NtQueryVolumeInformationFile(
    _In_ HANDLE FileHandle,
    _Out_ PIO_STATUS_BLOCK IoStatusBlock,
    _Out_writes_bytes_(Length) PVOID FsInformation,
    _In_ ULONG Length,
    _In_ FS_INFORMATION_CLASS FsInformationClass
)
{
    static NtQueryVolumeInformationFile_t native = NULL;

    if (NULL == native) {
        native = (NtQueryVolumeInformationFile_t)GetNativeRoutine("NtQueryVolumeInformationFile");
        // printf("Mapped NtQueryVolumeInformationFile to 0x%p\n", native);
    }
    
    printf("\nFsInformationClass is: %d\n\n", (int)FsInformationClass);
    return native(FileHandle, IoStatusBlock, FsInformation, Length, FsInformationClass);
}

