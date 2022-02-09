#include "native-internal.h"

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

NATIVEAPI
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
	NTSTATUS status = 0;

	if (NULL == native) {
		native = (NtCreateFile_t)GetNativeRoutine("NtCreateFile");
		// printf("Mapped NtCreateFile to 0x%p\n", native);
	}
	assert(NULL != native);

	*FileHandle = INVALID_HANDLE_VALUE;

	status = native(FileHandle, DesiredAccess, ObjectAttributes, IoStatusBlock, AllocationSize, FileAttributes, ShareAccess, CreateDisposition, CreateOptions, EaBuffer, EaLength);

#if 0
	printf("NtCreateFile called:\n");
	printf("\tFileHandle = 0x%p\n", FileHandle);
	printf("\tDesiredAccess = 0x%x\n", DesiredAccess);
	printf("\tObjectAttributes:\n");
	printf("\t\tObjectName = %wZ\n", ObjectAttributes->ObjectName);
	printf("\tAllocationSize (ptr) = 0x%p\n", AllocationSize);
	printf("\tFileAttributes = 0x%x\n", FileAttributes);
	printf("\tShareAccess = %d\n", ShareAccess);
	printf("\tCreateDisposition = %d\n", CreateDisposition);
	printf("\tCreateOptions = 0x%x\n", CreateOptions);

	printf("NtCreateFile returned status = 0x%x (%d), IoStatus: Status = 0x%x (0x%d), Information = %ul:\n", status, status, IoStatusBlock->Status, IoStatusBlock->Status, IoStatusBlock->Information);

	if (STATUS_INVALID_PARAMETER == status) {
		// this is my debug code while I'm trying to debug this issue.

		HANDLE handle = NULL;
		OBJECT_ATTRIBUTES oa;
		UNICODE_STRING fname;
		IO_STATUS_BLOCK iosb;
		NTSTATUS status;
		static const PWSTR mountManagerName = L"\\DosDevices\\D:";
		DWORD mpBufferSize = 1024 * 1024;
		char* mpBuffer = malloc(mpBufferSize);

		assert(NULL != mpBuffer);

		// Set the name
		fname.Length = fname.MaximumLength = (USHORT)(sizeof(WCHAR) * wcslen(mountManagerName));
		fname.Buffer = mountManagerName;

		// Open the volume
		oa.Length = sizeof(OBJECT_ATTRIBUTES);
		oa.RootDirectory = NULL;
		oa.ObjectName = &fname;
		oa.Attributes = 0x00000040L;
		oa.SecurityDescriptor = NULL; // compute and use default
		oa.SecurityQualityOfService = NULL; // default

		memset(&iosb, 0, sizeof(iosb));

		ACCESS_MASK mask = GENERIC_READ;
		ULONG fileAttributes = 0;
		ULONG sharing = FILE_SHARE_READ | FILE_SHARE_WRITE;
		ULONG disposition = 0x00000001; // FILE_OPEN
		ULONG options = 0x20;

		status = native(&handle, mask, &oa, &iosb, NULL, fileAttributes, sharing, disposition, options, NULL, 0);


		printf("Debug testing NtCreateFile: status = 0x%x (%d)\n", status, status);
		printf("\tFileHandle = 0x%p\n", &handle);
		printf("\tDesiredAccess = 0x%x\n", mask);
		printf("\tObjectAttributes:\n");
		printf("\t\tObjectName = %wZ\n", oa.ObjectName);
		printf("\tAllocationSize (ptr) = 0x%p\n", (void*)0);
		printf("\tFileAttributes = 0x%x\n", fileAttributes);
		printf("\tShareAccess = %d\n", sharing);
		printf("\tCreateDisposition = %d\n", disposition);
		printf("\tCreateOptions = 0x%x\n", options);


		if (0 != status) {
			CloseHandle(handle);
		}
	}
#endif // 0

	return status;
	// return (NTSTATUS) 0xC0000001;
}

