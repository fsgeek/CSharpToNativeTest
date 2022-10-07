using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace NativeSupportLibrary
{
    public class NativeLibrary
    {
        // These first routines are here for testing
        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern void print_line(string line);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public unsafe static extern void NativeTestUnicodeString(IntPtr UnicodeString);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public unsafe static extern void NativeTestIoStatusBlock(ref IO_STATUS_BLOCK iosb);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public unsafe static extern void NativeTestLargeInteger(IntPtr LargeInteger);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public unsafe static extern void NativeTestObjectAttributes(IntPtr ObjectAttributes);

        // These are native APIs that should be supported by this library
        // They have been organized by the public header file from which they were derived:
        //   wdm.h
        //   ntddk.h
        //   ntifs.h
        //
        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtCreateFile(
                ref IntPtr handle,
                UInt32 access,
                IntPtr objectAttributes,
                IntPtr ioStatus,
                IntPtr allocSize,
                UInt32 fileAttributes,
                UInt32 share,
                UInt32 createDisposition,
                UInt32 createOptions,
                IntPtr eaBuffer,
                UInt32 eaLength);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtOpenFile(
            ref IntPtr handle,
            UInt32 access,
            IntPtr objectAttributes,
            IntPtr ioStatus,
            UInt32 shareAccess,
            UInt32 openOptions);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtLoadDriver(
            IntPtr DriverServiceName // UNICODE_STRING
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtUnloadDriver(
            IntPtr DriverServiceName
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtQueryInformationFile(
            IntPtr Handle,
            IntPtr IoStatusBlock,
            IntPtr FileInformation,
            UInt32 Length,
            UInt32 FileInformationClass);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtSetInformationFile(
            IntPtr Handle,
            IntPtr IoStatusBlock,
            IntPtr FileInformation,
            UInt32 Length,
            UInt32 FileInformationClass);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtReadFile(
            IntPtr Handle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            IntPtr IoStatusBlock,
            IntPtr Buffer,
            UInt32 Length,
            Int64 ByteOffset,
            IntPtr Key);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtWriteFile(
            IntPtr Handle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            IntPtr IoStatusBlock,
            IntPtr Buffer,
            UInt32 Length,
            Int64 ByteOffset,
            IntPtr Key);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtClose(
            IntPtr Handle
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtCreateDirectoryObject(
            ref IntPtr Handle,
            UInt32 DesiredAccess,
            IntPtr ObjectAttributes);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtMakeTemporaryObject(
            IntPtr Handle
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtCreateSection(
            ref IntPtr Handle,
            UInt32 DesiredAccess,
            IntPtr ObjectAttributes,
            Int64 MaximumSize,
            UInt32 SectionPageProtection,
            UInt32 AllocationAttributes,
            IntPtr FileHandle // can be IntPtr.Zero (non-zero = file backed)
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtOpenSection(
            ref IntPtr Handle,
            UInt32 DesiredAccess,
            IntPtr ObjectAttributes);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtMapViewOfSection(
            IntPtr SectionHandle,
            IntPtr ProcessHandle,
            ref IntPtr BaseAddress,
            IntPtr ZeroBits,
            UInt64 CommitSize,
            Int64 SectionOffset,
            UInt64 ViewSize,
            UInt32 InheritDisposition,
            UInt32 AllocationType,
            UInt32 Win32Protect
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtUnmapViewOfSection(
            IntPtr Handle,
            IntPtr BaseAddress
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtCreateKey(
            ref IntPtr KeyHandle,
            UInt32 DesiredAccess,
            IntPtr ObjectAttributes,
            UInt32 TitleIndex,
            IntPtr Class, // UNICODE_STRING
            UInt32 CreateOptions,
            ref UInt32 Disposition
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtCreateKeyTransacted(
            ref IntPtr KeyHandle,
            UInt32 DesiredAccess,
            IntPtr ObjectAttributes,
            UInt32 TitleIndex,
            IntPtr Class, // UNICODE_STRING
            UInt32 CreateOptions,
            IntPtr TransactionHandle,
            ref UInt32 Disposition
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtCreateRegistryTransaction(
            ref IntPtr TransactionHandle,
            UInt32 DesiredAccess,
            IntPtr ObjectAttributes,
            UInt32 CreateOptions
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtOpenRegistryTransaction(
            ref IntPtr TransactionHandle,
            UInt32 DesiredAccess,
            IntPtr ObjectAttributes
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtCommitRegistryTransaction(
            ref IntPtr TransactionHandle,
            UInt32 Flags
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtRollbackRegistryTransaction(
            ref IntPtr TransactionHandle,
            UInt32 Flags
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtOpenKey(
            ref IntPtr KeyHandle,
            UInt32 DesiredAccess,
            IntPtr ObjectAttributes
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtOpenKeyEx(
            ref IntPtr KeyHandle,
            UInt32 DesiredAccess,
            IntPtr ObjectAttributes,
            UInt32 OpenOptions
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtOpenKeyTransacted(
            ref IntPtr KeyHandle,
            UInt32 DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr TransactionHandle
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtOpenKeyTransactedEx(
            ref IntPtr KeyHandle,
            UInt32 DesiredAccess,
            IntPtr ObjectAttributes,
            UInt32 OpenOptions,
            IntPtr TransactionHandle
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtDeleteKey(
            IntPtr KeyHandle
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtDeleteValueKey(
            IntPtr KeyHandle,
            IntPtr ValueName // UNICODE_STRING
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtEnumerateKey(
            IntPtr KeyHandle,
            UInt32 Index,
            UInt32 KeyInformationClass, // enum
            IntPtr KeyInformation, // buffer
            UInt32 Length,
            ref UInt32 ResultLength
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtEnumerateValueKey(
            IntPtr KeyHandle,
            UInt32 Index,
            UInt32 KeyValueClass, // enum
            IntPtr KeyValueInformation, // buffer
            UInt32 Length,
            ref UInt32 ResultLength
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtFlushKey(
            IntPtr Handle
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtQueryKey(
            IntPtr KeyHandle,
            UInt32 KeyInformationClass, // enum
            IntPtr KeyInformation, // buffer
            UInt32 Length,
            ref UInt32 ResultLength
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtRenameKey(
            IntPtr KeyHandle,
            IntPtr NewName // UNICODE_STRING
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtSaveKey(
            IntPtr KeyHandle,
            IntPtr FileHandle
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtSaveKeyEx(
            IntPtr KeyHandle,
            IntPtr FileHandle,
            UInt32 Format
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtRestoreKey(
            IntPtr KeyHandle,
            IntPtr FileHandle,
            UInt32 Flags
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtSetInformationKey(
            IntPtr KeyHandle,
            UInt32 KeySetInformationClass, // enum
            IntPtr KeySetInformation, // buffer
            UInt32 KeySetInformationLength
            );

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtSetValueKey(
            IntPtr KeyHandle,
            IntPtr ValueName,
            UInt32 TitleIndex,
            UInt32 Type,
            IntPtr Data, // buffer
            UInt32 DataSize
            );

        // Lots to go still
        //
        /* 
         * #if (NTDDI_VERSION >= NTDDI_WIN2K)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwOpenSymbolicLinkObject(
                _Out_ PHANDLE LinkHandle,
                _In_ ACCESS_MASK DesiredAccess,
                _In_ POBJECT_ATTRIBUTES ObjectAttributes
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WIN2K)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwQuerySymbolicLinkObject(
                _In_ HANDLE LinkHandle,
                _Inout_ PUNICODE_STRING LinkTarget,
                _Out_opt_ PULONG ReturnedLength
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwCreateTransactionManager (
                _Out_ PHANDLE TmHandle,
                _In_ ACCESS_MASK DesiredAccess,
                _In_opt_ POBJECT_ATTRIBUTES ObjectAttributes,
                _In_opt_ PUNICODE_STRING LogFileName,
                _In_opt_ ULONG CreateOptions,
                _In_opt_ ULONG CommitStrength
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwOpenTransactionManager (
                _Out_ PHANDLE TmHandle,
                _In_ ACCESS_MASK DesiredAccess,
                _In_opt_ POBJECT_ATTRIBUTES ObjectAttributes,
                _In_opt_ PUNICODE_STRING LogFileName,
                _In_opt_ LPGUID TmIdentity,
                _In_opt_ ULONG OpenOptions
                );
            #endif


            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwRollforwardTransactionManager (
                _In_ HANDLE TransactionManagerHandle,
                _In_opt_ PLARGE_INTEGER TmVirtualClock
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwRecoverTransactionManager (
                _In_ HANDLE TransactionManagerHandle
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwQueryInformationTransactionManager (
                _In_ HANDLE TransactionManagerHandle,
                _In_ TRANSACTIONMANAGER_INFORMATION_CLASS TransactionManagerInformationClass,
                _Out_writes_bytes_(TransactionManagerInformationLength) PVOID TransactionManagerInformation,
                _In_ ULONG TransactionManagerInformationLength,
                _Out_opt_ PULONG ReturnLength
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwSetInformationTransactionManager (
                _In_ HANDLE TmHandle,
                _In_ TRANSACTIONMANAGER_INFORMATION_CLASS TransactionManagerInformationClass,
                _In_ PVOID TransactionManagerInformation,
                _In_ ULONG TransactionManagerInformationLength
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwEnumerateTransactionObject (
                _In_opt_ HANDLE            RootObjectHandle,
                _In_     KTMOBJECT_TYPE    QueryType,
                _Inout_updates_bytes_(ObjectCursorLength) PKTMOBJECT_CURSOR ObjectCursor,
                _In_     ULONG             ObjectCursorLength,
                _Out_    PULONG            ReturnLength
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwCreateTransaction (
                _Out_ PHANDLE TransactionHandle,
                _In_ ACCESS_MASK DesiredAccess,
                _In_opt_ POBJECT_ATTRIBUTES ObjectAttributes,
                _In_opt_ LPGUID Uow,
                _In_opt_ HANDLE TmHandle,
                _In_opt_ ULONG CreateOptions,
                _In_opt_ ULONG IsolationLevel,
                _In_opt_ ULONG IsolationFlags,
                _In_opt_ PLARGE_INTEGER Timeout,
                _In_opt_ PUNICODE_STRING Description
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwOpenTransaction (
                _Out_ PHANDLE TransactionHandle,
                _In_ ACCESS_MASK DesiredAccess,
                _In_opt_ POBJECT_ATTRIBUTES ObjectAttributes,
                _In_ LPGUID Uow,
                _In_opt_ HANDLE TmHandle
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwQueryInformationTransaction (
                _In_ HANDLE TransactionHandle,
                _In_ TRANSACTION_INFORMATION_CLASS TransactionInformationClass,
                _Out_writes_bytes_(TransactionInformationLength) PVOID TransactionInformation,
                _In_ ULONG TransactionInformationLength,
                _Out_opt_ PULONG ReturnLength
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwSetInformationTransaction (
                _In_ HANDLE TransactionHandle,
                _In_ TRANSACTION_INFORMATION_CLASS TransactionInformationClass,
                _In_ PVOID TransactionInformation,
                _In_ ULONG TransactionInformationLength
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwCommitTransaction (
                _In_ HANDLE  TransactionHandle,
                _In_ BOOLEAN Wait
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwRollbackTransaction (
                _In_ HANDLE  TransactionHandle,
                _In_ BOOLEAN Wait
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwCreateResourceManager (
                _Out_ PHANDLE ResourceManagerHandle,
                _In_ ACCESS_MASK DesiredAccess,
                _In_ HANDLE TmHandle,
                _In_opt_ LPGUID ResourceManagerGuid,
                _In_opt_ POBJECT_ATTRIBUTES ObjectAttributes,
                _In_opt_ ULONG CreateOptions,
                _In_opt_ PUNICODE_STRING Description
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwOpenResourceManager (
                _Out_ PHANDLE ResourceManagerHandle,
                _In_ ACCESS_MASK DesiredAccess,
                _In_ HANDLE TmHandle,
                _In_ LPGUID ResourceManagerGuid,
                _In_opt_ POBJECT_ATTRIBUTES ObjectAttributes
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwRecoverResourceManager (
                _In_ HANDLE ResourceManagerHandle
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwGetNotificationResourceManager (
                _In_ HANDLE             ResourceManagerHandle,
                _Out_ PTRANSACTION_NOTIFICATION TransactionNotification,
                _In_ ULONG              NotificationLength,
                _In_ PLARGE_INTEGER         Timeout,
                _Out_opt_ PULONG                    ReturnLength,
                _In_ ULONG                          Asynchronous,
                _In_opt_ ULONG_PTR                  AsynchronousContext
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwQueryInformationResourceManager (
                _In_ HANDLE ResourceManagerHandle,
                _In_ RESOURCEMANAGER_INFORMATION_CLASS ResourceManagerInformationClass,
                _Out_writes_bytes_(ResourceManagerInformationLength) PVOID ResourceManagerInformation,
                _In_ ULONG ResourceManagerInformationLength,
                _Out_opt_ PULONG ReturnLength
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwSetInformationResourceManager (
                _In_ HANDLE ResourceManagerHandle,
                _In_ RESOURCEMANAGER_INFORMATION_CLASS ResourceManagerInformationClass,
                _In_reads_bytes_(ResourceManagerInformationLength) PVOID ResourceManagerInformation,
                _In_ ULONG ResourceManagerInformationLength
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwCreateEnlistment (
                _Out_ PHANDLE EnlistmentHandle,
                _In_ ACCESS_MASK DesiredAccess,
                _In_ HANDLE ResourceManagerHandle,
                _In_ HANDLE TransactionHandle,
                _In_opt_ POBJECT_ATTRIBUTES ObjectAttributes,
                _In_opt_ ULONG CreateOptions,
                _In_ NOTIFICATION_MASK NotificationMask,
                _In_opt_ PVOID EnlistmentKey
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwOpenEnlistment (
                _Out_ PHANDLE EnlistmentHandle,
                _In_ ACCESS_MASK DesiredAccess,
                _In_ HANDLE RmHandle,
                _In_ LPGUID EnlistmentGuid,
                _In_opt_ POBJECT_ATTRIBUTES ObjectAttributes
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwQueryInformationEnlistment (
                _In_ HANDLE EnlistmentHandle,
                _In_ ENLISTMENT_INFORMATION_CLASS EnlistmentInformationClass,
                _Out_writes_bytes_(EnlistmentInformationLength) PVOID EnlistmentInformation,
                _In_ ULONG EnlistmentInformationLength,
                _Out_opt_ PULONG ReturnLength
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwSetInformationEnlistment (
                _In_ HANDLE EnlistmentHandle,
                _In_ ENLISTMENT_INFORMATION_CLASS EnlistmentInformationClass,
                _In_reads_bytes_(EnlistmentInformationLength) PVOID EnlistmentInformation,
                _In_ ULONG EnlistmentInformationLength
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwRecoverEnlistment (
                _In_ HANDLE EnlistmentHandle,
                _In_opt_ PVOID EnlistmentKey
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwPrePrepareEnlistment (
                _In_ HANDLE EnlistmentHandle,
                _In_opt_ PLARGE_INTEGER TmVirtualClock
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwPrepareEnlistment (
                _In_ HANDLE EnlistmentHandle,
                _In_opt_ PLARGE_INTEGER TmVirtualClock
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwCommitEnlistment (
                _In_ HANDLE EnlistmentHandle,
                _In_opt_ PLARGE_INTEGER TmVirtualClock
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwRollbackEnlistment (
                _In_ HANDLE EnlistmentHandle,
                _In_opt_ PLARGE_INTEGER TmVirtualClock
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwPrePrepareComplete (
                _In_ HANDLE            EnlistmentHandle,
                _In_opt_ PLARGE_INTEGER TmVirtualClock
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwPrepareComplete (
                _In_ HANDLE            EnlistmentHandle,
                _In_opt_ PLARGE_INTEGER TmVirtualClock
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwCommitComplete (
                _In_ HANDLE            EnlistmentHandle,
                _In_opt_ PLARGE_INTEGER TmVirtualClock
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwReadOnlyEnlistment (
                _In_ HANDLE            EnlistmentHandle,
                _In_opt_ PLARGE_INTEGER TmVirtualClock
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwRollbackComplete (
                _In_ HANDLE            EnlistmentHandle,
                _In_opt_ PLARGE_INTEGER TmVirtualClock
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_VISTA)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwSinglePhaseReject (
                _In_ HANDLE            EnlistmentHandle,
                _In_opt_ PLARGE_INTEGER TmVirtualClock
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WS03)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSCALLAPI
            NTSTATUS
            NTAPI
            ZwOpenEvent (
                _Out_ PHANDLE EventHandle,
                _In_ ACCESS_MASK DesiredAccess,
                _In_ POBJECT_ATTRIBUTES ObjectAttributes
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WIN10_RS2)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwQueryInformationByName (
                _In_ POBJECT_ATTRIBUTES ObjectAttributes,
                _Out_ PIO_STATUS_BLOCK IoStatusBlock,
                _Out_writes_bytes_(Length) PVOID FileInformation,
                _In_ ULONG Length,
                _In_ FILE_INFORMATION_CLASS FileInformationClass
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WIN2K)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwQueryFullAttributesFile(
                _In_ POBJECT_ATTRIBUTES ObjectAttributes,
                _Out_ PFILE_NETWORK_OPEN_INFORMATION FileInformation
                );
            #endif

         */


        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtQueryFullAttributesFile(
            IntPtr ObjectAttributes,
            IntPtr FileInformation);

        //
        // ntddk.h
        //

        /*
         * 
         #if (NTDDI_VERSION >= NTDDI_WIN2K)
            //@[comment("MVI_tracked")]
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwSetInformationThread (
                _In_ HANDLE ThreadHandle,
                _In_ THREADINFOCLASS ThreadInformationClass,
                _In_reads_bytes_(ThreadInformationLength) PVOID ThreadInformation,
                _In_ ULONG ThreadInformationLength
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WIN2K)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            _When_(return=0, __drv_allocatesMem(TimerObject))
            NTSTATUS
            ZwCreateTimer (
                _Out_ PHANDLE TimerHandle,
                _In_ ACCESS_MASK DesiredAccess,
                _In_opt_ POBJECT_ATTRIBUTES ObjectAttributes,
                _In_ TIMER_TYPE TimerType
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WIN2K)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSTATUS
            ZwOpenTimer (
                _Out_ PHANDLE TimerHandle,
                _In_ ACCESS_MASK DesiredAccess,
                _In_ POBJECT_ATTRIBUTES ObjectAttributes
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WIN2K)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSTATUS
            ZwCancelTimer (
                _In_ HANDLE TimerHandle,
                _Out_opt_ PBOOLEAN CurrentState
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WIN2K)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSTATUS
            ZwSetTimer (
                _In_ HANDLE TimerHandle,
                _In_ PLARGE_INTEGER DueTime,
                _In_opt_ PTIMER_APC_ROUTINE TimerApcRoutine,
                _In_opt_ PVOID TimerContext,
                _In_ BOOLEAN ResumeTimer,
                _In_opt_ LONG Period,
                _Out_opt_ PBOOLEAN PreviousState
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WIN7)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSTATUS
            ZwSetTimerEx (
                _In_ HANDLE TimerHandle,
                _In_ TIMER_SET_INFORMATION_CLASS TimerSetInformationClass,
                _Inout_updates_bytes_opt_(TimerSetInformationLength) PVOID TimerSetInformation,
                _In_ ULONG TimerSetInformationLength
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WIN2K)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwQueryVolumeInformationFile(
                _In_ HANDLE FileHandle,
                _Out_ PIO_STATUS_BLOCK IoStatusBlock,
                _Out_writes_bytes_(Length) PVOID FsInformation,
                _In_ ULONG Length,
                _In_ FS_INFORMATION_CLASS FsInformationClass
                );
            #endif
        */

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtDeviceIoControlFile(
            IntPtr Handle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            IntPtr IoStatusBlock,
            UInt32 FsControlCode,
            IntPtr InputBuffer,
            UInt32 InputBufferLength,
            IntPtr OutputBuffer,
            UInt32 OutputBufferLength);
        /*
            #if (NTDDI_VERSION >= NTDDI_WIN2K)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwDisplayString(
                _In_ PUNICODE_STRING String
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WIN2K)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwPowerInformation(
                _In_ POWER_INFORMATION_LEVEL InformationLevel,
                _In_reads_bytes_opt_(InputBufferLength) PVOID InputBuffer,
                _In_ ULONG InputBufferLength,
                _Out_writes_bytes_opt_(OutputBufferLength) PVOID OutputBuffer,
                _In_ ULONG OutputBufferLength
                );
            #endif


            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwAllocateLocallyUniqueId(
                _Out_ PLUID Luid
                );

            _IRQL_requires_max_(PASSIVE_LEVEL)
            //@[comment("MVI_tracked")]
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwTerminateProcess (
                _In_opt_ HANDLE ProcessHandle,
                _In_ NTSTATUS ExitStatus
                );

            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwOpenProcess (
                _Out_ PHANDLE ProcessHandle,
                _In_ ACCESS_MASK DesiredAccess,
                _In_ POBJECT_ATTRIBUTES ObjectAttributes,
                _In_opt_ PCLIENT_ID ClientId
                );

         */

        //
        // ntifs.h
        //

        /*
             #if (NTDDI_VERSION >= NTDDI_WIN2K)
            //@[comment("MVI_tracked")]
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwQueryObject(
                _In_opt_ HANDLE Handle,
                _In_ OBJECT_INFORMATION_CLASS ObjectInformationClass,
                _Out_writes_bytes_opt_(ObjectInformationLength) PVOID ObjectInformation,
                _In_ ULONG ObjectInformationLength,
                _Out_opt_ PULONG ReturnLength
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WIN2K)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwNotifyChangeKey(
                _In_ HANDLE KeyHandle,
                _In_opt_ HANDLE Event,
                _In_opt_ PIO_APC_ROUTINE ApcRoutine,
                _In_opt_ PVOID ApcContext,
                _Out_ PIO_STATUS_BLOCK IoStatusBlock,
                _In_ ULONG CompletionFilter,
                _In_ BOOLEAN WatchTree,
                _Out_writes_bytes_opt_(BufferSize) PVOID Buffer,
                _In_ ULONG BufferSize,
                _In_ BOOLEAN Asynchronous
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WIN2K)
            //@[comment("MVI_tracked")]
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwCreateEvent (
                _Out_ PHANDLE EventHandle,
                _In_ ACCESS_MASK DesiredAccess,
                _In_opt_ POBJECT_ATTRIBUTES ObjectAttributes,
                _In_ EVENT_TYPE EventType,
                _In_ BOOLEAN InitialState
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WIN2K)
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwDeleteFile(
                _In_ POBJECT_ATTRIBUTES ObjectAttributes
                );
            #endif

            #if (NTDDI_VERSION >= NTDDI_WIN2K)
            //@[comment("MVI_tracked")]
            _IRQL_requires_max_(PASSIVE_LEVEL)
            NTSYSAPI
            NTSTATUS
            NTAPI
            ZwDeviceIoControlFile(
                _In_ HANDLE FileHandle,
                _In_opt_ HANDLE Event,
                _In_opt_ PIO_APC_ROUTINE ApcRoutine,
                _In_opt_ PVOID ApcContext,
                _Out_ PIO_STATUS_BLOCK IoStatusBlock,
                _In_ ULONG IoControlCode,
                _In_reads_bytes_opt_(InputBufferLength) PVOID InputBuffer,
                _In_ ULONG InputBufferLength,
                _Out_writes_bytes_opt_(OutputBufferLength) PVOID OutputBuffer,
                _In_ ULONG OutputBufferLength
                );
            #endif
           */

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtQueryDirectoryFile(
            IntPtr FileHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            IntPtr IoStatusBlock,
            IntPtr FileInformation,
            UInt32 Length,
            UInt32 FileInformationClass,
            UInt32 ReturnSingleEntry,
            IntPtr FileName,
            UInt32 RestartScan);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtQueryDirectoryFileEx(
            IntPtr FileHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            IntPtr IoStatusBlock,
            IntPtr FileInformation,
            UInt32 Length,
            UInt32 FileInformationClass,
            UInt32 QueryFlags,
            IntPtr FileName);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtQueryVolumeInformationFile(
            IntPtr Handle,
            IntPtr IoStatusBlock,
            IntPtr FsInformation,
            UInt32 Length,
            UInt32 FsInformationClass);

        /*

         #if (NTDDI_VERSION >= NTDDI_WIN2K)
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwSetVolumeInformationFile(
             _In_ HANDLE FileHandle,
             _Out_ PIO_STATUS_BLOCK IoStatusBlock,
             _In_reads_bytes_(Length) PVOID FsInformation,
             _In_ ULONG Length,
             _In_ FS_INFORMATION_CLASS FsInformationClass
             );
         #endif
        */

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtFsControlFile(
            IntPtr Handle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            IntPtr IoStatusBlock,
            UInt32 FsControlCode,
            IntPtr InputBuffer,
            UInt32 InputBufferLength,
            IntPtr OutputBuffer,
            UInt32 OutputBufferLength);

        /*

         // begin_nthal

         #if (NTDDI_VERSION >= NTDDI_WIN2K)
         //@[comment("MVI_tracked")]
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwDuplicateObject(
             _In_ HANDLE SourceProcessHandle,
             _In_ HANDLE SourceHandle,
             _In_opt_ HANDLE TargetProcessHandle,
             _Out_opt_ PHANDLE TargetHandle,
             _In_ ACCESS_MASK DesiredAccess,
             _In_ ULONG HandleAttributes,
             _In_ ULONG Options
             );
         #endif

         // end_nthal

         #if (NTDDI_VERSION >= NTDDI_WIN2K)
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwOpenDirectoryObject(
             _Out_ PHANDLE DirectoryHandle,
             _In_ ACCESS_MASK DesiredAccess,
             _In_ POBJECT_ATTRIBUTES ObjectAttributes
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WIN2K)
         //@[comment("MVI_tracked")]
         _Must_inspect_result_
         _IRQL_requires_max_(PASSIVE_LEVEL)
         _When_(return==0, __drv_allocatesMem(Region))
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwAllocateVirtualMemory(
             _In_ HANDLE ProcessHandle,
             _Inout_ PVOID *BaseAddress,
             _In_ ULONG_PTR ZeroBits,
             _Inout_ PSIZE_T RegionSize,
             _In_ ULONG AllocationType,
             _In_ ULONG Protect
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WIN10_RS5)
         _Must_inspect_result_
         _IRQL_requires_max_(PASSIVE_LEVEL)
         _When_(return==0, __drv_allocatesMem(Region))
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwAllocateVirtualMemoryEx(
             _In_ HANDLE ProcessHandle,
             _Inout_ _At_ (*BaseAddress, _Readable_bytes_ (*RegionSize) _Writable_bytes_ (*RegionSize) _Post_readable_byte_size_ (*RegionSize)) PVOID* BaseAddress,
             _Inout_ PSIZE_T RegionSize,
             _In_ ULONG AllocationType,
             _In_ ULONG PageProtection,
             _Inout_updates_opt_(ExtendedParameterCount) PMEM_EXTENDED_PARAMETER ExtendedParameters,
             _In_ ULONG ExtendedParameterCount
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WIN2K)
         //@[comment("MVI_tracked")]
         _IRQL_requires_max_(PASSIVE_LEVEL)
         _When_(return==0, __drv_freesMem(Region))
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwFreeVirtualMemory(
             _In_ HANDLE ProcessHandle,
             _Inout_ PVOID *BaseAddress,
             _Inout_ PSIZE_T RegionSize,
             _In_ ULONG FreeType
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WIN2K)
         //@[comment("MVI_tracked")]
         _IRQL_requires_max_(PASSIVE_LEVEL)
         _Must_inspect_result_
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwQueryVirtualMemory(
             _In_ HANDLE ProcessHandle,
             _In_opt_ PVOID BaseAddress,
             _In_ MEMORY_INFORMATION_CLASS MemoryInformationClass,
             _Out_writes_bytes_(MemoryInformationLength) PVOID MemoryInformation,
             _In_ SIZE_T MemoryInformationLength,
             _Out_opt_ PSIZE_T ReturnLength
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WIN8)
         _IRQL_requires_max_(PASSIVE_LEVEL)
         _Must_inspect_result_
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwSetInformationVirtualMemory(
             _In_ HANDLE ProcessHandle,
             _In_ VIRTUAL_MEMORY_INFORMATION_CLASS VmInformationClass,
             _In_ ULONG_PTR NumberOfEntries,
             _In_reads_(NumberOfEntries) PMEMORY_RANGE_ENTRY VirtualAddresses,
             _In_reads_bytes_(VmInformationLength) PVOID VmInformation,
             _In_ ULONG VmInformationLength
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WIN2K)
         //@[comment("MVI_tracked")]
         _When_(Timeout == NULL, _IRQL_requires_max_(APC_LEVEL))
         _When_(Timeout->QuadPart != 0, _IRQL_requires_max_(APC_LEVEL))
         _When_(Timeout->QuadPart == 0, _IRQL_requires_max_(DISPATCH_LEVEL))
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwWaitForSingleObject(
             _In_ HANDLE Handle,
             _In_ BOOLEAN Alertable,
             _In_opt_ PLARGE_INTEGER Timeout
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WIN2K)
         //@[comment("MVI_tracked")]
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwSetEvent (
             _In_ HANDLE EventHandle,
             _Out_opt_ PLONG PreviousState
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WIN2K)
         _IRQL_requires_max_(APC_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwFlushVirtualMemory(
             _In_ HANDLE ProcessHandle,
             _Inout_ PVOID *BaseAddress,
             _Inout_ PSIZE_T RegionSize,
             _Out_ PIO_STATUS_BLOCK IoStatus
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WINXP)
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwOpenProcessTokenEx(
             _In_ HANDLE ProcessHandle,
             _In_ ACCESS_MASK DesiredAccess,
             _In_ ULONG HandleAttributes,
             _Out_ PHANDLE TokenHandle
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WINXP)
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwOpenThreadTokenEx(
             _In_ HANDLE ThreadHandle,
             _In_ ACCESS_MASK DesiredAccess,
             _In_ BOOLEAN OpenAsSelf,
             _In_ ULONG HandleAttributes,
             _Out_ PHANDLE TokenHandle
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WIN2K)
         //@[comment("MVI_tracked")]
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwQueryInformationToken (
             _In_ HANDLE TokenHandle,
             _In_ TOKEN_INFORMATION_CLASS TokenInformationClass,
             _Out_writes_bytes_to_opt_(TokenInformationLength,*ReturnLength) PVOID TokenInformation,
             _In_ ULONG TokenInformationLength,
             _Out_ PULONG ReturnLength
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WIN7)
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwSetInformationToken (
             _In_ HANDLE TokenHandle,
             _In_ TOKEN_INFORMATION_CLASS TokenInformationClass,
             _In_reads_bytes_(TokenInformationLength) PVOID TokenInformation,
             _In_ ULONG TokenInformationLength
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WIN2K)
         //@[comment("MVI_tracked")]
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwSetSecurityObject(
             _In_ HANDLE Handle,
             _In_ SECURITY_INFORMATION SecurityInformation,
             _In_ PSECURITY_DESCRIPTOR SecurityDescriptor
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WIN2K)
         //@[comment("MVI_tracked")]
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwQuerySecurityObject(
             _In_ HANDLE Handle,
             _In_ SECURITY_INFORMATION SecurityInformation,
             _Out_writes_bytes_to_(Length,*LengthNeeded) PSECURITY_DESCRIPTOR SecurityDescriptor,
             _In_ ULONG Length,
             _Out_ PULONG LengthNeeded
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_VISTA)
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwLockFile(
             _In_ HANDLE FileHandle,
             _In_opt_ HANDLE Event,
             _In_opt_ PIO_APC_ROUTINE ApcRoutine,
             _In_opt_ PVOID ApcContext,
             _Out_ PIO_STATUS_BLOCK IoStatusBlock,
             _In_ PLARGE_INTEGER ByteOffset,
             _In_ PLARGE_INTEGER Length,
             _In_ ULONG Key,
             _In_ BOOLEAN FailImmediately,
             _In_ BOOLEAN ExclusiveLock
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_VISTA)
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwUnlockFile(
             _In_ HANDLE FileHandle,
             _Out_ PIO_STATUS_BLOCK IoStatusBlock,
             _In_ PLARGE_INTEGER ByteOffset,
             _In_ PLARGE_INTEGER Length,
             _In_ ULONG Key
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_VISTA)
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwQueryQuotaInformationFile(
             _In_ HANDLE FileHandle,
             _Out_ PIO_STATUS_BLOCK IoStatusBlock,
             _Out_writes_bytes_(Length) PVOID Buffer,
             _In_ ULONG Length,
             _In_ BOOLEAN ReturnSingleEntry,
             _In_reads_bytes_opt_(SidListLength) PVOID SidList,
             _In_ ULONG SidListLength,
             _In_opt_ PSID StartSid,
             _In_ BOOLEAN RestartScan
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_VISTA)
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         NTAPI
         ZwSetQuotaInformationFile(
             _In_ HANDLE FileHandle,
             _Out_ PIO_STATUS_BLOCK IoStatusBlock,
             _In_reads_bytes_(Length) PVOID Buffer,
             _In_ ULONG Length
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_VISTA)
         //@[comment("MVI_tracked")]
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         ZwFlushBuffersFile(
             _In_ HANDLE FileHandle,
             _Out_ PIO_STATUS_BLOCK IoStatusBlock
             );
         #endif

         #if (NTDDI_VERSION >= NTDDI_WIN8)
         _IRQL_requires_max_(PASSIVE_LEVEL)
         NTSYSAPI
         NTSTATUS
         ZwFlushBuffersFileEx(
             _In_ HANDLE FileHandle,
             _In_ ULONG FLags,
             _In_reads_bytes_(ParametersSize) PVOID Parameters,
             _In_ ULONG ParametersSize,
             _Out_ PIO_STATUS_BLOCK IoStatusBlock
             );
         #endif
         */

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtQueryEaFile(
            IntPtr FileHandle,
            IntPtr IoStatusBlock,
            IntPtr Buffer,
            UInt32 Length,
            UInt32 ReturnSingleEntry,
            IntPtr EaList,
            UInt32 EaListLength,
            ref UInt32? EaIndex,
            UInt32 RestartScan);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtSetEaFile(
            IntPtr FileHandle,
            IntPtr IoStatusBlock,
            IntPtr Buffer,
            UInt32 Length
            );

        /*
        _IRQL_requires_max_(PASSIVE_LEVEL)
        NTSYSAPI
        NTSTATUS
        NTAPI
        ZwDuplicateToken(
            _In_ HANDLE ExistingTokenHandle,
            _In_ ACCESS_MASK DesiredAccess,
            _In_opt_ POBJECT_ATTRIBUTES ObjectAttributes,
            _In_ BOOLEAN EffectiveOnly,
            _In_ TOKEN_TYPE TokenType,
            _Out_ PHANDLE NewTokenHandle
            );

     */

    }
}
