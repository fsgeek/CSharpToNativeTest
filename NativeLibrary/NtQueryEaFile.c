#include "native-internal.h"

typedef NTSTATUS(*NtQueryEaFile_t)(
    _In_ HANDLE FileHandle,
    _Out_ PIO_STATUS_BLOCK IoStatusBlock,
    _Out_writes_bytes_(Length) PVOID FileInformation,
    _In_ ULONG Length,
    _In_ BOOLEAN ReturnSingleEntry,
    _In_reads_bytes_opt_(EaListLength) PVOID EaList,
    _In_ ULONG EaListLength,
    _In_opt_ PULONG EaIndex,
    _In_ BOOLEAN RestartScan);


NATIVEAPI
NTSTATUS
NtQueryEaFile(
    _In_ HANDLE FileHandle,
    _Out_ PIO_STATUS_BLOCK IoStatusBlock,
    _Out_writes_bytes_(Length) PVOID Buffer,
    _In_ ULONG Length,
    _In_ BOOLEAN ReturnSingleEntry,
    _In_reads_bytes_opt_(EaListLength) PVOID EaList,
    _In_ ULONG EaListLength,
    _In_opt_ PULONG EaIndex,
    _In_ BOOLEAN RestartScan
)
{
    static NtQueryEaFile_t native = NULL;

    if (NULL == native)
    {
        native = (NtQueryEaFile_t)GetNativeRoutine("NtQueryEaFile");
        printf("Mapped NtQueryEaFile to 0x%p\n", native);
    }

    return native(FileHandle, IoStatusBlock, Buffer, Length, ReturnSingleEntry, EaList, EaListLength, EaIndex, RestartScan);
}

