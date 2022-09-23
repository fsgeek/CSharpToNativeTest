#include <ntifs.h>
#include <stdio.h>

int main(int argc, char** argv, char** envp)
{
	if ((argc < 1) || (NULL == argv) || (NULL == envp)) {
		printf("Strange parameters passed (argc, argv, envp) = %d, 0x%p, 0x%p\n", argc, argv, envp);

	}
	printf("FILE_DIRECTORY_INFORMATION Offset:\n");
	printf("\t FileName: %d\n", FIELD_OFFSET(FILE_DIRECTORY_INFORMATION, FileName));

	printf("FILE_FULL_DIR_INFORMATION Offset:\n");
	printf("\t FileName: %d\n", FIELD_OFFSET(FILE_FULL_DIR_INFORMATION, FileName));

	printf("FILE_ID_FULL_DIR_INFORMATION Offset:\n");
	printf("\t FileName: %d\n", FIELD_OFFSET(FILE_ID_FULL_DIR_INFORMATION, FileName));

	printf("FILE_BOTH_DIR_INFORMATION Offset:\n");
	printf("\tShortName: %d\n", FIELD_OFFSET(FILE_BOTH_DIR_INFORMATION, ShortName));
	printf("\t FileName: %d\n", FIELD_OFFSET(FILE_BOTH_DIR_INFORMATION, FileName));

	printf("FILE_ID_BOTH_DIR_INFORMATION Offset:\n");
	printf("\tShortName: %d\n", FIELD_OFFSET(FILE_ID_BOTH_DIR_INFORMATION, ShortName));
	printf("\t FileName: %d\n", FIELD_OFFSET(FILE_ID_BOTH_DIR_INFORMATION, FileName));

	printf("FILE_ID_GLOBAL_TX_DIR_INFORMATION Offset:\n");
	printf("\t FileName: %d\n", FIELD_OFFSET(FILE_ID_GLOBAL_TX_DIR_INFORMATION, FileName));

	printf("FILE_ID_EXTD_DIR_INFORMATION Offset:\n");
	printf("\t FileName: %d\n", FIELD_OFFSET(FILE_ID_EXTD_DIR_INFORMATION, FileName));

	printf("FILE_ID_EXTD_BOTH_DIR_INFORMATION Offset:\n");
	printf("\tShortName: %d\n", FIELD_OFFSET(FILE_ID_EXTD_BOTH_DIR_INFORMATION, ShortName));
	printf("\t FileName: %d\n", FIELD_OFFSET(FILE_ID_EXTD_BOTH_DIR_INFORMATION, FileName));

	printf("FILE_OBJECTID_INFORMATION Length: %zu", sizeof(FILE_OBJECTID_INFORMATION));

}
