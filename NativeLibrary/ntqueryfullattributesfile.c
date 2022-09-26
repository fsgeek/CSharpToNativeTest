#include "native-internal.h"

typedef
NTSTATUS
(*NtQueryFullAttributesFile_t)(
	_In_ POBJECT_ATTRIBUTES ObjectAttributes,
	_Out_ PFILE_NETWORK_OPEN_INFORMATION FileInformation
	);

NATIVEAPI
NTSTATUS
NtQueryFullAttributesFile(
	_In_ POBJECT_ATTRIBUTES ObjectAttributes,
	_Out_ PFILE_NETWORK_OPEN_INFORMATION FileInformation
)
{
	static NtQueryFullAttributesFile_t native = NULL;
	NTSTATUS status = 0;

	if (NULL == native) {
		native = (NtQueryFullAttributesFile_t)GetNativeRoutine("NtQueryFullAttributesFile");
		// printf("Mapped NtCreateFile to 0x%p\n", native);
	}
	assert(NULL != native);

	status = native(ObjectAttributes, FileInformation);

	return status;
}

