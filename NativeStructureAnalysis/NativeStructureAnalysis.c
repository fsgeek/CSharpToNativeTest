// NativeStructureAnalysis.c : This file contains the 'main' function. Program execution begins and ends there.
//

#if !defined(_68K_) && !defined(_MPPC_) && !defined(_X86_) && !defined(_IA64_) && !defined(_AMD64_) && !defined(_ARM_) && !defined(_ARM64_) && defined(_M_IX86)
#define _X86_
#if !defined(_CHPE_X86_ARM64_) && defined(_M_HYBRID)
#define _CHPE_X86_ARM64_
#endif
#endif

#if !defined(_68K_) && !defined(_MPPC_) && !defined(_X86_) && !defined(_IA64_) && !defined(_AMD64_) && !defined(_ARM_) && !defined(_ARM64_) && defined(_M_AMD64)
#define _AMD64_
#endif

#if !defined(_68K_) && !defined(_MPPC_) && !defined(_X86_) && !defined(_IA64_) && !defined(_AMD64_) && !defined(_ARM_) && !defined(_ARM64_) && defined(_M_ARM)
#define _ARM_
#endif

#if !defined(_68K_) && !defined(_MPPC_) && !defined(_X86_) && !defined(_IA64_) && !defined(_AMD64_) && !defined(_ARM_) && !defined(_ARM64_) && defined(_M_ARM64)
#define _ARM64_
#endif

#include <stdio.h>
#include <ntifs.h>

int main(int argc, char **argv, char **env)
{
	const char* ulong = "unknown";
	const char* uint = "unknown";
	const char* uchar = "unknown";
	const char* ushort = "unknown";
	const char* boolean = "unknown";

	if (4 == sizeof(ULONG)) {
		ulong = "UInt32";
	}
	if (8 == sizeof(ULONG)) {
		ulong = "UInt64";
	}

	if (4 == sizeof(unsigned)) {
		uint = "UInt32";
	}

	if (1 == sizeof(UCHAR)) {
		uchar = "byte";
	}

	if (2 == sizeof(USHORT)) {
		ushort = "UInt16";
	}

	if (1 == sizeof(BOOLEAN)) {
		boolean = "bool";
	}

	printf("Print structure offsets for OS data structures\n");
	printf("sizeof(void *) = %zu\n", sizeof(void*));
	
	printf("[StructLayout(LayoutKind.Explicit, Pack = 0)]\n");
	printf("private struct _OBJECT_ATTRIBUTES\n{\n");
	printf("\t[FieldOffset(%lu)] public %s Length; // field size is %zu\n", FIELD_OFFSET(OBJECT_ATTRIBUTES, Length), ulong, sizeof(ULONG));
	printf("\t[FieldOffset(%lu)] public SafeFileHandle RootDirectory; // field size is %zu\n", FIELD_OFFSET(OBJECT_ATTRIBUTES, RootDirectory), sizeof(HANDLE));
	printf("\t[FieldOffset(%lu)] public IntPtr ObjectName; // PUNICODE_STRING, field size is %zu\n", FIELD_OFFSET(OBJECT_ATTRIBUTES, ObjectName), sizeof(void*));
	printf("\t[FieldOffset(%lu)] public %s Attributes; // fields size is %zu\n", FIELD_OFFSET(OBJECT_ATTRIBUTES, Attributes), ulong, sizeof(ULONG));
	printf("\t[FieldOffset(%lu)] public IntPtr SecurityDescriptor; // field size is %zu\n", FIELD_OFFSET(OBJECT_ATTRIBUTES, SecurityDescriptor), sizeof(void*));
	printf("\t[FieldOffset(%lu)] public IntPtr SecurityQualityOfService; // field size is %zu\n", FIELD_OFFSET(OBJECT_ATTRIBUTES, SecurityQualityOfService), sizeof(void*));
	printf("}\n\n");

	printf("[StructLayout(LayoutKind.Explicit, Pack = 0)]\n");
	printf("private struct _SECURITY_DESCRIPTOR\n{\n");
	printf("\t[FieldOffset(%lu)] public %s Revision; // field size is %zu\n", FIELD_OFFSET(SECURITY_DESCRIPTOR, Revision), uchar, sizeof(UCHAR));
	printf("\t[FieldOffset(%lu)] public %s Control; // field size is %zu\n", FIELD_OFFSET(SECURITY_DESCRIPTOR, Control), ushort, sizeof(USHORT));
	printf("\t[FieldOffset(%lu)] public IntPtr Owner; // field size is %zu\n", FIELD_OFFSET(SECURITY_DESCRIPTOR, Owner), sizeof(PSID));
	printf("\t[FieldOffset(%lu)] public IntPtr Group; // field size is %zu\n", FIELD_OFFSET(SECURITY_DESCRIPTOR, Group), sizeof(PSID));
	printf("\t[FieldOffset(%lu)] public IntPtr Sacl; // field size is %zu\n", FIELD_OFFSET(SECURITY_DESCRIPTOR, Sacl), sizeof(PACL));
	printf("\t[FieldOffset(%lu)] public IntPtr Dacl; // field size is %zu\n", FIELD_OFFSET(SECURITY_DESCRIPTOR, Dacl), sizeof(PACL));
	printf("}\n\n");

	printf("[StructLayout(LayoutKind.Explicit, Pack = 0)]\n");
	printf("private unsafe struct _SECURITY_DESCRIPTOR_RELATIVE\n{\n");
	printf("\t[FieldOffset(%lu)] public %s Revision; // field size is %zu\n", FIELD_OFFSET(SECURITY_DESCRIPTOR, Revision), uchar, sizeof(UCHAR));
	printf("\t[FieldOffset(%lu)] public %s Control; // field size is %zu\n", FIELD_OFFSET(SECURITY_DESCRIPTOR, Control), ushort, sizeof(USHORT));
	printf("\t[FieldOffset(%lu)] public %s Owner; // field size is %zu\n", FIELD_OFFSET(SECURITY_DESCRIPTOR, Owner), ulong, sizeof(ULONG));
	printf("\t[FieldOffset(%lu)] public %s Group; // field size is %zu\n", FIELD_OFFSET(SECURITY_DESCRIPTOR, Group), ulong, sizeof(ULONG));
	printf("\t[FieldOffset(%lu)] public %s Sacl; // field size is %zu\n", FIELD_OFFSET(SECURITY_DESCRIPTOR, Sacl), ulong, sizeof(ULONG));
	printf("\t[FieldOffset(%lu)] public %s Dacl; // field size is %zu\n", FIELD_OFFSET(SECURITY_DESCRIPTOR, Dacl), ulong, sizeof(ULONG));
	printf("}\n\n");

	printf("[StructLayout(LayoutKind.Explicit, Pack = 0)]\n");
	printf("private unsafe struct _ACL\n{\n");
	printf("\t[FieldOffset(%lu)] public %s AclRevision; // field size is %zu\n", FIELD_OFFSET(ACL, AclRevision), uchar, sizeof(UCHAR));
	printf("\t[FieldOffset(%lu)] public %s AclSize; // field size is %zu\n", FIELD_OFFSET(ACL, AclSize), ushort, sizeof(USHORT));
	printf("\t[FieldOffset(%lu)] public %s AceCount; // field size is %zu\n", FIELD_OFFSET(ACL, AceCount), ushort, sizeof(USHORT));
	printf("}\n\n");

	printf("private const UInt SECURITY_MAX_SID_SIZE = %zu\n", sizeof(ULONG) * SID_MAX_SUB_AUTHORITIES);
	printf("[StructLayout(LayoutKind.Explicit, Pack = 0)]\n");
	printf("private unsafe struct _SID\n{\n");
	printf("\t[FieldOffset(%lu)] public %s Revision; // field size is %zu\n", FIELD_OFFSET(SID, Revision), uchar, sizeof(UCHAR));
	printf("\t[FieldOffset(%lu)] public %s SubAuthorityCount; // field size is %zu\n", FIELD_OFFSET(SID, SubAuthorityCount), uchar, sizeof(UCHAR));
	printf("\t[FieldOffset(%lu)] public fixed %s IdentifierAuthority[6]; // field size is %zu\n", FIELD_OFFSET(SID, IdentifierAuthority), uchar, 6 * sizeof(UCHAR));
	printf("\t[FieldOffset(%lu)] public fixed %s SubAuthority[SECURITY_MAX_SID_SIZE];\n", FIELD_OFFSET(SID, SubAuthority), uchar);
	printf("}\n\n");

	/*
	* 
	typedef enum _SECURITY_IMPERSONATION_LEVEL {
		SecurityAnonymous,
		SecurityIdentification,
		SecurityImpersonation,
		SecurityDelegation
    } SECURITY_IMPERSONATION_LEVEL, * PSECURITY_IMPERSONATION_LEVEL;

	typedef BOOLEAN SECURITY_CONTEXT_TRACKING_MODE,
					* PSECURITY_CONTEXT_TRACKING_MODE;

	typedef struct _SECURITY_QUALITY_OF_SERVICE {
		ULONG Length;
		SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;
		SECURITY_CONTEXT_TRACKING_MODE ContextTrackingMode;
		BOOLEAN EffectiveOnly;
    } SECURITY_QUALITY_OF_SERVICE, * PSECURITY_QUALITY_OF_SERVICE;
	*/

	printf("public enum SECURITY_IMPERSONATION_LEVEL\n{\n");
	printf("\tSecurityAnonymous = %d,\n", (int) SecurityAnonymous);
	printf("\tSecurityIdentification = %d,\n", (int)SecurityIdentification);
	printf("\tSecurityImpersonation = %d,\n", (int)SecurityImpersonation);
	printf("\tSecurityDelegation = %d,\n", (int)SecurityDelegation);
	printf("}\n\n");

	printf("[StructLayout(LayoutKind.Explicit, Pack = 0)]\n");
	printf("private unsafe struct _SECURITY_QUALITY_OF_SERVICE\n{\n");
	printf("\t[FieldOffset(%lu)] public %s Length; // field size is %zu\n", FIELD_OFFSET(SECURITY_QUALITY_OF_SERVICE, Length), ulong, sizeof(ULONG));
	printf("\t[FieldOffset(%lu)] public %s ImpersonationLevel; // field size is %zu\n", FIELD_OFFSET(SECURITY_QUALITY_OF_SERVICE, ImpersonationLevel), ulong, sizeof(ULONG));
	printf("\t[FieldOffset(%lu)] public %s ContextTrackingMode; // field size is %zu\n", FIELD_OFFSET(SECURITY_QUALITY_OF_SERVICE, ContextTrackingMode), boolean, sizeof(BOOLEAN));
	printf("\t[FieldOffset(%lu)] public %s EffectiveOnly; // field size is %zu\n", FIELD_OFFSET(SECURITY_QUALITY_OF_SERVICE, EffectiveOnly), boolean, sizeof(BOOLEAN));
	printf("}\n\n");

	printf("[StructLayout(LayoutKind.Explicit, Pack = 0)]\n");
	printf("private unsafe struct _MFT_ENUM_DATA\n{\n");
	printf("\t[FieldOffset(%lu)] public %s StartFileReferenceNumber; // field size is %zu\n", FIELD_OFFSET(MFT_ENUM_DATA, StartFileReferenceNumber), ulong, sizeof(ULONGLONG));
	printf("\t[FieldOffset(%lu)] public %s LowUsn; // field size is %zu\n", FIELD_OFFSET(MFT_ENUM_DATA, LowUsn), ulong, sizeof(ULONGLONG));
	printf("\t[FieldOffset(%lu)] public %s HighUsn; // field size is %zu\n", FIELD_OFFSET(MFT_ENUM_DATA, HighUsn), ulong, sizeof(ULONGLONG));
	printf("\t[FieldOffset(%lu)] public %s MinMajorVersion; // field size is %zu\n", FIELD_OFFSET(MFT_ENUM_DATA, MinMajorVersion), ushort, sizeof(USHORT));
	printf("\t[FieldOffset(%lu)] public %s MaxMajorVersion; // field size is %zu\n", FIELD_OFFSET(MFT_ENUM_DATA, MaxMajorVersion), ushort, sizeof(USHORT));
	printf("}\n\n");

	/* 
	typedef struct {

    USN StartUsn;
    ULONG ReasonMask;
    ULONG ReturnOnlyOnClose;
    ULONGLONG Timeout;
    ULONGLONG BytesToWaitFor;
    ULONGLONG UsnJournalID;
    USHORT MinMajorVersion;
    USHORT MaxMajorVersion;

	} READ_USN_JOURNAL_DATA_V1, *PREAD_USN_JOURNAL_DATA_V1;
	*/
	printf("[StructLayout(LayoutKind.Explicit, Pack = 0)]\n");
	printf("private struct _READ_USN_JOURNAL_DATA\n{\n");
	printf("\t[FieldOffset(%lu)] public %s StartUsn; // field size is %zu\n", FIELD_OFFSET(READ_USN_JOURNAL_DATA, StartUsn), ulong, sizeof(ULONGLONG));
	printf("\t[FieldOffset(%lu)] public %s ReasonMask; // field size is %zu\n", FIELD_OFFSET(READ_USN_JOURNAL_DATA, ReasonMask), uint, sizeof(unsigned));
	printf("\t[FieldOffset(%lu)] public %s ReturnOnlyOnClose; // field size is %zu\n", FIELD_OFFSET(READ_USN_JOURNAL_DATA, ReturnOnlyOnClose), uint, sizeof(unsigned));
	printf("\t[FieldOffset(%lu)] public %s Timeout; // field size is %zu\n", FIELD_OFFSET(READ_USN_JOURNAL_DATA, Timeout), ulong, sizeof(ULONGLONG));
	printf("\t[FieldOffset(%lu)] public %s BytesToWaitFor; // field size is %zu\n", FIELD_OFFSET(READ_USN_JOURNAL_DATA, BytesToWaitFor), ulong, sizeof(ULONGLONG));
	printf("\t[FieldOffset(%lu)] public %s UsnJournalID; // field size is %zu\n", FIELD_OFFSET(READ_USN_JOURNAL_DATA, UsnJournalID), ulong, sizeof(ULONGLONG));
	printf("\t[FieldOffset(%lu)] public %s MinMajorVersion; // field size is %zu\n", FIELD_OFFSET(READ_USN_JOURNAL_DATA, MinMajorVersion), ushort, sizeof(USHORT));
	printf("\t[FieldOffset(%lu)] public %s MaxMajorVersion; // field size is %zu\n", FIELD_OFFSET(READ_USN_JOURNAL_DATA, MaxMajorVersion), ushort, sizeof(USHORT));
	printf("}\n\n");


	printf("[StructLayout(LayoutKind.Explicit, Pack = 0)]\n");
	printf("private struct _USN_RECORD_EXTENT\n{\n");
	printf("\t[FieldOffset(%lu)] public %s Usn; // field size is %zu\n", FIELD_OFFSET(USN_RECORD_EXTENT, Offset), ulong, sizeof(ULONGLONG));
	printf("\t[FieldOffset(%lu)] public %s Usn; // field size is %zu\n", FIELD_OFFSET(USN_RECORD_EXTENT, Length), ulong, sizeof(ULONGLONG));
	printf("}\n\n");

	printf("[StructLayout(LayoutKind.Explicit, Pack = 0)]\n");
	printf("private struct _USN_RECORD\n{\n");
	printf("\t[FieldOffset(%lu)] public %s RecordLength; // field size is %zu\n", FIELD_OFFSET(USN_RECORD_V4, Header.RecordLength), ulong, sizeof(ULONGLONG));
	printf("\t[FieldOffset(%lu)] public %s MajorVersion; // field size is %zu\n", FIELD_OFFSET(USN_RECORD_V4, Header.MajorVersion), ushort, sizeof(USHORT));
	printf("\t[FieldOffset(%lu)] public %s MinorVersion; // field size is %zu\n", FIELD_OFFSET(USN_RECORD_V4, Header.MinorVersion), ushort, sizeof(USHORT));
	printf("\t[FieldOffset(%lu)] public %s FileReferenceNumber; // field size is %zu\n", FIELD_OFFSET(USN_RECORD_V4, FileReferenceNumber), uchar, sizeof(FILE_ID_128) * sizeof(USHORT));
	printf("\t[FieldOffset(%lu)] public %s ParentFileReferenceNumber; // field size is %zu\n", FIELD_OFFSET(USN_RECORD_V4, ParentFileReferenceNumber), uchar, sizeof(FILE_ID_128) * sizeof(USHORT));
	printf("\t[FieldOffset(%lu)] public %s Usn; // field size is %zu\n", FIELD_OFFSET(USN_RECORD_V4, Usn), ulong, sizeof(ULONGLONG));
	printf("\t[FieldOffset(%lu)] public %s Reason; // field size is %zu\n", FIELD_OFFSET(USN_RECORD_V4, Reason), uint, sizeof(unsigned));
	printf("\t[FieldOffset(%lu)] public %s RemainingExtents; // field size is %zu\n", FIELD_OFFSET(USN_RECORD_V4, RemainingExtents), uint, sizeof(unsigned));
	printf("\t[FieldOffset(%lu)] public %s SourceInfo; // field size is %zu\n", FIELD_OFFSET(USN_RECORD_V4, SourceInfo), uint, sizeof(unsigned));
	printf("\t[FieldOffset(%lu)] public %s NumberOfExtents; // field size is %zu\n", FIELD_OFFSET(USN_RECORD_V4, NumberOfExtents), ushort, sizeof(USHORT));
	printf("\t[FieldOffset(%lu)] public %s ExtentSize; // field size is %zu\n", FIELD_OFFSET(USN_RECORD_V4, ExtentSize), ushort, sizeof(USHORT));
	printf("}\n\n");


}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
