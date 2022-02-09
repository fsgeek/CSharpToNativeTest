#include "native-internal.h"

//
// These are just test routines; should compile them away when this is not a debug build.
//

#define MYAPI NATIVEAPI

MYAPI void print_line(const char* str)
{
    printf("%s\n", str);
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

MYAPI void NativeTestUsnJournal(UNICODE_STRING drive)
{

}


