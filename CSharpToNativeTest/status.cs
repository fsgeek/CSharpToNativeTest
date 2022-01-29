using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpToNativeTest
{
    #region enums
    public enum NtStatusCodes
    {
        STATUS_WAIT_0 = unchecked((int)0x00000000),
        STATUS_SUCCESS = unchecked((int)0x00000000),
        STATUS_WAIT_1 = unchecked((int)0x00000001),
        STATUS_WAIT_2 = unchecked((int)0x00000002),
        STATUS_WAIT_3 = unchecked((int)0x00000003),
        STATUS_WAIT_63 = unchecked((int)0x0000003F),
        STATUS_ABANDONED = unchecked((int)0x00000080),
        STATUS_ABANDONED_WAIT_0 = unchecked((int)0x00000080),
        STATUS_ABANDONED_WAIT_63 = unchecked((int)0x000000BF),
        STATUS_USER_APC = unchecked((int)0x000000C0),
        STATUS_ALREADY_COMPLETE = unchecked((int)0x000000FF),
        STATUS_KERNEL_APC = unchecked((int)0x00000100),
        STATUS_ALERTED = unchecked((int)0x00000101),
        STATUS_TIMEOUT = unchecked((int)0x00000102),
        STATUS_PENDING = unchecked((int)0x00000103),
        STATUS_REPARSE = unchecked((int)0x00000104),
        STATUS_MORE_ENTRIES = unchecked((int)0x00000105),
        STATUS_NOT_ALL_ASSIGNED = unchecked((int)0x00000106),
        STATUS_SOME_NOT_MAPPED = unchecked((int)0x00000107),
        STATUS_OPLOCK_BREAK_IN_PROGRESS = unchecked((int)0x00000108),
        STATUS_VOLUME_MOUNTED = unchecked((int)0x00000109),
        STATUS_RXACT_COMMITTED = unchecked((int)0x0000010A),
        STATUS_NOTIFY_CLEANUP = unchecked((int)0x0000010B),
        STATUS_NOTIFY_ENUM_DIR = unchecked((int)0x0000010C),
        STATUS_NO_QUOTAS_FOR_ACCOUNT = unchecked((int)0x0000010D),
        STATUS_PRIMARY_TRANSPORT_CONNECT_FAILED = unchecked((int)0x0000010E),
        STATUS_PAGE_FAULT_TRANSITION = unchecked((int)0x00000110),
        STATUS_PAGE_FAULT_DEMAND_ZERO = unchecked((int)0x00000111),
        STATUS_PAGE_FAULT_COPY_ON_WRITE = unchecked((int)0x00000112),
        STATUS_PAGE_FAULT_GUARD_PAGE = unchecked((int)0x00000113),
        STATUS_PAGE_FAULT_PAGING_FILE = unchecked((int)0x00000114),
        STATUS_CACHE_PAGE_LOCKED = unchecked((int)0x00000115),
        STATUS_CRASH_DUMP = unchecked((int)0x00000116),
        STATUS_BUFFER_ALL_ZEROS = unchecked((int)0x00000117),
        STATUS_REPARSE_OBJECT = unchecked((int)0x00000118),
        STATUS_RESOURCE_REQUIREMENTS_CHANGED = unchecked((int)0x00000119),
        STATUS_TRANSLATION_COMPLETE = unchecked((int)0x00000120),
        STATUS_DS_MEMBERSHIP_EVALUATED_LOCALLY = unchecked((int)0x00000121),
        STATUS_NOTHING_TO_TERMINATE = unchecked((int)0x00000122),
        STATUS_PROCESS_NOT_IN_JOB = unchecked((int)0x00000123),
        STATUS_PROCESS_IN_JOB = unchecked((int)0x00000124),
        STATUS_VOLSNAP_HIBERNATE_READY = unchecked((int)0x00000125),
        STATUS_FSFILTER_OP_COMPLETED_SUCCESSFULLY = unchecked((int)0x00000126),
        STATUS_INTERRUPT_VECTOR_ALREADY_CONNECTED = unchecked((int)0x00000127),
        STATUS_INTERRUPT_STILL_CONNECTED = unchecked((int)0x00000128),
        STATUS_PROCESS_CLONED = unchecked((int)0x00000129),
        STATUS_FILE_LOCKED_WITH_ONLY_READERS = unchecked((int)0x0000012A),
        STATUS_FILE_LOCKED_WITH_WRITERS = unchecked((int)0x0000012B),
        STATUS_VALID_IMAGE_HASH = unchecked((int)0x0000012C),
        STATUS_VALID_CATALOG_HASH = unchecked((int)0x0000012D),
        STATUS_VALID_STRONG_CODE_HASH = unchecked((int)0x0000012E),
        STATUS_GHOSTED = unchecked((int)0x0000012F),
        STATUS_DATA_OVERWRITTEN = unchecked((int)0x00000130),
        STATUS_RESOURCEMANAGER_READ_ONLY = unchecked((int)0x00000202),
        STATUS_RING_PREVIOUSLY_EMPTY = unchecked((int)0x00000210),
        STATUS_RING_PREVIOUSLY_FULL = unchecked((int)0x00000211),
        STATUS_RING_PREVIOUSLY_ABOVE_QUOTA = unchecked((int)0x00000212),
        STATUS_RING_NEWLY_EMPTY = unchecked((int)0x00000213),
        STATUS_RING_SIGNAL_OPPOSITE_ENDPOINT = unchecked((int)0x00000214),
        STATUS_OPLOCK_SWITCHED_TO_NEW_HANDLE = unchecked((int)0x00000215),
        STATUS_OPLOCK_HANDLE_CLOSED = unchecked((int)0x00000216),
        STATUS_WAIT_FOR_OPLOCK = unchecked((int)0x00000367),
        STATUS_REPARSE_GLOBAL = unchecked((int)0x00000368),
        STATUS_FLT_IO_COMPLETE = unchecked((int)0x001C0001),
        STATUS_OBJECT_NAME_EXISTS = unchecked((int)0x40000000),
        STATUS_THREAD_WAS_SUSPENDED = unchecked((int)0x40000001),
        STATUS_WORKING_SET_LIMIT_RANGE = unchecked((int)0x40000002),
        STATUS_IMAGE_NOT_AT_BASE = unchecked((int)0x40000003),
        STATUS_RXACT_STATE_CREATED = unchecked((int)0x40000004),
        STATUS_SEGMENT_NOTIFICATION = unchecked((int)0x40000005),
        STATUS_LOCAL_USER_SESSION_KEY = unchecked((int)0x40000006),
        STATUS_BAD_CURRENT_DIRECTORY = unchecked((int)0x40000007),
        STATUS_SERIAL_MORE_WRITES = unchecked((int)0x40000008),
        STATUS_REGISTRY_RECOVERED = unchecked((int)0x40000009),
        STATUS_FT_READ_RECOVERY_FROM_BACKUP = unchecked((int)0x4000000A),
        STATUS_FT_WRITE_RECOVERY = unchecked((int)0x4000000B),
        STATUS_SERIAL_COUNTER_TIMEOUT = unchecked((int)0x4000000C),
        STATUS_NULL_LM_PASSWORD = unchecked((int)0x4000000D),
        STATUS_IMAGE_MACHINE_TYPE_MISMATCH = unchecked((int)0x4000000E),
        STATUS_RECEIVE_PARTIAL = unchecked((int)0x4000000F),
        STATUS_RECEIVE_EXPEDITED = unchecked((int)0x40000010),
        STATUS_RECEIVE_PARTIAL_EXPEDITED = unchecked((int)0x40000011),
        STATUS_EVENT_DONE = unchecked((int)0x40000012),
        STATUS_EVENT_PENDING = unchecked((int)0x40000013),
        STATUS_CHECKING_FILE_SYSTEM = unchecked((int)0x40000014),
        STATUS_FATAL_APP_EXIT = unchecked((int)0x40000015),
        STATUS_PREDEFINED_HANDLE = unchecked((int)0x40000016),
        STATUS_WAS_UNLOCKED = unchecked((int)0x40000017),
        STATUS_SERVICE_NOTIFICATION = unchecked((int)0x40000018),
        STATUS_WAS_LOCKED = unchecked((int)0x40000019),
        STATUS_LOG_HARD_ERROR = unchecked((int)0x4000001A),
        STATUS_ALREADY_WIN32 = unchecked((int)0x4000001B),
        STATUS_WX86_UNSIMULATE = unchecked((int)0x4000001C),
        STATUS_WX86_CONTINUE = unchecked((int)0x4000001D),
        STATUS_WX86_SINGLE_STEP = unchecked((int)0x4000001E),
        STATUS_WX86_BREAKPOINT = unchecked((int)0x4000001F),
        STATUS_WX86_EXCEPTION_CONTINUE = unchecked((int)0x40000020),
        STATUS_WX86_EXCEPTION_LASTCHANCE = unchecked((int)0x40000021),
        STATUS_WX86_EXCEPTION_CHAIN = unchecked((int)0x40000022),
        STATUS_IMAGE_MACHINE_TYPE_MISMATCH_EXE = unchecked((int)0x40000023),
        STATUS_NO_YIELD_PERFORMED = unchecked((int)0x40000024),
        STATUS_TIMER_RESUME_IGNORED = unchecked((int)0x40000025),
        STATUS_ARBITRATION_UNHANDLED = unchecked((int)0x40000026),
        STATUS_CARDBUS_NOT_SUPPORTED = unchecked((int)0x40000027),
        STATUS_WX86_CREATEWX86TIB = unchecked((int)0x40000028),
        STATUS_MP_PROCESSOR_MISMATCH = unchecked((int)0x40000029),
        STATUS_HIBERNATED = unchecked((int)0x4000002A),
        STATUS_RESUME_HIBERNATION = unchecked((int)0x4000002B),
        STATUS_FIRMWARE_UPDATED = unchecked((int)0x4000002C),
        STATUS_DRIVERS_LEAKING_LOCKED_PAGES = unchecked((int)0x4000002D),
        STATUS_MESSAGE_RETRIEVED = unchecked((int)0x4000002E),
        STATUS_SYSTEM_POWERSTATE_TRANSITION = unchecked((int)0x4000002F),
        STATUS_ALPC_CHECK_COMPLETION_LIST = unchecked((int)0x40000030),
        STATUS_SYSTEM_POWERSTATE_COMPLEX_TRANSITION = unchecked((int)0x40000031),
        STATUS_ACCESS_AUDIT_BY_POLICY = unchecked((int)0x40000032),
        STATUS_ABANDON_HIBERFILE = unchecked((int)0x40000033),
        STATUS_BIZRULES_NOT_ENABLED = unchecked((int)0x40000034),
        STATUS_FT_READ_FROM_COPY = unchecked((int)0x40000035),
        STATUS_IMAGE_AT_DIFFERENT_BASE = unchecked((int)0x40000036),
        STATUS_PATCH_DEFERRED = unchecked((int)0x40000037),
        STATUS_EMULATION_BREAKPOINT = unchecked((int)0x40000038),
        STATUS_EMULATION_SYSCALL = unchecked((int)0x40000039),
        STATUS_HEURISTIC_DAMAGE_POSSIBLE = unchecked((int)0x40190001),
        STATUS_GUARD_PAGE_VIOLATION = unchecked((int)0x80000001),
        STATUS_DATATYPE_MISALIGNMENT = unchecked((int)0x80000002),
        STATUS_BREAKPOINT = unchecked((int)0x80000003),
        STATUS_SINGLE_STEP = unchecked((int)0x80000004),
        STATUS_BUFFER_OVERFLOW = unchecked((int)0x80000005),
        STATUS_NO_MORE_FILES = unchecked((int)0x80000006),
        STATUS_WAKE_SYSTEM_DEBUGGER = unchecked((int)0x80000007),
        STATUS_HANDLES_CLOSED = unchecked((int)0x8000000A),
        STATUS_NO_INHERITANCE = unchecked((int)0x8000000B),
        STATUS_GUID_SUBSTITUTION_MADE = unchecked((int)0x8000000C),
        STATUS_PARTIAL_COPY = unchecked((int)0x8000000D),
        STATUS_DEVICE_PAPER_EMPTY = unchecked((int)0x8000000E),
        STATUS_DEVICE_POWERED_OFF = unchecked((int)0x8000000F),
        STATUS_DEVICE_OFF_LINE = unchecked((int)0x80000010),
        STATUS_DEVICE_BUSY = unchecked((int)0x80000011),
        STATUS_NO_MORE_EAS = unchecked((int)0x80000012),
        STATUS_INVALID_EA_NAME = unchecked((int)0x80000013),
        STATUS_EA_LIST_INCONSISTENT = unchecked((int)0x80000014),
        STATUS_INVALID_EA_FLAG = unchecked((int)0x80000015),
        STATUS_VERIFY_REQUIRED = unchecked((int)0x80000016),
        STATUS_EXTRANEOUS_INFORMATION = unchecked((int)0x80000017),
        STATUS_RXACT_COMMIT_NECESSARY = unchecked((int)0x80000018),
        STATUS_NO_MORE_ENTRIES = unchecked((int)0x8000001A),
        STATUS_FILEMARK_DETECTED = unchecked((int)0x8000001B),
        STATUS_MEDIA_CHANGED = unchecked((int)0x8000001C),
        STATUS_BUS_RESET = unchecked((int)0x8000001D),
        STATUS_END_OF_MEDIA = unchecked((int)0x8000001E),
        STATUS_BEGINNING_OF_MEDIA = unchecked((int)0x8000001F),
        STATUS_MEDIA_CHECK = unchecked((int)0x80000020),
        STATUS_SETMARK_DETECTED = unchecked((int)0x80000021),
        STATUS_NO_DATA_DETECTED = unchecked((int)0x80000022),
        STATUS_REDIRECTOR_HAS_OPEN_HANDLES = unchecked((int)0x80000023),
        STATUS_SERVER_HAS_OPEN_HANDLES = unchecked((int)0x80000024),
        STATUS_ALREADY_DISCONNECTED = unchecked((int)0x80000025),
        STATUS_LONGJUMP = unchecked((int)0x80000026),
        STATUS_CLEANER_CARTRIDGE_INSTALLED = unchecked((int)0x80000027),
        STATUS_PLUGPLAY_QUERY_VETOED = unchecked((int)0x80000028),
        STATUS_UNWIND_CONSOLIDATE = unchecked((int)0x80000029),
        STATUS_REGISTRY_HIVE_RECOVERED = unchecked((int)0x8000002A),
        STATUS_DLL_MIGHT_BE_INSECURE = unchecked((int)0x8000002B),
        STATUS_DLL_MIGHT_BE_INCOMPATIBLE = unchecked((int)0x8000002C),
        STATUS_STOPPED_ON_SYMLINK = unchecked((int)0x8000002D),
        STATUS_CANNOT_GRANT_REQUESTED_OPLOCK = unchecked((int)0x8000002E),
        STATUS_NO_ACE_CONDITION = unchecked((int)0x8000002F),
        STATUS_DEVICE_SUPPORT_IN_PROGRESS = unchecked((int)0x80000030),
        STATUS_DEVICE_POWER_CYCLE_REQUIRED = unchecked((int)0x80000031),
        STATUS_NO_WORK_DONE = unchecked((int)0x80000032),
        STATUS_RETURN_ADDRESS_HIJACK_ATTEMPT = unchecked((int)0x80000033),
        STATUS_RECOVERABLE_BUGCHECK = unchecked((int)0x80000034),
        STATUS_CLUSTER_NODE_ALREADY_UP = unchecked((int)0x80130001),
        STATUS_CLUSTER_NODE_ALREADY_DOWN = unchecked((int)0x80130002),
        STATUS_CLUSTER_NETWORK_ALREADY_ONLINE = unchecked((int)0x80130003),
        STATUS_CLUSTER_NETWORK_ALREADY_OFFLINE = unchecked((int)0x80130004),
        STATUS_CLUSTER_NODE_ALREADY_MEMBER = unchecked((int)0x80130005),
        STATUS_FLT_BUFFER_TOO_SMALL = unchecked((int)0x801C0001),
        STATUS_FVE_PARTIAL_METADATA = unchecked((int)0x80210001),
        STATUS_FVE_TRANSIENT_STATE = unchecked((int)0x80210002),
        STATUS_CLOUD_FILE_PROPERTY_BLOB_CHECKSUM_MISMATCH = unchecked((int)0x8000CF00),
        STATUS_UNSUCCESSFUL = unchecked((int)0xC0000001),
        STATUS_NOT_IMPLEMENTED = unchecked((int)0xC0000002),
        STATUS_INVALID_INFO_CLASS = unchecked((int)0xC0000003),
        STATUS_INFO_LENGTH_MISMATCH = unchecked((int)0xC0000004),
        STATUS_ACCESS_VIOLATION = unchecked((int)0xC0000005),
        STATUS_IN_PAGE_ERROR = unchecked((int)0xC0000006),
        STATUS_PAGEFILE_QUOTA = unchecked((int)0xC0000007),
        STATUS_INVALID_HANDLE = unchecked((int)0xC0000008),
        STATUS_BAD_INITIAL_STACK = unchecked((int)0xC0000009),
        STATUS_BAD_INITIAL_PC = unchecked((int)0xC000000A),
        STATUS_INVALID_CID = unchecked((int)0xC000000B),
        STATUS_TIMER_NOT_CANCELED = unchecked((int)0xC000000C),
        STATUS_INVALID_PARAMETER = unchecked((int)0xC000000D),
        STATUS_NO_SUCH_DEVICE = unchecked((int)0xC000000E),
        STATUS_NO_SUCH_FILE = unchecked((int)0xC000000F),
        STATUS_INVALID_DEVICE_REQUEST = unchecked((int)0xC0000010),
        STATUS_END_OF_FILE = unchecked((int)0xC0000011),
        STATUS_WRONG_VOLUME = unchecked((int)0xC0000012),
        STATUS_NO_MEDIA_IN_DEVICE = unchecked((int)0xC0000013),
        STATUS_UNRECOGNIZED_MEDIA = unchecked((int)0xC0000014),
        STATUS_NONEXISTENT_SECTOR = unchecked((int)0xC0000015),
        STATUS_MORE_PROCESSING_REQUIRED = unchecked((int)0xC0000016),
        STATUS_NO_MEMORY = unchecked((int)0xC0000017),
        STATUS_CONFLICTING_ADDRESSES = unchecked((int)0xC0000018),
        STATUS_NOT_MAPPED_VIEW = unchecked((int)0xC0000019),
        STATUS_UNABLE_TO_FREE_VM = unchecked((int)0xC000001A),
        STATUS_UNABLE_TO_DELETE_SECTION = unchecked((int)0xC000001B),
        STATUS_INVALID_SYSTEM_SERVICE = unchecked((int)0xC000001C),
        STATUS_ILLEGAL_INSTRUCTION = unchecked((int)0xC000001D),
        STATUS_INVALID_LOCK_SEQUENCE = unchecked((int)0xC000001E),
        STATUS_INVALID_VIEW_SIZE = unchecked((int)0xC000001F),
        STATUS_INVALID_FILE_FOR_SECTION = unchecked((int)0xC0000020),
        STATUS_ALREADY_COMMITTED = unchecked((int)0xC0000021),
        STATUS_ACCESS_DENIED = unchecked((int)0xC0000022),
        STATUS_BUFFER_TOO_SMALL = unchecked((int)0xC0000023),
        STATUS_OBJECT_TYPE_MISMATCH = unchecked((int)0xC0000024),
        STATUS_NONCONTINUABLE_EXCEPTION = unchecked((int)0xC0000025),
        STATUS_INVALID_DISPOSITION = unchecked((int)0xC0000026),
        STATUS_UNWIND = unchecked((int)0xC0000027),
        STATUS_BAD_STACK = unchecked((int)0xC0000028),
        STATUS_INVALID_UNWIND_TARGET = unchecked((int)0xC0000029),
        STATUS_NOT_LOCKED = unchecked((int)0xC000002A),
        STATUS_PARITY_ERROR = unchecked((int)0xC000002B),
        STATUS_UNABLE_TO_DECOMMIT_VM = unchecked((int)0xC000002C),
        STATUS_NOT_COMMITTED = unchecked((int)0xC000002D),
        STATUS_INVALID_PORT_ATTRIBUTES = unchecked((int)0xC000002E),
        STATUS_PORT_MESSAGE_TOO_LONG = unchecked((int)0xC000002F),
        STATUS_INVALID_PARAMETER_MIX = unchecked((int)0xC0000030),
        STATUS_INVALID_QUOTA_LOWER = unchecked((int)0xC0000031),
        STATUS_DISK_CORRUPT_ERROR = unchecked((int)0xC0000032),
        STATUS_OBJECT_NAME_INVALID = unchecked((int)0xC0000033),
        STATUS_OBJECT_NAME_NOT_FOUND = unchecked((int)0xC0000034),
        STATUS_OBJECT_NAME_COLLISION = unchecked((int)0xC0000035),
        STATUS_PORT_DO_NOT_DISTURB = unchecked((int)0xC0000036),
        STATUS_PORT_DISCONNECTED = unchecked((int)0xC0000037),
        STATUS_DEVICE_ALREADY_ATTACHED = unchecked((int)0xC0000038),
        STATUS_OBJECT_PATH_INVALID = unchecked((int)0xC0000039),
        STATUS_OBJECT_PATH_NOT_FOUND = unchecked((int)0xC000003A),
        STATUS_OBJECT_PATH_SYNTAX_BAD = unchecked((int)0xC000003B),
        STATUS_DATA_OVERRUN = unchecked((int)0xC000003C),
        STATUS_DATA_LATE_ERROR = unchecked((int)0xC000003D),
        STATUS_DATA_ERROR = unchecked((int)0xC000003E),
        STATUS_CRC_ERROR = unchecked((int)0xC000003F),
        STATUS_SECTION_TOO_BIG = unchecked((int)0xC0000040),
        STATUS_PORT_CONNECTION_REFUSED = unchecked((int)0xC0000041),
        STATUS_INVALID_PORT_HANDLE = unchecked((int)0xC0000042),
        STATUS_SHARING_VIOLATION = unchecked((int)0xC0000043),
        STATUS_QUOTA_EXCEEDED = unchecked((int)0xC0000044),
        STATUS_INVALID_PAGE_PROTECTION = unchecked((int)0xC0000045),
        STATUS_MUTANT_NOT_OWNED = unchecked((int)0xC0000046),
        STATUS_SEMAPHORE_LIMIT_EXCEEDED = unchecked((int)0xC0000047),
        STATUS_PORT_ALREADY_SET = unchecked((int)0xC0000048),
        STATUS_SECTION_NOT_IMAGE = unchecked((int)0xC0000049),
        STATUS_SUSPEND_COUNT_EXCEEDED = unchecked((int)0xC000004A),
        STATUS_THREAD_IS_TERMINATING = unchecked((int)0xC000004B),
        STATUS_BAD_WORKING_SET_LIMIT = unchecked((int)0xC000004C),
        STATUS_INCOMPATIBLE_FILE_MAP = unchecked((int)0xC000004D),
        STATUS_SECTION_PROTECTION = unchecked((int)0xC000004E),
        STATUS_EAS_NOT_SUPPORTED = unchecked((int)0xC000004F),
        STATUS_EA_TOO_LARGE = unchecked((int)0xC0000050),
        STATUS_NONEXISTENT_EA_ENTRY = unchecked((int)0xC0000051),
        STATUS_NO_EAS_ON_FILE = unchecked((int)0xC0000052),
        STATUS_EA_CORRUPT_ERROR = unchecked((int)0xC0000053),
        STATUS_FILE_LOCK_CONFLICT = unchecked((int)0xC0000054),
        STATUS_LOCK_NOT_GRANTED = unchecked((int)0xC0000055),
        STATUS_DELETE_PENDING = unchecked((int)0xC0000056),
        STATUS_CTL_FILE_NOT_SUPPORTED = unchecked((int)0xC0000057),
        STATUS_UNKNOWN_REVISION = unchecked((int)0xC0000058),
        STATUS_REVISION_MISMATCH = unchecked((int)0xC0000059),
        STATUS_INVALID_OWNER = unchecked((int)0xC000005A),
        STATUS_INVALID_PRIMARY_GROUP = unchecked((int)0xC000005B),
        STATUS_NO_IMPERSONATION_TOKEN = unchecked((int)0xC000005C),
        STATUS_CANT_DISABLE_MANDATORY = unchecked((int)0xC000005D),
        STATUS_NO_LOGON_SERVERS = unchecked((int)0xC000005E),
        STATUS_NO_SUCH_LOGON_SESSION = unchecked((int)0xC000005F),
        STATUS_NO_SUCH_PRIVILEGE = unchecked((int)0xC0000060),
        STATUS_PRIVILEGE_NOT_HELD = unchecked((int)0xC0000061),
        STATUS_INVALID_ACCOUNT_NAME = unchecked((int)0xC0000062),
        STATUS_USER_EXISTS = unchecked((int)0xC0000063),
        STATUS_NO_SUCH_USER = unchecked((int)0xC0000064),
        STATUS_GROUP_EXISTS = unchecked((int)0xC0000065),
        STATUS_NO_SUCH_GROUP = unchecked((int)0xC0000066),
        STATUS_MEMBER_IN_GROUP = unchecked((int)0xC0000067),
        STATUS_MEMBER_NOT_IN_GROUP = unchecked((int)0xC0000068),
        STATUS_LAST_ADMIN = unchecked((int)0xC0000069),
        STATUS_WRONG_PASSWORD = unchecked((int)0xC000006A),
        STATUS_ILL_FORMED_PASSWORD = unchecked((int)0xC000006B),
        STATUS_PASSWORD_RESTRICTION = unchecked((int)0xC000006C),
        STATUS_LOGON_FAILURE = unchecked((int)0xC000006D),
        STATUS_ACCOUNT_RESTRICTION = unchecked((int)0xC000006E),
        STATUS_INVALID_LOGON_HOURS = unchecked((int)0xC000006F),
        STATUS_INVALID_WORKSTATION = unchecked((int)0xC0000070),
        STATUS_PASSWORD_EXPIRED = unchecked((int)0xC0000071),
        STATUS_ACCOUNT_DISABLED = unchecked((int)0xC0000072),
        STATUS_NONE_MAPPED = unchecked((int)0xC0000073),
        STATUS_TOO_MANY_LUIDS_REQUESTED = unchecked((int)0xC0000074),
        STATUS_LUIDS_EXHAUSTED = unchecked((int)0xC0000075),
        STATUS_INVALID_SUB_AUTHORITY = unchecked((int)0xC0000076),
        STATUS_INVALID_ACL = unchecked((int)0xC0000077),
        STATUS_INVALID_SID = unchecked((int)0xC0000078),
        STATUS_INVALID_SECURITY_DESCR = unchecked((int)0xC0000079),
        STATUS_PROCEDURE_NOT_FOUND = unchecked((int)0xC000007A),
        STATUS_INVALID_IMAGE_FORMAT = unchecked((int)0xC000007B),
        STATUS_NO_TOKEN = unchecked((int)0xC000007C),
        STATUS_BAD_INHERITANCE_ACL = unchecked((int)0xC000007D),
        STATUS_RANGE_NOT_LOCKED = unchecked((int)0xC000007E),
        STATUS_DISK_FULL = unchecked((int)0xC000007F),
        STATUS_SERVER_DISABLED = unchecked((int)0xC0000080),
        STATUS_SERVER_NOT_DISABLED = unchecked((int)0xC0000081),
        STATUS_TOO_MANY_GUIDS_REQUESTED = unchecked((int)0xC0000082),
        STATUS_GUIDS_EXHAUSTED = unchecked((int)0xC0000083),
        STATUS_INVALID_ID_AUTHORITY = unchecked((int)0xC0000084),
        STATUS_AGENTS_EXHAUSTED = unchecked((int)0xC0000085),
        STATUS_INVALID_VOLUME_LABEL = unchecked((int)0xC0000086),
        STATUS_SECTION_NOT_EXTENDED = unchecked((int)0xC0000087),
        STATUS_NOT_MAPPED_DATA = unchecked((int)0xC0000088),
        STATUS_RESOURCE_DATA_NOT_FOUND = unchecked((int)0xC0000089),
        STATUS_RESOURCE_TYPE_NOT_FOUND = unchecked((int)0xC000008A),
        STATUS_RESOURCE_NAME_NOT_FOUND = unchecked((int)0xC000008B),
        STATUS_ARRAY_BOUNDS_EXCEEDED = unchecked((int)0xC000008C),
        STATUS_FLOAT_DENORMAL_OPERAND = unchecked((int)0xC000008D),
        STATUS_FLOAT_DIVIDE_BY_ZERO = unchecked((int)0xC000008E),
        STATUS_FLOAT_INEXACT_RESULT = unchecked((int)0xC000008F),
        STATUS_FLOAT_INVALID_OPERATION = unchecked((int)0xC0000090),
        STATUS_FLOAT_OVERFLOW = unchecked((int)0xC0000091),
        STATUS_FLOAT_STACK_CHECK = unchecked((int)0xC0000092),
        STATUS_FLOAT_UNDERFLOW = unchecked((int)0xC0000093),
        STATUS_INTEGER_DIVIDE_BY_ZERO = unchecked((int)0xC0000094),
        STATUS_INTEGER_OVERFLOW = unchecked((int)0xC0000095),
        STATUS_PRIVILEGED_INSTRUCTION = unchecked((int)0xC0000096),
        STATUS_TOO_MANY_PAGING_FILES = unchecked((int)0xC0000097),
        STATUS_FILE_INVALID = unchecked((int)0xC0000098),
        STATUS_ALLOTTED_SPACE_EXCEEDED = unchecked((int)0xC0000099),
        STATUS_INSUFFICIENT_RESOURCES = unchecked((int)0xC000009A),
        STATUS_DFS_EXIT_PATH_FOUND = unchecked((int)0xC000009B),
        STATUS_DEVICE_DATA_ERROR = unchecked((int)0xC000009C),
        STATUS_DEVICE_NOT_CONNECTED = unchecked((int)0xC000009D),
        STATUS_DEVICE_POWER_FAILURE = unchecked((int)0xC000009E),
        STATUS_FREE_VM_NOT_AT_BASE = unchecked((int)0xC000009F),
        STATUS_MEMORY_NOT_ALLOCATED = unchecked((int)0xC00000A0),
        STATUS_WORKING_SET_QUOTA = unchecked((int)0xC00000A1),
        STATUS_MEDIA_WRITE_PROTECTED = unchecked((int)0xC00000A2),
        STATUS_DEVICE_NOT_READY = unchecked((int)0xC00000A3),
        STATUS_INVALID_GROUP_ATTRIBUTES = unchecked((int)0xC00000A4),
        STATUS_BAD_IMPERSONATION_LEVEL = unchecked((int)0xC00000A5),
        STATUS_CANT_OPEN_ANONYMOUS = unchecked((int)0xC00000A6),
        STATUS_BAD_VALIDATION_CLASS = unchecked((int)0xC00000A7),
        STATUS_BAD_TOKEN_TYPE = unchecked((int)0xC00000A8),
        STATUS_BAD_MASTER_BOOT_RECORD = unchecked((int)0xC00000A9),
        STATUS_INSTRUCTION_MISALIGNMENT = unchecked((int)0xC00000AA),
        STATUS_INSTANCE_NOT_AVAILABLE = unchecked((int)0xC00000AB),
        STATUS_PIPE_NOT_AVAILABLE = unchecked((int)0xC00000AC),
        STATUS_INVALID_PIPE_STATE = unchecked((int)0xC00000AD),
        STATUS_PIPE_BUSY = unchecked((int)0xC00000AE),
        STATUS_ILLEGAL_FUNCTION = unchecked((int)0xC00000AF),
        STATUS_PIPE_DISCONNECTED = unchecked((int)0xC00000B0),
        STATUS_PIPE_CLOSING = unchecked((int)0xC00000B1),
        STATUS_PIPE_CONNECTED = unchecked((int)0xC00000B2),
        STATUS_PIPE_LISTENING = unchecked((int)0xC00000B3),
        STATUS_INVALID_READ_MODE = unchecked((int)0xC00000B4),
        STATUS_IO_TIMEOUT = unchecked((int)0xC00000B5),
        STATUS_FILE_FORCED_CLOSED = unchecked((int)0xC00000B6),
        STATUS_PROFILING_NOT_STARTED = unchecked((int)0xC00000B7),
        STATUS_PROFILING_NOT_STOPPED = unchecked((int)0xC00000B8),
        STATUS_COULD_NOT_INTERPRET = unchecked((int)0xC00000B9),
        STATUS_FILE_IS_A_DIRECTORY = unchecked((int)0xC00000BA),
        STATUS_NOT_SUPPORTED = unchecked((int)0xC00000BB),
        STATUS_REMOTE_NOT_LISTENING = unchecked((int)0xC00000BC),
        STATUS_DUPLICATE_NAME = unchecked((int)0xC00000BD),
        STATUS_BAD_NETWORK_PATH = unchecked((int)0xC00000BE),
        STATUS_NETWORK_BUSY = unchecked((int)0xC00000BF),
        STATUS_DEVICE_DOES_NOT_EXIST = unchecked((int)0xC00000C0),
        STATUS_TOO_MANY_COMMANDS = unchecked((int)0xC00000C1),
        STATUS_ADAPTER_HARDWARE_ERROR = unchecked((int)0xC00000C2),
        STATUS_INVALID_NETWORK_RESPONSE = unchecked((int)0xC00000C3),
        STATUS_UNEXPECTED_NETWORK_ERROR = unchecked((int)0xC00000C4),
        STATUS_BAD_REMOTE_ADAPTER = unchecked((int)0xC00000C5),
        STATUS_PRINT_QUEUE_FULL = unchecked((int)0xC00000C6),
        STATUS_NO_SPOOL_SPACE = unchecked((int)0xC00000C7),
        STATUS_PRINT_CANCELLED = unchecked((int)0xC00000C8),
        STATUS_NETWORK_NAME_DELETED = unchecked((int)0xC00000C9),
        STATUS_NETWORK_ACCESS_DENIED = unchecked((int)0xC00000CA),
        STATUS_BAD_DEVICE_TYPE = unchecked((int)0xC00000CB),
        STATUS_BAD_NETWORK_NAME = unchecked((int)0xC00000CC),
        STATUS_TOO_MANY_NAMES = unchecked((int)0xC00000CD),
        STATUS_TOO_MANY_SESSIONS = unchecked((int)0xC00000CE),
        STATUS_SHARING_PAUSED = unchecked((int)0xC00000CF),
        STATUS_REQUEST_NOT_ACCEPTED = unchecked((int)0xC00000D0),
        STATUS_REDIRECTOR_PAUSED = unchecked((int)0xC00000D1),
        STATUS_NET_WRITE_FAULT = unchecked((int)0xC00000D2),
        STATUS_PROFILING_AT_LIMIT = unchecked((int)0xC00000D3),
        STATUS_NOT_SAME_DEVICE = unchecked((int)0xC00000D4),
        STATUS_FILE_RENAMED = unchecked((int)0xC00000D5),
        STATUS_VIRTUAL_CIRCUIT_CLOSED = unchecked((int)0xC00000D6),
        STATUS_NO_SECURITY_ON_OBJECT = unchecked((int)0xC00000D7),
        STATUS_CANT_WAIT = unchecked((int)0xC00000D8),
        STATUS_PIPE_EMPTY = unchecked((int)0xC00000D9),
        STATUS_CANT_ACCESS_DOMAIN_INFO = unchecked((int)0xC00000DA),
        STATUS_CANT_TERMINATE_SELF = unchecked((int)0xC00000DB),
        STATUS_INVALID_SERVER_STATE = unchecked((int)0xC00000DC),
        STATUS_INVALID_DOMAIN_STATE = unchecked((int)0xC00000DD),
        STATUS_INVALID_DOMAIN_ROLE = unchecked((int)0xC00000DE),
        STATUS_NO_SUCH_DOMAIN = unchecked((int)0xC00000DF),
        STATUS_DOMAIN_EXISTS = unchecked((int)0xC00000E0),
        STATUS_DOMAIN_LIMIT_EXCEEDED = unchecked((int)0xC00000E1),
        STATUS_OPLOCK_NOT_GRANTED = unchecked((int)0xC00000E2),
        STATUS_INVALID_OPLOCK_PROTOCOL = unchecked((int)0xC00000E3),
        STATUS_INTERNAL_DB_CORRUPTION = unchecked((int)0xC00000E4),
        STATUS_INTERNAL_ERROR = unchecked((int)0xC00000E5),
        STATUS_GENERIC_NOT_MAPPED = unchecked((int)0xC00000E6),
        STATUS_BAD_DESCRIPTOR_FORMAT = unchecked((int)0xC00000E7),
        STATUS_INVALID_USER_BUFFER = unchecked((int)0xC00000E8),
        STATUS_UNEXPECTED_IO_ERROR = unchecked((int)0xC00000E9),
        STATUS_UNEXPECTED_MM_CREATE_ERR = unchecked((int)0xC00000EA),
        STATUS_UNEXPECTED_MM_MAP_ERROR = unchecked((int)0xC00000EB),
        STATUS_UNEXPECTED_MM_EXTEND_ERR = unchecked((int)0xC00000EC),
        STATUS_NOT_LOGON_PROCESS = unchecked((int)0xC00000ED),
        STATUS_LOGON_SESSION_EXISTS = unchecked((int)0xC00000EE),
        STATUS_INVALID_PARAMETER_1 = unchecked((int)0xC00000EF),
        STATUS_INVALID_PARAMETER_2 = unchecked((int)0xC00000F0),
        STATUS_INVALID_PARAMETER_3 = unchecked((int)0xC00000F1),
        STATUS_INVALID_PARAMETER_4 = unchecked((int)0xC00000F2),
        STATUS_INVALID_PARAMETER_5 = unchecked((int)0xC00000F3),
        STATUS_INVALID_PARAMETER_6 = unchecked((int)0xC00000F4),
        STATUS_INVALID_PARAMETER_7 = unchecked((int)0xC00000F5),
        STATUS_INVALID_PARAMETER_8 = unchecked((int)0xC00000F6),
        STATUS_INVALID_PARAMETER_9 = unchecked((int)0xC00000F7),
        STATUS_INVALID_PARAMETER_10 = unchecked((int)0xC00000F8),
        STATUS_INVALID_PARAMETER_11 = unchecked((int)0xC00000F9),
        STATUS_INVALID_PARAMETER_12 = unchecked((int)0xC00000FA),
        STATUS_REDIRECTOR_NOT_STARTED = unchecked((int)0xC00000FB),
        STATUS_REDIRECTOR_STARTED = unchecked((int)0xC00000FC),
        STATUS_STACK_OVERFLOW = unchecked((int)0xC00000FD),
        STATUS_NO_SUCH_PACKAGE = unchecked((int)0xC00000FE),
        STATUS_BAD_FUNCTION_TABLE = unchecked((int)0xC00000FF),
        STATUS_VARIABLE_NOT_FOUND = unchecked((int)0xC0000100),
        STATUS_DIRECTORY_NOT_EMPTY = unchecked((int)0xC0000101),
        STATUS_FILE_CORRUPT_ERROR = unchecked((int)0xC0000102),
        STATUS_NOT_A_DIRECTORY = unchecked((int)0xC0000103),
        STATUS_BAD_LOGON_SESSION_STATE = unchecked((int)0xC0000104),
        STATUS_LOGON_SESSION_COLLISION = unchecked((int)0xC0000105),
        STATUS_NAME_TOO_LONG = unchecked((int)0xC0000106),
        STATUS_FILES_OPEN = unchecked((int)0xC0000107),
        STATUS_CONNECTION_IN_USE = unchecked((int)0xC0000108),
        STATUS_MESSAGE_NOT_FOUND = unchecked((int)0xC0000109),
        STATUS_PROCESS_IS_TERMINATING = unchecked((int)0xC000010A),
        STATUS_INVALID_LOGON_TYPE = unchecked((int)0xC000010B),
        STATUS_NO_GUID_TRANSLATION = unchecked((int)0xC000010C),
        STATUS_CANNOT_IMPERSONATE = unchecked((int)0xC000010D),
        STATUS_IMAGE_ALREADY_LOADED = unchecked((int)0xC000010E),
        STATUS_ABIOS_NOT_PRESENT = unchecked((int)0xC000010F),
        STATUS_ABIOS_LID_NOT_EXIST = unchecked((int)0xC0000110),
        STATUS_ABIOS_LID_ALREADY_OWNED = unchecked((int)0xC0000111),
        STATUS_ABIOS_NOT_LID_OWNER = unchecked((int)0xC0000112),
        STATUS_ABIOS_INVALID_COMMAND = unchecked((int)0xC0000113),
        STATUS_ABIOS_INVALID_LID = unchecked((int)0xC0000114),
        STATUS_ABIOS_SELECTOR_NOT_AVAILABLE = unchecked((int)0xC0000115),
        STATUS_ABIOS_INVALID_SELECTOR = unchecked((int)0xC0000116),
        STATUS_NO_LDT = unchecked((int)0xC0000117),
        STATUS_INVALID_LDT_SIZE = unchecked((int)0xC0000118),
        STATUS_INVALID_LDT_OFFSET = unchecked((int)0xC0000119),
        STATUS_INVALID_LDT_DESCRIPTOR = unchecked((int)0xC000011A),
        STATUS_INVALID_IMAGE_NE_FORMAT = unchecked((int)0xC000011B),
        STATUS_RXACT_INVALID_STATE = unchecked((int)0xC000011C),
        STATUS_RXACT_COMMIT_FAILURE = unchecked((int)0xC000011D),
        STATUS_MAPPED_FILE_SIZE_ZERO = unchecked((int)0xC000011E),
        STATUS_TOO_MANY_OPENED_FILES = unchecked((int)0xC000011F),
        STATUS_CANCELLED = unchecked((int)0xC0000120),
        STATUS_CANNOT_DELETE = unchecked((int)0xC0000121),
        STATUS_INVALID_COMPUTER_NAME = unchecked((int)0xC0000122),
        STATUS_FILE_DELETED = unchecked((int)0xC0000123),
        STATUS_SPECIAL_ACCOUNT = unchecked((int)0xC0000124),
        STATUS_SPECIAL_GROUP = unchecked((int)0xC0000125),
        STATUS_SPECIAL_USER = unchecked((int)0xC0000126),
        STATUS_MEMBERS_PRIMARY_GROUP = unchecked((int)0xC0000127),
        STATUS_FILE_CLOSED = unchecked((int)0xC0000128),
        STATUS_TOO_MANY_THREADS = unchecked((int)0xC0000129),
        STATUS_THREAD_NOT_IN_PROCESS = unchecked((int)0xC000012A),
        STATUS_TOKEN_ALREADY_IN_USE = unchecked((int)0xC000012B),
        STATUS_PAGEFILE_QUOTA_EXCEEDED = unchecked((int)0xC000012C),
        STATUS_COMMITMENT_LIMIT = unchecked((int)0xC000012D),
        STATUS_INVALID_IMAGE_LE_FORMAT = unchecked((int)0xC000012E),
        STATUS_INVALID_IMAGE_NOT_MZ = unchecked((int)0xC000012F),
        STATUS_INVALID_IMAGE_PROTECT = unchecked((int)0xC0000130),
        STATUS_INVALID_IMAGE_WIN_16 = unchecked((int)0xC0000131),
        STATUS_LOGON_SERVER_CONFLICT = unchecked((int)0xC0000132),
        STATUS_TIME_DIFFERENCE_AT_DC = unchecked((int)0xC0000133),
        STATUS_SYNCHRONIZATION_REQUIRED = unchecked((int)0xC0000134),
        STATUS_DLL_NOT_FOUND = unchecked((int)0xC0000135),
        STATUS_OPEN_FAILED = unchecked((int)0xC0000136),
        STATUS_IO_PRIVILEGE_FAILED = unchecked((int)0xC0000137),
        STATUS_ORDINAL_NOT_FOUND = unchecked((int)0xC0000138),
        STATUS_ENTRYPOINT_NOT_FOUND = unchecked((int)0xC0000139),
        STATUS_CONTROL_C_EXIT = unchecked((int)0xC000013A),
        STATUS_LOCAL_DISCONNECT = unchecked((int)0xC000013B),
        STATUS_REMOTE_DISCONNECT = unchecked((int)0xC000013C),
        STATUS_REMOTE_RESOURCES = unchecked((int)0xC000013D),
        STATUS_LINK_FAILED = unchecked((int)0xC000013E),
        STATUS_LINK_TIMEOUT = unchecked((int)0xC000013F),
        STATUS_INVALID_CONNECTION = unchecked((int)0xC0000140),
        STATUS_INVALID_ADDRESS = unchecked((int)0xC0000141),
        STATUS_DLL_INIT_FAILED = unchecked((int)0xC0000142),
        STATUS_MISSING_SYSTEMFILE = unchecked((int)0xC0000143),
        STATUS_UNHANDLED_EXCEPTION = unchecked((int)0xC0000144),
        STATUS_APP_INIT_FAILURE = unchecked((int)0xC0000145),
        STATUS_PAGEFILE_CREATE_FAILED = unchecked((int)0xC0000146),
        STATUS_NO_PAGEFILE = unchecked((int)0xC0000147),
        STATUS_INVALID_LEVEL = unchecked((int)0xC0000148),
        STATUS_WRONG_PASSWORD_CORE = unchecked((int)0xC0000149),
        STATUS_ILLEGAL_FLOAT_CONTEXT = unchecked((int)0xC000014A),
        STATUS_PIPE_BROKEN = unchecked((int)0xC000014B),
        STATUS_REGISTRY_CORRUPT = unchecked((int)0xC000014C),
        STATUS_REGISTRY_IO_FAILED = unchecked((int)0xC000014D),
        STATUS_NO_EVENT_PAIR = unchecked((int)0xC000014E),
        STATUS_UNRECOGNIZED_VOLUME = unchecked((int)0xC000014F),
        STATUS_SERIAL_NO_DEVICE_INITED = unchecked((int)0xC0000150),
        STATUS_NO_SUCH_ALIAS = unchecked((int)0xC0000151),
        STATUS_MEMBER_NOT_IN_ALIAS = unchecked((int)0xC0000152),
        STATUS_MEMBER_IN_ALIAS = unchecked((int)0xC0000153),
        STATUS_ALIAS_EXISTS = unchecked((int)0xC0000154),
        STATUS_LOGON_NOT_GRANTED = unchecked((int)0xC0000155),
        STATUS_TOO_MANY_SECRETS = unchecked((int)0xC0000156),
        STATUS_SECRET_TOO_LONG = unchecked((int)0xC0000157),
        STATUS_INTERNAL_DB_ERROR = unchecked((int)0xC0000158),
        STATUS_FULLSCREEN_MODE = unchecked((int)0xC0000159),
        STATUS_TOO_MANY_CONTEXT_IDS = unchecked((int)0xC000015A),
        STATUS_LOGON_TYPE_NOT_GRANTED = unchecked((int)0xC000015B),
        STATUS_NOT_REGISTRY_FILE = unchecked((int)0xC000015C),
        STATUS_NT_CROSS_ENCRYPTION_REQUIRED = unchecked((int)0xC000015D),
        STATUS_DOMAIN_CTRLR_CONFIG_ERROR = unchecked((int)0xC000015E),
        STATUS_FT_MISSING_MEMBER = unchecked((int)0xC000015F),
        STATUS_ILL_FORMED_SERVICE_ENTRY = unchecked((int)0xC0000160),
        STATUS_ILLEGAL_CHARACTER = unchecked((int)0xC0000161),
        STATUS_UNMAPPABLE_CHARACTER = unchecked((int)0xC0000162),
        STATUS_UNDEFINED_CHARACTER = unchecked((int)0xC0000163),
        STATUS_FLOPPY_VOLUME = unchecked((int)0xC0000164),
        STATUS_FLOPPY_ID_MARK_NOT_FOUND = unchecked((int)0xC0000165),
        STATUS_FLOPPY_WRONG_CYLINDER = unchecked((int)0xC0000166),
        STATUS_FLOPPY_UNKNOWN_ERROR = unchecked((int)0xC0000167),
        STATUS_FLOPPY_BAD_REGISTERS = unchecked((int)0xC0000168),
        STATUS_DISK_RECALIBRATE_FAILED = unchecked((int)0xC0000169),
        STATUS_DISK_OPERATION_FAILED = unchecked((int)0xC000016A),
        STATUS_DISK_RESET_FAILED = unchecked((int)0xC000016B),
        STATUS_SHARED_IRQ_BUSY = unchecked((int)0xC000016C),
        STATUS_FT_ORPHANING = unchecked((int)0xC000016D),
        STATUS_BIOS_FAILED_TO_CONNECT_INTERRUPT = unchecked((int)0xC000016E),
        STATUS_PARTITION_FAILURE = unchecked((int)0xC0000172),
        STATUS_INVALID_BLOCK_LENGTH = unchecked((int)0xC0000173),
        STATUS_DEVICE_NOT_PARTITIONED = unchecked((int)0xC0000174),
        STATUS_UNABLE_TO_LOCK_MEDIA = unchecked((int)0xC0000175),
        STATUS_UNABLE_TO_UNLOAD_MEDIA = unchecked((int)0xC0000176),
        STATUS_EOM_OVERFLOW = unchecked((int)0xC0000177),
        STATUS_NO_MEDIA = unchecked((int)0xC0000178),
        STATUS_NO_SUCH_MEMBER = unchecked((int)0xC000017A),
        STATUS_INVALID_MEMBER = unchecked((int)0xC000017B),
        STATUS_KEY_DELETED = unchecked((int)0xC000017C),
        STATUS_NO_LOG_SPACE = unchecked((int)0xC000017D),
        STATUS_TOO_MANY_SIDS = unchecked((int)0xC000017E),
        STATUS_LM_CROSS_ENCRYPTION_REQUIRED = unchecked((int)0xC000017F),
        STATUS_KEY_HAS_CHILDREN = unchecked((int)0xC0000180),
        STATUS_CHILD_MUST_BE_VOLATILE = unchecked((int)0xC0000181),
        STATUS_DEVICE_CONFIGURATION_ERROR = unchecked((int)0xC0000182),
        STATUS_DRIVER_INTERNAL_ERROR = unchecked((int)0xC0000183),
        STATUS_INVALID_DEVICE_STATE = unchecked((int)0xC0000184),
        STATUS_IO_DEVICE_ERROR = unchecked((int)0xC0000185),
        STATUS_DEVICE_PROTOCOL_ERROR = unchecked((int)0xC0000186),
        STATUS_BACKUP_CONTROLLER = unchecked((int)0xC0000187),
        STATUS_LOG_FILE_FULL = unchecked((int)0xC0000188),
        STATUS_TOO_LATE = unchecked((int)0xC0000189),
        STATUS_NO_TRUST_LSA_SECRET = unchecked((int)0xC000018A),
        STATUS_NO_TRUST_SAM_ACCOUNT = unchecked((int)0xC000018B),
        STATUS_TRUSTED_DOMAIN_FAILURE = unchecked((int)0xC000018C),
        STATUS_TRUSTED_RELATIONSHIP_FAILURE = unchecked((int)0xC000018D),
        STATUS_EVENTLOG_FILE_CORRUPT = unchecked((int)0xC000018E),
        STATUS_EVENTLOG_CANT_START = unchecked((int)0xC000018F),
        STATUS_TRUST_FAILURE = unchecked((int)0xC0000190),
        STATUS_MUTANT_LIMIT_EXCEEDED = unchecked((int)0xC0000191),
        STATUS_NETLOGON_NOT_STARTED = unchecked((int)0xC0000192),
        STATUS_ACCOUNT_EXPIRED = unchecked((int)0xC0000193),
        STATUS_POSSIBLE_DEADLOCK = unchecked((int)0xC0000194),
        STATUS_NETWORK_CREDENTIAL_CONFLICT = unchecked((int)0xC0000195),
        STATUS_REMOTE_SESSION_LIMIT = unchecked((int)0xC0000196),
        STATUS_EVENTLOG_FILE_CHANGED = unchecked((int)0xC0000197),
        STATUS_NOLOGON_INTERDOMAIN_TRUST_ACCOUNT = unchecked((int)0xC0000198),
        STATUS_NOLOGON_WORKSTATION_TRUST_ACCOUNT = unchecked((int)0xC0000199),
        STATUS_NOLOGON_SERVER_TRUST_ACCOUNT = unchecked((int)0xC000019A),
        STATUS_DOMAIN_TRUST_INCONSISTENT = unchecked((int)0xC000019B),
        STATUS_FS_DRIVER_REQUIRED = unchecked((int)0xC000019C),
        STATUS_IMAGE_ALREADY_LOADED_AS_DLL = unchecked((int)0xC000019D),
        STATUS_INCOMPATIBLE_WITH_GLOBAL_SHORT_NAME_REGISTRY_SETTING = unchecked((int)0xC000019E),
        STATUS_SHORT_NAMES_NOT_ENABLED_ON_VOLUME = unchecked((int)0xC000019F),
        STATUS_SECURITY_STREAM_IS_INCONSISTENT = unchecked((int)0xC00001A0),
        STATUS_INVALID_LOCK_RANGE = unchecked((int)0xC00001A1),
        STATUS_INVALID_ACE_CONDITION = unchecked((int)0xC00001A2),
        STATUS_IMAGE_SUBSYSTEM_NOT_PRESENT = unchecked((int)0xC00001A3),
        STATUS_NOTIFICATION_GUID_ALREADY_DEFINED = unchecked((int)0xC00001A4),
        STATUS_INVALID_EXCEPTION_HANDLER = unchecked((int)0xC00001A5),
        STATUS_DUPLICATE_PRIVILEGES = unchecked((int)0xC00001A6),
        STATUS_NOT_ALLOWED_ON_SYSTEM_FILE = unchecked((int)0xC00001A7),
        STATUS_REPAIR_NEEDED = unchecked((int)0xC00001A8),
        STATUS_QUOTA_NOT_ENABLED = unchecked((int)0xC00001A9),
        STATUS_NO_APPLICATION_PACKAGE = unchecked((int)0xC00001AA),
        STATUS_FILE_METADATA_OPTIMIZATION_IN_PROGRESS = unchecked((int)0xC00001AB),
        STATUS_NOT_SAME_OBJECT = unchecked((int)0xC00001AC),
        STATUS_FATAL_MEMORY_EXHAUSTION = unchecked((int)0xC00001AD),
        STATUS_ERROR_PROCESS_NOT_IN_JOB = unchecked((int)0xC00001AE),
        STATUS_CPU_SET_INVALID = unchecked((int)0xC00001AF),
        STATUS_IO_DEVICE_INVALID_DATA = unchecked((int)0xC00001B0),
        STATUS_IO_UNALIGNED_WRITE = unchecked((int)0xC00001B1),
        STATUS_CONTROL_STACK_VIOLATION = unchecked((int)0xC00001B2),
        STATUS_WEAK_WHFBKEY_BLOCKED = unchecked((int)0xC00001B3),
        STATUS_SERVER_TRANSPORT_CONFLICT = unchecked((int)0xC00001B4),
        STATUS_CERTIFICATE_VALIDATION_PREFERENCE_CONFLICT = unchecked((int)0xC00001B5),
        STATUS_DEVICE_RESET_REQUIRED = unchecked((int)0x800001B6),
        STATUS_NETWORK_OPEN_RESTRICTION = unchecked((int)0xC0000201),
        STATUS_NO_USER_SESSION_KEY = unchecked((int)0xC0000202),
        STATUS_USER_SESSION_DELETED = unchecked((int)0xC0000203),
        STATUS_RESOURCE_LANG_NOT_FOUND = unchecked((int)0xC0000204),
        STATUS_INSUFF_SERVER_RESOURCES = unchecked((int)0xC0000205),
        STATUS_INVALID_BUFFER_SIZE = unchecked((int)0xC0000206),
        STATUS_INVALID_ADDRESS_COMPONENT = unchecked((int)0xC0000207),
        STATUS_INVALID_ADDRESS_WILDCARD = unchecked((int)0xC0000208),
        STATUS_TOO_MANY_ADDRESSES = unchecked((int)0xC0000209),
        STATUS_ADDRESS_ALREADY_EXISTS = unchecked((int)0xC000020A),
        STATUS_ADDRESS_CLOSED = unchecked((int)0xC000020B),
        STATUS_CONNECTION_DISCONNECTED = unchecked((int)0xC000020C),
        STATUS_CONNECTION_RESET = unchecked((int)0xC000020D),
        STATUS_TOO_MANY_NODES = unchecked((int)0xC000020E),
        STATUS_TRANSACTION_ABORTED = unchecked((int)0xC000020F),
        STATUS_TRANSACTION_TIMED_OUT = unchecked((int)0xC0000210),
        STATUS_TRANSACTION_NO_RELEASE = unchecked((int)0xC0000211),
        STATUS_TRANSACTION_NO_MATCH = unchecked((int)0xC0000212),
        STATUS_TRANSACTION_RESPONDED = unchecked((int)0xC0000213),
        STATUS_TRANSACTION_INVALID_ID = unchecked((int)0xC0000214),
        STATUS_TRANSACTION_INVALID_TYPE = unchecked((int)0xC0000215),
        STATUS_NOT_SERVER_SESSION = unchecked((int)0xC0000216),
        STATUS_NOT_CLIENT_SESSION = unchecked((int)0xC0000217),
        STATUS_CANNOT_LOAD_REGISTRY_FILE = unchecked((int)0xC0000218),
        STATUS_DEBUG_ATTACH_FAILED = unchecked((int)0xC0000219),
        STATUS_SYSTEM_PROCESS_TERMINATED = unchecked((int)0xC000021A),
        STATUS_DATA_NOT_ACCEPTED = unchecked((int)0xC000021B),
        STATUS_NO_BROWSER_SERVERS_FOUND = unchecked((int)0xC000021C),
        STATUS_VDM_HARD_ERROR = unchecked((int)0xC000021D),
        STATUS_DRIVER_CANCEL_TIMEOUT = unchecked((int)0xC000021E),
        STATUS_REPLY_MESSAGE_MISMATCH = unchecked((int)0xC000021F),
        STATUS_MAPPED_ALIGNMENT = unchecked((int)0xC0000220),
        STATUS_IMAGE_CHECKSUM_MISMATCH = unchecked((int)0xC0000221),
        STATUS_LOST_WRITEBEHIND_DATA = unchecked((int)0xC0000222),
        STATUS_CLIENT_SERVER_PARAMETERS_INVALID = unchecked((int)0xC0000223),
        STATUS_PASSWORD_MUST_CHANGE = unchecked((int)0xC0000224),
        STATUS_NOT_FOUND = unchecked((int)0xC0000225),
        STATUS_NOT_TINY_STREAM = unchecked((int)0xC0000226),
        STATUS_RECOVERY_FAILURE = unchecked((int)0xC0000227),
        STATUS_STACK_OVERFLOW_READ = unchecked((int)0xC0000228),
        STATUS_FAIL_CHECK = unchecked((int)0xC0000229),
        STATUS_DUPLICATE_OBJECTID = unchecked((int)0xC000022A),
        STATUS_OBJECTID_EXISTS = unchecked((int)0xC000022B),
        STATUS_CONVERT_TO_LARGE = unchecked((int)0xC000022C),
        STATUS_RETRY = unchecked((int)0xC000022D),
        STATUS_FOUND_OUT_OF_SCOPE = unchecked((int)0xC000022E),
        STATUS_ALLOCATE_BUCKET = unchecked((int)0xC000022F),
        STATUS_PROPSET_NOT_FOUND = unchecked((int)0xC0000230),
        STATUS_MARSHALL_OVERFLOW = unchecked((int)0xC0000231),
        STATUS_INVALID_VARIANT = unchecked((int)0xC0000232),
        STATUS_DOMAIN_CONTROLLER_NOT_FOUND = unchecked((int)0xC0000233),
        STATUS_ACCOUNT_LOCKED_OUT = unchecked((int)0xC0000234),
        STATUS_HANDLE_NOT_CLOSABLE = unchecked((int)0xC0000235),
        STATUS_CONNECTION_REFUSED = unchecked((int)0xC0000236),
        STATUS_GRACEFUL_DISCONNECT = unchecked((int)0xC0000237),
        STATUS_ADDRESS_ALREADY_ASSOCIATED = unchecked((int)0xC0000238),
        STATUS_ADDRESS_NOT_ASSOCIATED = unchecked((int)0xC0000239),
        STATUS_CONNECTION_INVALID = unchecked((int)0xC000023A),
        STATUS_CONNECTION_ACTIVE = unchecked((int)0xC000023B),
        STATUS_NETWORK_UNREACHABLE = unchecked((int)0xC000023C),
        STATUS_HOST_UNREACHABLE = unchecked((int)0xC000023D),
        STATUS_PROTOCOL_UNREACHABLE = unchecked((int)0xC000023E),
        STATUS_PORT_UNREACHABLE = unchecked((int)0xC000023F),
        STATUS_REQUEST_ABORTED = unchecked((int)0xC0000240),
        STATUS_CONNECTION_ABORTED = unchecked((int)0xC0000241),
        STATUS_BAD_COMPRESSION_BUFFER = unchecked((int)0xC0000242),
        STATUS_USER_MAPPED_FILE = unchecked((int)0xC0000243),
        STATUS_AUDIT_FAILED = unchecked((int)0xC0000244),
        STATUS_TIMER_RESOLUTION_NOT_SET = unchecked((int)0xC0000245),
        STATUS_CONNECTION_COUNT_LIMIT = unchecked((int)0xC0000246),
        STATUS_LOGIN_TIME_RESTRICTION = unchecked((int)0xC0000247),
        STATUS_LOGIN_WKSTA_RESTRICTION = unchecked((int)0xC0000248),
        STATUS_IMAGE_MP_UP_MISMATCH = unchecked((int)0xC0000249),
        STATUS_INSUFFICIENT_LOGON_INFO = unchecked((int)0xC0000250),
        STATUS_BAD_DLL_ENTRYPOINT = unchecked((int)0xC0000251),
        STATUS_BAD_SERVICE_ENTRYPOINT = unchecked((int)0xC0000252),
        STATUS_LPC_REPLY_LOST = unchecked((int)0xC0000253),
        STATUS_IP_ADDRESS_CONFLICT1 = unchecked((int)0xC0000254),
        STATUS_IP_ADDRESS_CONFLICT2 = unchecked((int)0xC0000255),
        STATUS_REGISTRY_QUOTA_LIMIT = unchecked((int)0xC0000256),
        STATUS_PATH_NOT_COVERED = unchecked((int)0xC0000257),
        STATUS_NO_CALLBACK_ACTIVE = unchecked((int)0xC0000258),
        STATUS_LICENSE_QUOTA_EXCEEDED = unchecked((int)0xC0000259),
        STATUS_PWD_TOO_SHORT = unchecked((int)0xC000025A),
        STATUS_PWD_TOO_RECENT = unchecked((int)0xC000025B),
        STATUS_PWD_HISTORY_CONFLICT = unchecked((int)0xC000025C),
        STATUS_PLUGPLAY_NO_DEVICE = unchecked((int)0xC000025E),
        STATUS_UNSUPPORTED_COMPRESSION = unchecked((int)0xC000025F),
        STATUS_INVALID_HW_PROFILE = unchecked((int)0xC0000260),
        STATUS_INVALID_PLUGPLAY_DEVICE_PATH = unchecked((int)0xC0000261),
        STATUS_DRIVER_ORDINAL_NOT_FOUND = unchecked((int)0xC0000262),
        STATUS_DRIVER_ENTRYPOINT_NOT_FOUND = unchecked((int)0xC0000263),
        STATUS_RESOURCE_NOT_OWNED = unchecked((int)0xC0000264),
        STATUS_TOO_MANY_LINKS = unchecked((int)0xC0000265),
        STATUS_QUOTA_LIST_INCONSISTENT = unchecked((int)0xC0000266),
        STATUS_FILE_IS_OFFLINE = unchecked((int)0xC0000267),
        STATUS_EVALUATION_EXPIRATION = unchecked((int)0xC0000268),
        STATUS_ILLEGAL_DLL_RELOCATION = unchecked((int)0xC0000269),
        STATUS_LICENSE_VIOLATION = unchecked((int)0xC000026A),
        STATUS_DLL_INIT_FAILED_LOGOFF = unchecked((int)0xC000026B),
        STATUS_DRIVER_UNABLE_TO_LOAD = unchecked((int)0xC000026C),
        STATUS_DFS_UNAVAILABLE = unchecked((int)0xC000026D),
        STATUS_VOLUME_DISMOUNTED = unchecked((int)0xC000026E),
        STATUS_WX86_INTERNAL_ERROR = unchecked((int)0xC000026F),
        STATUS_WX86_FLOAT_STACK_CHECK = unchecked((int)0xC0000270),
        STATUS_VALIDATE_CONTINUE = unchecked((int)0xC0000271),
        STATUS_NO_MATCH = unchecked((int)0xC0000272),
        STATUS_NO_MORE_MATCHES = unchecked((int)0xC0000273),
        STATUS_NOT_A_REPARSE_POINT = unchecked((int)0xC0000275),
        STATUS_IO_REPARSE_TAG_INVALID = unchecked((int)0xC0000276),
        STATUS_IO_REPARSE_TAG_MISMATCH = unchecked((int)0xC0000277),
        STATUS_IO_REPARSE_DATA_INVALID = unchecked((int)0xC0000278),
        STATUS_IO_REPARSE_TAG_NOT_HANDLED = unchecked((int)0xC0000279),
        STATUS_PWD_TOO_LONG = unchecked((int)0xC000027A),
        STATUS_STOWED_EXCEPTION = unchecked((int)0xC000027B),
        STATUS_CONTEXT_STOWED_EXCEPTION = unchecked((int)0xC000027C),
        STATUS_REPARSE_POINT_NOT_RESOLVED = unchecked((int)0xC0000280),
        STATUS_DIRECTORY_IS_A_REPARSE_POINT = unchecked((int)0xC0000281),
        STATUS_RANGE_LIST_CONFLICT = unchecked((int)0xC0000282),
        STATUS_SOURCE_ELEMENT_EMPTY = unchecked((int)0xC0000283),
        STATUS_DESTINATION_ELEMENT_FULL = unchecked((int)0xC0000284),
        STATUS_ILLEGAL_ELEMENT_ADDRESS = unchecked((int)0xC0000285),
        STATUS_MAGAZINE_NOT_PRESENT = unchecked((int)0xC0000286),
        STATUS_REINITIALIZATION_NEEDED = unchecked((int)0xC0000287),
        STATUS_DEVICE_REQUIRES_CLEANING = unchecked((int)0x80000288),
        STATUS_DEVICE_DOOR_OPEN = unchecked((int)0x80000289),
        STATUS_ENCRYPTION_FAILED = unchecked((int)0xC000028A),
        STATUS_DECRYPTION_FAILED = unchecked((int)0xC000028B),
        STATUS_RANGE_NOT_FOUND = unchecked((int)0xC000028C),
        STATUS_NO_RECOVERY_POLICY = unchecked((int)0xC000028D),
        STATUS_NO_EFS = unchecked((int)0xC000028E),
        STATUS_WRONG_EFS = unchecked((int)0xC000028F),
        STATUS_NO_USER_KEYS = unchecked((int)0xC0000290),
        STATUS_FILE_NOT_ENCRYPTED = unchecked((int)0xC0000291),
        STATUS_NOT_EXPORT_FORMAT = unchecked((int)0xC0000292),
        STATUS_FILE_ENCRYPTED = unchecked((int)0xC0000293),
        STATUS_WAKE_SYSTEM = unchecked((int)0x40000294),
        STATUS_WMI_GUID_NOT_FOUND = unchecked((int)0xC0000295),
        STATUS_WMI_INSTANCE_NOT_FOUND = unchecked((int)0xC0000296),
        STATUS_WMI_ITEMID_NOT_FOUND = unchecked((int)0xC0000297),
        STATUS_WMI_TRY_AGAIN = unchecked((int)0xC0000298),
        STATUS_SHARED_POLICY = unchecked((int)0xC0000299),
        STATUS_POLICY_OBJECT_NOT_FOUND = unchecked((int)0xC000029A),
        STATUS_POLICY_ONLY_IN_DS = unchecked((int)0xC000029B),
        STATUS_VOLUME_NOT_UPGRADED = unchecked((int)0xC000029C),
        STATUS_REMOTE_STORAGE_NOT_ACTIVE = unchecked((int)0xC000029D),
        STATUS_REMOTE_STORAGE_MEDIA_ERROR = unchecked((int)0xC000029E),
        STATUS_NO_TRACKING_SERVICE = unchecked((int)0xC000029F),
        STATUS_SERVER_SID_MISMATCH = unchecked((int)0xC00002A0),
        STATUS_DS_NO_ATTRIBUTE_OR_VALUE = unchecked((int)0xC00002A1),
        STATUS_DS_INVALID_ATTRIBUTE_SYNTAX = unchecked((int)0xC00002A2),
        STATUS_DS_ATTRIBUTE_TYPE_UNDEFINED = unchecked((int)0xC00002A3),
        STATUS_DS_ATTRIBUTE_OR_VALUE_EXISTS = unchecked((int)0xC00002A4),
        STATUS_DS_BUSY = unchecked((int)0xC00002A5),
        STATUS_DS_UNAVAILABLE = unchecked((int)0xC00002A6),
        STATUS_DS_NO_RIDS_ALLOCATED = unchecked((int)0xC00002A7),
        STATUS_DS_NO_MORE_RIDS = unchecked((int)0xC00002A8),
        STATUS_DS_INCORRECT_ROLE_OWNER = unchecked((int)0xC00002A9),
        STATUS_DS_RIDMGR_INIT_ERROR = unchecked((int)0xC00002AA),
        STATUS_DS_OBJ_CLASS_VIOLATION = unchecked((int)0xC00002AB),
        STATUS_DS_CANT_ON_NON_LEAF = unchecked((int)0xC00002AC),
        STATUS_DS_CANT_ON_RDN = unchecked((int)0xC00002AD),
        STATUS_DS_CANT_MOD_OBJ_CLASS = unchecked((int)0xC00002AE),
        STATUS_DS_CROSS_DOM_MOVE_FAILED = unchecked((int)0xC00002AF),
        STATUS_DS_GC_NOT_AVAILABLE = unchecked((int)0xC00002B0),
        STATUS_DIRECTORY_SERVICE_REQUIRED = unchecked((int)0xC00002B1),
        STATUS_REPARSE_ATTRIBUTE_CONFLICT = unchecked((int)0xC00002B2),
        STATUS_CANT_ENABLE_DENY_ONLY = unchecked((int)0xC00002B3),
        STATUS_FLOAT_MULTIPLE_FAULTS = unchecked((int)0xC00002B4),
        STATUS_FLOAT_MULTIPLE_TRAPS = unchecked((int)0xC00002B5),
        STATUS_DEVICE_REMOVED = unchecked((int)0xC00002B6),
        STATUS_JOURNAL_DELETE_IN_PROGRESS = unchecked((int)0xC00002B7),
        STATUS_JOURNAL_NOT_ACTIVE = unchecked((int)0xC00002B8),
        STATUS_NOINTERFACE = unchecked((int)0xC00002B9),
        STATUS_DS_RIDMGR_DISABLED = unchecked((int)0xC00002BA),
        STATUS_DS_ADMIN_LIMIT_EXCEEDED = unchecked((int)0xC00002C1),
        STATUS_DRIVER_FAILED_SLEEP = unchecked((int)0xC00002C2),
        STATUS_MUTUAL_AUTHENTICATION_FAILED = unchecked((int)0xC00002C3),
        STATUS_CORRUPT_SYSTEM_FILE = unchecked((int)0xC00002C4),
        STATUS_DATATYPE_MISALIGNMENT_ERROR = unchecked((int)0xC00002C5),
        STATUS_WMI_READ_ONLY = unchecked((int)0xC00002C6),
        STATUS_WMI_SET_FAILURE = unchecked((int)0xC00002C7),
        STATUS_COMMITMENT_MINIMUM = unchecked((int)0xC00002C8),
        STATUS_REG_NAT_CONSUMPTION = unchecked((int)0xC00002C9),
        STATUS_TRANSPORT_FULL = unchecked((int)0xC00002CA),
        STATUS_DS_SAM_INIT_FAILURE = unchecked((int)0xC00002CB),
        STATUS_ONLY_IF_CONNECTED = unchecked((int)0xC00002CC),
        STATUS_DS_SENSITIVE_GROUP_VIOLATION = unchecked((int)0xC00002CD),
        STATUS_PNP_RESTART_ENUMERATION = unchecked((int)0xC00002CE),
        STATUS_JOURNAL_ENTRY_DELETED = unchecked((int)0xC00002CF),
        STATUS_DS_CANT_MOD_PRIMARYGROUPID = unchecked((int)0xC00002D0),
        STATUS_SYSTEM_IMAGE_BAD_SIGNATURE = unchecked((int)0xC00002D1),
        STATUS_PNP_REBOOT_REQUIRED = unchecked((int)0xC00002D2),
        STATUS_POWER_STATE_INVALID = unchecked((int)0xC00002D3),
        STATUS_DS_INVALID_GROUP_TYPE = unchecked((int)0xC00002D4),
        STATUS_DS_NO_NEST_GLOBALGROUP_IN_MIXEDDOMAIN = unchecked((int)0xC00002D5),
        STATUS_DS_NO_NEST_LOCALGROUP_IN_MIXEDDOMAIN = unchecked((int)0xC00002D6),
        STATUS_DS_GLOBAL_CANT_HAVE_LOCAL_MEMBER = unchecked((int)0xC00002D7),
        STATUS_DS_GLOBAL_CANT_HAVE_UNIVERSAL_MEMBER = unchecked((int)0xC00002D8),
        STATUS_DS_UNIVERSAL_CANT_HAVE_LOCAL_MEMBER = unchecked((int)0xC00002D9),
        STATUS_DS_GLOBAL_CANT_HAVE_CROSSDOMAIN_MEMBER = unchecked((int)0xC00002DA),
        STATUS_DS_LOCAL_CANT_HAVE_CROSSDOMAIN_LOCAL_MEMBER = unchecked((int)0xC00002DB),
        STATUS_DS_HAVE_PRIMARY_MEMBERS = unchecked((int)0xC00002DC),
        STATUS_WMI_NOT_SUPPORTED = unchecked((int)0xC00002DD),
        STATUS_INSUFFICIENT_POWER = unchecked((int)0xC00002DE),
        STATUS_SAM_NEED_BOOTKEY_PASSWORD = unchecked((int)0xC00002DF),
        STATUS_SAM_NEED_BOOTKEY_FLOPPY = unchecked((int)0xC00002E0),
        STATUS_DS_CANT_START = unchecked((int)0xC00002E1),
        STATUS_DS_INIT_FAILURE = unchecked((int)0xC00002E2),
        STATUS_SAM_INIT_FAILURE = unchecked((int)0xC00002E3),
        STATUS_DS_GC_REQUIRED = unchecked((int)0xC00002E4),
        STATUS_DS_LOCAL_MEMBER_OF_LOCAL_ONLY = unchecked((int)0xC00002E5),
        STATUS_DS_NO_FPO_IN_UNIVERSAL_GROUPS = unchecked((int)0xC00002E6),
        STATUS_DS_MACHINE_ACCOUNT_QUOTA_EXCEEDED = unchecked((int)0xC00002E7),
        STATUS_MULTIPLE_FAULT_VIOLATION = unchecked((int)0xC00002E8),
        STATUS_CURRENT_DOMAIN_NOT_ALLOWED = unchecked((int)0xC00002E9),
        STATUS_CANNOT_MAKE = unchecked((int)0xC00002EA),
        STATUS_SYSTEM_SHUTDOWN = unchecked((int)0xC00002EB),
        STATUS_DS_INIT_FAILURE_CONSOLE = unchecked((int)0xC00002EC),
        STATUS_DS_SAM_INIT_FAILURE_CONSOLE = unchecked((int)0xC00002ED),
        STATUS_UNFINISHED_CONTEXT_DELETED = unchecked((int)0xC00002EE),
        STATUS_NO_TGT_REPLY = unchecked((int)0xC00002EF),
        STATUS_OBJECTID_NOT_FOUND = unchecked((int)0xC00002F0),
        STATUS_NO_IP_ADDRESSES = unchecked((int)0xC00002F1),
        STATUS_WRONG_CREDENTIAL_HANDLE = unchecked((int)0xC00002F2),
        STATUS_CRYPTO_SYSTEM_INVALID = unchecked((int)0xC00002F3),
        STATUS_MAX_REFERRALS_EXCEEDED = unchecked((int)0xC00002F4),
        STATUS_MUST_BE_KDC = unchecked((int)0xC00002F5),
        STATUS_STRONG_CRYPTO_NOT_SUPPORTED = unchecked((int)0xC00002F6),
        STATUS_TOO_MANY_PRINCIPALS = unchecked((int)0xC00002F7),
        STATUS_NO_PA_DATA = unchecked((int)0xC00002F8),
        STATUS_PKINIT_NAME_MISMATCH = unchecked((int)0xC00002F9),
        STATUS_SMARTCARD_LOGON_REQUIRED = unchecked((int)0xC00002FA),
        STATUS_KDC_INVALID_REQUEST = unchecked((int)0xC00002FB),
        STATUS_KDC_UNABLE_TO_REFER = unchecked((int)0xC00002FC),
        STATUS_KDC_UNKNOWN_ETYPE = unchecked((int)0xC00002FD),
        STATUS_SHUTDOWN_IN_PROGRESS = unchecked((int)0xC00002FE),
        STATUS_SERVER_SHUTDOWN_IN_PROGRESS = unchecked((int)0xC00002FF),
        STATUS_NOT_SUPPORTED_ON_SBS = unchecked((int)0xC0000300),
        STATUS_WMI_GUID_DISCONNECTED = unchecked((int)0xC0000301),
        STATUS_WMI_ALREADY_DISABLED = unchecked((int)0xC0000302),
        STATUS_WMI_ALREADY_ENABLED = unchecked((int)0xC0000303),
        STATUS_MFT_TOO_FRAGMENTED = unchecked((int)0xC0000304),
        STATUS_COPY_PROTECTION_FAILURE = unchecked((int)0xC0000305),
        STATUS_CSS_AUTHENTICATION_FAILURE = unchecked((int)0xC0000306),
        STATUS_CSS_KEY_NOT_PRESENT = unchecked((int)0xC0000307),
        STATUS_CSS_KEY_NOT_ESTABLISHED = unchecked((int)0xC0000308),
        STATUS_CSS_SCRAMBLED_SECTOR = unchecked((int)0xC0000309),
        STATUS_CSS_REGION_MISMATCH = unchecked((int)0xC000030A),
        STATUS_CSS_RESETS_EXHAUSTED = unchecked((int)0xC000030B),
        STATUS_PASSWORD_CHANGE_REQUIRED = unchecked((int)0xC000030C),
        STATUS_LOST_MODE_LOGON_RESTRICTION = unchecked((int)0xC000030D),
        STATUS_PKINIT_FAILURE = unchecked((int)0xC0000320),
        STATUS_SMARTCARD_SUBSYSTEM_FAILURE = unchecked((int)0xC0000321),
        STATUS_NO_KERB_KEY = unchecked((int)0xC0000322),
        STATUS_HOST_DOWN = unchecked((int)0xC0000350),
        STATUS_UNSUPPORTED_PREAUTH = unchecked((int)0xC0000351),
        STATUS_EFS_ALG_BLOB_TOO_BIG = unchecked((int)0xC0000352),
        STATUS_PORT_NOT_SET = unchecked((int)0xC0000353),
        STATUS_DEBUGGER_INACTIVE = unchecked((int)0xC0000354),
        STATUS_DS_VERSION_CHECK_FAILURE = unchecked((int)0xC0000355),
        STATUS_AUDITING_DISABLED = unchecked((int)0xC0000356),
        STATUS_PRENT4_MACHINE_ACCOUNT = unchecked((int)0xC0000357),
        STATUS_DS_AG_CANT_HAVE_UNIVERSAL_MEMBER = unchecked((int)0xC0000358),
        STATUS_INVALID_IMAGE_WIN_32 = unchecked((int)0xC0000359),
        STATUS_INVALID_IMAGE_WIN_64 = unchecked((int)0xC000035A),
        STATUS_BAD_BINDINGS = unchecked((int)0xC000035B),
        STATUS_NETWORK_SESSION_EXPIRED = unchecked((int)0xC000035C),
        STATUS_APPHELP_BLOCK = unchecked((int)0xC000035D),
        STATUS_ALL_SIDS_FILTERED = unchecked((int)0xC000035E),
        STATUS_NOT_SAFE_MODE_DRIVER = unchecked((int)0xC000035F),
        STATUS_ACCESS_DISABLED_BY_POLICY_DEFAULT = unchecked((int)0xC0000361),
        STATUS_ACCESS_DISABLED_BY_POLICY_PATH = unchecked((int)0xC0000362),
        STATUS_ACCESS_DISABLED_BY_POLICY_PUBLISHER = unchecked((int)0xC0000363),
        STATUS_ACCESS_DISABLED_BY_POLICY_OTHER = unchecked((int)0xC0000364),
        STATUS_FAILED_DRIVER_ENTRY = unchecked((int)0xC0000365),
        STATUS_DEVICE_ENUMERATION_ERROR = unchecked((int)0xC0000366),
        STATUS_MOUNT_POINT_NOT_RESOLVED = unchecked((int)0xC0000368),
        STATUS_INVALID_DEVICE_OBJECT_PARAMETER = unchecked((int)0xC0000369),
        STATUS_MCA_OCCURED = unchecked((int)0xC000036A),
        STATUS_DRIVER_BLOCKED_CRITICAL = unchecked((int)0xC000036B),
        STATUS_DRIVER_BLOCKED = unchecked((int)0xC000036C),
        STATUS_DRIVER_DATABASE_ERROR = unchecked((int)0xC000036D),
        STATUS_SYSTEM_HIVE_TOO_LARGE = unchecked((int)0xC000036E),
        STATUS_INVALID_IMPORT_OF_NON_DLL = unchecked((int)0xC000036F),
        STATUS_DS_SHUTTING_DOWN = unchecked((int)0x40000370),
        STATUS_NO_SECRETS = unchecked((int)0xC0000371),
        STATUS_ACCESS_DISABLED_NO_SAFER_UI_BY_POLICY = unchecked((int)0xC0000372),
        STATUS_FAILED_STACK_SWITCH = unchecked((int)0xC0000373),
        STATUS_HEAP_CORRUPTION = unchecked((int)0xC0000374),
        STATUS_SMARTCARD_WRONG_PIN = unchecked((int)0xC0000380),
        STATUS_SMARTCARD_CARD_BLOCKED = unchecked((int)0xC0000381),
        STATUS_SMARTCARD_CARD_NOT_AUTHENTICATED = unchecked((int)0xC0000382),
        STATUS_SMARTCARD_NO_CARD = unchecked((int)0xC0000383),
        STATUS_SMARTCARD_NO_KEY_CONTAINER = unchecked((int)0xC0000384),
        STATUS_SMARTCARD_NO_CERTIFICATE = unchecked((int)0xC0000385),
        STATUS_SMARTCARD_NO_KEYSET = unchecked((int)0xC0000386),
        STATUS_SMARTCARD_IO_ERROR = unchecked((int)0xC0000387),
        STATUS_DOWNGRADE_DETECTED = unchecked((int)0xC0000388),
        STATUS_SMARTCARD_CERT_REVOKED = unchecked((int)0xC0000389),
        STATUS_ISSUING_CA_UNTRUSTED = unchecked((int)0xC000038A),
        STATUS_REVOCATION_OFFLINE_C = unchecked((int)0xC000038B),
        STATUS_PKINIT_CLIENT_FAILURE = unchecked((int)0xC000038C),
        STATUS_SMARTCARD_CERT_EXPIRED = unchecked((int)0xC000038D),
        STATUS_DRIVER_FAILED_PRIOR_UNLOAD = unchecked((int)0xC000038E),
        STATUS_SMARTCARD_SILENT_CONTEXT = unchecked((int)0xC000038F),
        STATUS_PER_USER_TRUST_QUOTA_EXCEEDED = unchecked((int)0xC0000401),
        STATUS_ALL_USER_TRUST_QUOTA_EXCEEDED = unchecked((int)0xC0000402),
        STATUS_USER_DELETE_TRUST_QUOTA_EXCEEDED = unchecked((int)0xC0000403),
        STATUS_DS_NAME_NOT_UNIQUE = unchecked((int)0xC0000404),
        STATUS_DS_DUPLICATE_ID_FOUND = unchecked((int)0xC0000405),
        STATUS_DS_GROUP_CONVERSION_ERROR = unchecked((int)0xC0000406),
        STATUS_VOLSNAP_PREPARE_HIBERNATE = unchecked((int)0xC0000407),
        STATUS_USER2USER_REQUIRED = unchecked((int)0xC0000408),
        STATUS_STACK_BUFFER_OVERRUN = unchecked((int)0xC0000409),
        STATUS_NO_S4U_PROT_SUPPORT = unchecked((int)0xC000040A),
        STATUS_CROSSREALM_DELEGATION_FAILURE = unchecked((int)0xC000040B),
        STATUS_REVOCATION_OFFLINE_KDC = unchecked((int)0xC000040C),
        STATUS_ISSUING_CA_UNTRUSTED_KDC = unchecked((int)0xC000040D),
        STATUS_KDC_CERT_EXPIRED = unchecked((int)0xC000040E),
        STATUS_KDC_CERT_REVOKED = unchecked((int)0xC000040F),
        STATUS_PARAMETER_QUOTA_EXCEEDED = unchecked((int)0xC0000410),
        STATUS_HIBERNATION_FAILURE = unchecked((int)0xC0000411),
        STATUS_DELAY_LOAD_FAILED = unchecked((int)0xC0000412),
        STATUS_AUTHENTICATION_FIREWALL_FAILED = unchecked((int)0xC0000413),
        STATUS_VDM_DISALLOWED = unchecked((int)0xC0000414),
        STATUS_HUNG_DISPLAY_DRIVER_THREAD = unchecked((int)0xC0000415),
        STATUS_INSUFFICIENT_RESOURCE_FOR_SPECIFIED_SHARED_SECTION_SIZE = unchecked((int)0xC0000416),
        STATUS_INVALID_CRUNTIME_PARAMETER = unchecked((int)0xC0000417),
        STATUS_NTLM_BLOCKED = unchecked((int)0xC0000418),
        STATUS_DS_SRC_SID_EXISTS_IN_FOREST = unchecked((int)0xC0000419),
        STATUS_DS_DOMAIN_NAME_EXISTS_IN_FOREST = unchecked((int)0xC000041A),
        STATUS_DS_FLAT_NAME_EXISTS_IN_FOREST = unchecked((int)0xC000041B),
        STATUS_INVALID_USER_PRINCIPAL_NAME = unchecked((int)0xC000041C),
        STATUS_FATAL_USER_CALLBACK_EXCEPTION = unchecked((int)0xC000041D),
        STATUS_ASSERTION_FAILURE = unchecked((int)0xC0000420),
        STATUS_VERIFIER_STOP = unchecked((int)0xC0000421),
        STATUS_CALLBACK_POP_STACK = unchecked((int)0xC0000423),
        STATUS_INCOMPATIBLE_DRIVER_BLOCKED = unchecked((int)0xC0000424),
        STATUS_HIVE_UNLOADED = unchecked((int)0xC0000425),
        STATUS_COMPRESSION_DISABLED = unchecked((int)0xC0000426),
        STATUS_FILE_SYSTEM_LIMITATION = unchecked((int)0xC0000427),
        STATUS_INVALID_IMAGE_HASH = unchecked((int)0xC0000428),
        STATUS_NOT_CAPABLE = unchecked((int)0xC0000429),
        STATUS_REQUEST_OUT_OF_SEQUENCE = unchecked((int)0xC000042A),
        STATUS_IMPLEMENTATION_LIMIT = unchecked((int)0xC000042B),
        STATUS_ELEVATION_REQUIRED = unchecked((int)0xC000042C),
        STATUS_NO_SECURITY_CONTEXT = unchecked((int)0xC000042D),
        STATUS_PKU2U_CERT_FAILURE = unchecked((int)0xC000042F),
        STATUS_BEYOND_VDL = unchecked((int)0xC0000432),
        STATUS_ENCOUNTERED_WRITE_IN_PROGRESS = unchecked((int)0xC0000433),
        STATUS_PTE_CHANGED = unchecked((int)0xC0000434),
        STATUS_PURGE_FAILED = unchecked((int)0xC0000435),
        STATUS_CRED_REQUIRES_CONFIRMATION = unchecked((int)0xC0000440),
        STATUS_CS_ENCRYPTION_INVALID_SERVER_RESPONSE = unchecked((int)0xC0000441),
        STATUS_CS_ENCRYPTION_UNSUPPORTED_SERVER = unchecked((int)0xC0000442),
        STATUS_CS_ENCRYPTION_EXISTING_ENCRYPTED_FILE = unchecked((int)0xC0000443),
        STATUS_CS_ENCRYPTION_NEW_ENCRYPTED_FILE = unchecked((int)0xC0000444),
        STATUS_CS_ENCRYPTION_FILE_NOT_CSE = unchecked((int)0xC0000445),
        STATUS_INVALID_LABEL = unchecked((int)0xC0000446),
        STATUS_DRIVER_PROCESS_TERMINATED = unchecked((int)0xC0000450),
        STATUS_AMBIGUOUS_SYSTEM_DEVICE = unchecked((int)0xC0000451),
        STATUS_SYSTEM_DEVICE_NOT_FOUND = unchecked((int)0xC0000452),
        STATUS_RESTART_BOOT_APPLICATION = unchecked((int)0xC0000453),
        STATUS_INSUFFICIENT_NVRAM_RESOURCES = unchecked((int)0xC0000454),
        STATUS_INVALID_SESSION = unchecked((int)0xC0000455),
        STATUS_THREAD_ALREADY_IN_SESSION = unchecked((int)0xC0000456),
        STATUS_THREAD_NOT_IN_SESSION = unchecked((int)0xC0000457),
        STATUS_INVALID_WEIGHT = unchecked((int)0xC0000458),
        STATUS_REQUEST_PAUSED = unchecked((int)0xC0000459),
        STATUS_NO_RANGES_PROCESSED = unchecked((int)0xC0000460),
        STATUS_DISK_RESOURCES_EXHAUSTED = unchecked((int)0xC0000461),
        STATUS_NEEDS_REMEDIATION = unchecked((int)0xC0000462),
        STATUS_DEVICE_FEATURE_NOT_SUPPORTED = unchecked((int)0xC0000463),
        STATUS_DEVICE_UNREACHABLE = unchecked((int)0xC0000464),
        STATUS_INVALID_TOKEN = unchecked((int)0xC0000465),
        STATUS_SERVER_UNAVAILABLE = unchecked((int)0xC0000466),
        STATUS_FILE_NOT_AVAILABLE = unchecked((int)0xC0000467),
        STATUS_DEVICE_INSUFFICIENT_RESOURCES = unchecked((int)0xC0000468),
        STATUS_PACKAGE_UPDATING = unchecked((int)0xC0000469),
        STATUS_NOT_READ_FROM_COPY = unchecked((int)0xC000046A),
        STATUS_FT_WRITE_FAILURE = unchecked((int)0xC000046B),
        STATUS_FT_DI_SCAN_REQUIRED = unchecked((int)0xC000046C),
        STATUS_OBJECT_NOT_EXTERNALLY_BACKED = unchecked((int)0xC000046D),
        STATUS_EXTERNAL_BACKING_PROVIDER_UNKNOWN = unchecked((int)0xC000046E),
        STATUS_COMPRESSION_NOT_BENEFICIAL = unchecked((int)0xC000046F),
        STATUS_DATA_CHECKSUM_ERROR = unchecked((int)0xC0000470),
        STATUS_INTERMIXED_KERNEL_EA_OPERATION = unchecked((int)0xC0000471),
        STATUS_TRIM_READ_ZERO_NOT_SUPPORTED = unchecked((int)0xC0000472),
        STATUS_TOO_MANY_SEGMENT_DESCRIPTORS = unchecked((int)0xC0000473),
        STATUS_INVALID_OFFSET_ALIGNMENT = unchecked((int)0xC0000474),
        STATUS_INVALID_FIELD_IN_PARAMETER_LIST = unchecked((int)0xC0000475),
        STATUS_OPERATION_IN_PROGRESS = unchecked((int)0xC0000476),
        STATUS_INVALID_INITIATOR_TARGET_PATH = unchecked((int)0xC0000477),
        STATUS_SCRUB_DATA_DISABLED = unchecked((int)0xC0000478),
        STATUS_NOT_REDUNDANT_STORAGE = unchecked((int)0xC0000479),
        STATUS_RESIDENT_FILE_NOT_SUPPORTED = unchecked((int)0xC000047A),
        STATUS_COMPRESSED_FILE_NOT_SUPPORTED = unchecked((int)0xC000047B),
        STATUS_DIRECTORY_NOT_SUPPORTED = unchecked((int)0xC000047C),
        STATUS_IO_OPERATION_TIMEOUT = unchecked((int)0xC000047D),
        STATUS_SYSTEM_NEEDS_REMEDIATION = unchecked((int)0xC000047E),
        STATUS_APPX_INTEGRITY_FAILURE_CLR_NGEN = unchecked((int)0xC000047F),
        STATUS_SHARE_UNAVAILABLE = unchecked((int)0xC0000480),
        STATUS_APISET_NOT_HOSTED = unchecked((int)0xC0000481),
        STATUS_APISET_NOT_PRESENT = unchecked((int)0xC0000482),
        STATUS_DEVICE_HARDWARE_ERROR = unchecked((int)0xC0000483),
        STATUS_FIRMWARE_SLOT_INVALID = unchecked((int)0xC0000484),
        STATUS_FIRMWARE_IMAGE_INVALID = unchecked((int)0xC0000485),
        STATUS_STORAGE_TOPOLOGY_ID_MISMATCH = unchecked((int)0xC0000486),
        STATUS_WIM_NOT_BOOTABLE = unchecked((int)0xC0000487),
        STATUS_BLOCKED_BY_PARENTAL_CONTROLS = unchecked((int)0xC0000488),
        STATUS_NEEDS_REGISTRATION = unchecked((int)0xC0000489),
        STATUS_QUOTA_ACTIVITY = unchecked((int)0xC000048A),
        STATUS_CALLBACK_INVOKE_INLINE = unchecked((int)0xC000048B),
        STATUS_BLOCK_TOO_MANY_REFERENCES = unchecked((int)0xC000048C),
        STATUS_MARKED_TO_DISALLOW_WRITES = unchecked((int)0xC000048D),
        STATUS_NETWORK_ACCESS_DENIED_EDP = unchecked((int)0xC000048E),
        STATUS_ENCLAVE_FAILURE = unchecked((int)0xC000048F),
        STATUS_PNP_NO_COMPAT_DRIVERS = unchecked((int)0xC0000490),
        STATUS_PNP_DRIVER_PACKAGE_NOT_FOUND = unchecked((int)0xC0000491),
        STATUS_PNP_DRIVER_CONFIGURATION_NOT_FOUND = unchecked((int)0xC0000492),
        STATUS_PNP_DRIVER_CONFIGURATION_INCOMPLETE = unchecked((int)0xC0000493),
        STATUS_PNP_FUNCTION_DRIVER_REQUIRED = unchecked((int)0xC0000494),
        STATUS_PNP_DEVICE_CONFIGURATION_PENDING = unchecked((int)0xC0000495),
        STATUS_DEVICE_HINT_NAME_BUFFER_TOO_SMALL = unchecked((int)0xC0000496),
        STATUS_PACKAGE_NOT_AVAILABLE = unchecked((int)0xC0000497),
        STATUS_DEVICE_IN_MAINTENANCE = unchecked((int)0xC0000499),
        STATUS_NOT_SUPPORTED_ON_DAX = unchecked((int)0xC000049A),
        STATUS_FREE_SPACE_TOO_FRAGMENTED = unchecked((int)0xC000049B),
        STATUS_DAX_MAPPING_EXISTS = unchecked((int)0xC000049C),
        STATUS_CHILD_PROCESS_BLOCKED = unchecked((int)0xC000049D),
        STATUS_STORAGE_LOST_DATA_PERSISTENCE = unchecked((int)0xC000049E),
        STATUS_PARTITION_TERMINATING = unchecked((int)0xC00004A0),
        STATUS_EXTERNAL_SYSKEY_NOT_SUPPORTED = unchecked((int)0xC00004A1),
        STATUS_ENCLAVE_VIOLATION = unchecked((int)0xC00004A2),
        STATUS_FILE_PROTECTED_UNDER_DPL = unchecked((int)0xC00004A3),
        STATUS_VOLUME_NOT_CLUSTER_ALIGNED = unchecked((int)0xC00004A4),
        STATUS_NO_PHYSICALLY_ALIGNED_FREE_SPACE_FOUND = unchecked((int)0xC00004A5),
        STATUS_APPX_FILE_NOT_ENCRYPTED = unchecked((int)0xC00004A6),
        STATUS_RWRAW_ENCRYPTED_FILE_NOT_ENCRYPTED = unchecked((int)0xC00004A7),
        STATUS_RWRAW_ENCRYPTED_INVALID_EDATAINFO_FILEOFFSET = unchecked((int)0xC00004A8),
        STATUS_RWRAW_ENCRYPTED_INVALID_EDATAINFO_FILERANGE = unchecked((int)0xC00004A9),
        STATUS_RWRAW_ENCRYPTED_INVALID_EDATAINFO_PARAMETER = unchecked((int)0xC00004AA),
        STATUS_FT_READ_FAILURE = unchecked((int)0xC00004AB),
        STATUS_PATCH_CONFLICT = unchecked((int)0xC00004AC),
        STATUS_STORAGE_RESERVE_ID_INVALID = unchecked((int)0xC00004AD),
        STATUS_STORAGE_RESERVE_DOES_NOT_EXIST = unchecked((int)0xC00004AE),
        STATUS_STORAGE_RESERVE_ALREADY_EXISTS = unchecked((int)0xC00004AF),
        STATUS_STORAGE_RESERVE_NOT_EMPTY = unchecked((int)0xC00004B0),
        STATUS_NOT_A_DAX_VOLUME = unchecked((int)0xC00004B1),
        STATUS_NOT_DAX_MAPPABLE = unchecked((int)0xC00004B2),
        STATUS_CASE_DIFFERING_NAMES_IN_DIR = unchecked((int)0xC00004B3),
        STATUS_FILE_NOT_SUPPORTED = unchecked((int)0xC00004B4),
        STATUS_NOT_SUPPORTED_WITH_BTT = unchecked((int)0xC00004B5),
        STATUS_ENCRYPTION_DISABLED = unchecked((int)0xC00004B6),
        STATUS_ENCRYPTING_METADATA_DISALLOWED = unchecked((int)0xC00004B7),
        STATUS_CANT_CLEAR_ENCRYPTION_FLAG = unchecked((int)0xC00004B8),
        STATUS_UNSATISFIED_DEPENDENCIES = unchecked((int)0xC00004B9),
        STATUS_CASE_SENSITIVE_PATH = unchecked((int)0xC00004BA),
        STATUS_UNSUPPORTED_PAGING_MODE = unchecked((int)0xC00004BB),
        STATUS_UNTRUSTED_MOUNT_POINT = unchecked((int)0xC00004BC),
        STATUS_HAS_SYSTEM_CRITICAL_FILES = unchecked((int)0xC00004BD),
        STATUS_OBJECT_IS_IMMUTABLE = unchecked((int)0xC00004BE),
        STATUS_FT_READ_FROM_COPY_FAILURE = unchecked((int)0xC00004BF),
        STATUS_IMAGE_LOADED_AS_PATCH_IMAGE = unchecked((int)0xC00004C0),
        STATUS_STORAGE_STACK_ACCESS_DENIED = unchecked((int)0xC00004C1),
        STATUS_INSUFFICIENT_VIRTUAL_ADDR_RESOURCES = unchecked((int)0xC00004C2),
        STATUS_ENCRYPTED_FILE_NOT_SUPPORTED = unchecked((int)0xC00004C3),
        STATUS_SPARSE_FILE_NOT_SUPPORTED = unchecked((int)0xC00004C4),
        STATUS_PAGEFILE_NOT_SUPPORTED = unchecked((int)0xC00004C5),
        STATUS_VOLUME_NOT_SUPPORTED = unchecked((int)0xC00004C6),
        STATUS_NOT_SUPPORTED_WITH_BYPASSIO = unchecked((int)0xC00004C7),
        STATUS_NO_BYPASSIO_DRIVER_SUPPORT = unchecked((int)0xC00004C8),
        STATUS_NOT_SUPPORTED_WITH_ENCRYPTION = unchecked((int)0xC00004C9),
        STATUS_NOT_SUPPORTED_WITH_COMPRESSION = unchecked((int)0xC00004CA),
        STATUS_NOT_SUPPORTED_WITH_REPLICATION = unchecked((int)0xC00004CB),
        STATUS_NOT_SUPPORTED_WITH_DEDUPLICATION = unchecked((int)0xC00004CC),
        STATUS_NOT_SUPPORTED_WITH_AUDITING = unchecked((int)0xC00004CD),
        STATUS_NOT_SUPPORTED_WITH_MONITORING = unchecked((int)0xC00004CE),
        STATUS_NOT_SUPPORTED_WITH_SNAPSHOT = unchecked((int)0xC00004CF),
        STATUS_NOT_SUPPORTED_WITH_VIRTUALIZATION = unchecked((int)0xC00004D0),
        STATUS_INDEX_OUT_OF_BOUNDS = unchecked((int)0xC00004D1),
        STATUS_BYPASSIO_FLT_NOT_SUPPORTED = unchecked((int)0xC00004D2),
        STATUS_VOLUME_WRITE_ACCESS_DENIED = unchecked((int)0xC00004D3),
        STATUS_INVALID_TASK_NAME = unchecked((int)0xC0000500),
        STATUS_INVALID_TASK_INDEX = unchecked((int)0xC0000501),
        STATUS_THREAD_ALREADY_IN_TASK = unchecked((int)0xC0000502),
        STATUS_CALLBACK_BYPASS = unchecked((int)0xC0000503),
        STATUS_UNDEFINED_SCOPE = unchecked((int)0xC0000504),
        STATUS_INVALID_CAP = unchecked((int)0xC0000505),
        STATUS_NOT_GUI_PROCESS = unchecked((int)0xC0000506),
        STATUS_DEVICE_HUNG = unchecked((int)0xC0000507),
        STATUS_CONTAINER_ASSIGNED = unchecked((int)0xC0000508),
        STATUS_JOB_NO_CONTAINER = unchecked((int)0xC0000509),
        STATUS_DEVICE_UNRESPONSIVE = unchecked((int)0xC000050A),
        STATUS_REPARSE_POINT_ENCOUNTERED = unchecked((int)0xC000050B),
        STATUS_ATTRIBUTE_NOT_PRESENT = unchecked((int)0xC000050C),
        STATUS_NOT_A_TIERED_VOLUME = unchecked((int)0xC000050D),
        STATUS_ALREADY_HAS_STREAM_ID = unchecked((int)0xC000050E),
        STATUS_JOB_NOT_EMPTY = unchecked((int)0xC000050F),
        STATUS_ALREADY_INITIALIZED = unchecked((int)0xC0000510),
        STATUS_ENCLAVE_NOT_TERMINATED = unchecked((int)0xC0000511),
        STATUS_ENCLAVE_IS_TERMINATING = unchecked((int)0xC0000512),
        STATUS_SMB1_NOT_AVAILABLE = unchecked((int)0xC0000513),
        STATUS_SMR_GARBAGE_COLLECTION_REQUIRED = unchecked((int)0xC0000514),
        STATUS_INTERRUPTED = unchecked((int)0xC0000515),
        STATUS_THREAD_NOT_RUNNING = unchecked((int)0xC0000516),
        STATUS_SESSION_KEY_TOO_SHORT = unchecked((int)0xC0000517),
        STATUS_FAIL_FAST_EXCEPTION = unchecked((int)0xC0000602),
        STATUS_IMAGE_CERT_REVOKED = unchecked((int)0xC0000603),
        STATUS_DYNAMIC_CODE_BLOCKED = unchecked((int)0xC0000604),
        STATUS_IMAGE_CERT_EXPIRED = unchecked((int)0xC0000605),
        STATUS_STRICT_CFG_VIOLATION = unchecked((int)0xC0000606),
        STATUS_SET_CONTEXT_DENIED = unchecked((int)0xC000060A),
        STATUS_CROSS_PARTITION_VIOLATION = unchecked((int)0xC000060B),
        STATUS_PORT_CLOSED = unchecked((int)0xC0000700),
        STATUS_MESSAGE_LOST = unchecked((int)0xC0000701),
        STATUS_INVALID_MESSAGE = unchecked((int)0xC0000702),
        STATUS_REQUEST_CANCELED = unchecked((int)0xC0000703),
        STATUS_RECURSIVE_DISPATCH = unchecked((int)0xC0000704),
        STATUS_LPC_RECEIVE_BUFFER_EXPECTED = unchecked((int)0xC0000705),
        STATUS_LPC_INVALID_CONNECTION_USAGE = unchecked((int)0xC0000706),
        STATUS_LPC_REQUESTS_NOT_ALLOWED = unchecked((int)0xC0000707),
        STATUS_RESOURCE_IN_USE = unchecked((int)0xC0000708),
        STATUS_HARDWARE_MEMORY_ERROR = unchecked((int)0xC0000709),
        STATUS_THREADPOOL_HANDLE_EXCEPTION = unchecked((int)0xC000070A),
        STATUS_THREADPOOL_SET_EVENT_ON_COMPLETION_FAILED = unchecked((int)0xC000070B),
        STATUS_THREADPOOL_RELEASE_SEMAPHORE_ON_COMPLETION_FAILED = unchecked((int)0xC000070C),
        STATUS_THREADPOOL_RELEASE_MUTEX_ON_COMPLETION_FAILED = unchecked((int)0xC000070D),
        STATUS_THREADPOOL_FREE_LIBRARY_ON_COMPLETION_FAILED = unchecked((int)0xC000070E),
        STATUS_THREADPOOL_RELEASED_DURING_OPERATION = unchecked((int)0xC000070F),
        STATUS_CALLBACK_RETURNED_WHILE_IMPERSONATING = unchecked((int)0xC0000710),
        STATUS_APC_RETURNED_WHILE_IMPERSONATING = unchecked((int)0xC0000711),
        STATUS_PROCESS_IS_PROTECTED = unchecked((int)0xC0000712),
        STATUS_MCA_EXCEPTION = unchecked((int)0xC0000713),
        STATUS_CERTIFICATE_MAPPING_NOT_UNIQUE = unchecked((int)0xC0000714),
        STATUS_SYMLINK_CLASS_DISABLED = unchecked((int)0xC0000715),
        STATUS_INVALID_IDN_NORMALIZATION = unchecked((int)0xC0000716),
        STATUS_NO_UNICODE_TRANSLATION = unchecked((int)0xC0000717),
        STATUS_ALREADY_REGISTERED = unchecked((int)0xC0000718),
        STATUS_CONTEXT_MISMATCH = unchecked((int)0xC0000719),
        STATUS_PORT_ALREADY_HAS_COMPLETION_LIST = unchecked((int)0xC000071A),
        STATUS_CALLBACK_RETURNED_THREAD_PRIORITY = unchecked((int)0xC000071B),
        STATUS_INVALID_THREAD = unchecked((int)0xC000071C),
        STATUS_CALLBACK_RETURNED_TRANSACTION = unchecked((int)0xC000071D),
        STATUS_CALLBACK_RETURNED_LDR_LOCK = unchecked((int)0xC000071E),
        STATUS_CALLBACK_RETURNED_LANG = unchecked((int)0xC000071F),
        STATUS_CALLBACK_RETURNED_PRI_BACK = unchecked((int)0xC0000720),
        STATUS_CALLBACK_RETURNED_THREAD_AFFINITY = unchecked((int)0xC0000721),
        STATUS_LPC_HANDLE_COUNT_EXCEEDED = unchecked((int)0xC0000722),
        STATUS_EXECUTABLE_MEMORY_WRITE = unchecked((int)0xC0000723),
        STATUS_KERNEL_EXECUTABLE_MEMORY_WRITE = unchecked((int)0xC0000724),
        STATUS_ATTACHED_EXECUTABLE_MEMORY_WRITE = unchecked((int)0xC0000725),
        STATUS_TRIGGERED_EXECUTABLE_MEMORY_WRITE = unchecked((int)0xC0000726),
        STATUS_DISK_REPAIR_DISABLED = unchecked((int)0xC0000800),
        STATUS_DS_DOMAIN_RENAME_IN_PROGRESS = unchecked((int)0xC0000801),
        STATUS_DISK_QUOTA_EXCEEDED = unchecked((int)0xC0000802),
        STATUS_DATA_LOST_REPAIR = unchecked((int)0x80000803),
        STATUS_CONTENT_BLOCKED = unchecked((int)0xC0000804),
        STATUS_BAD_CLUSTERS = unchecked((int)0xC0000805),
        STATUS_VOLUME_DIRTY = unchecked((int)0xC0000806),
        STATUS_DISK_REPAIR_REDIRECTED = unchecked((int)0x40000807),
        STATUS_DISK_REPAIR_UNSUCCESSFUL = unchecked((int)0xC0000808),
        STATUS_CORRUPT_LOG_OVERFULL = unchecked((int)0xC0000809),
        STATUS_CORRUPT_LOG_CORRUPTED = unchecked((int)0xC000080A),
        STATUS_CORRUPT_LOG_UNAVAILABLE = unchecked((int)0xC000080B),
        STATUS_CORRUPT_LOG_DELETED_FULL = unchecked((int)0xC000080C),
        STATUS_CORRUPT_LOG_CLEARED = unchecked((int)0xC000080D),
        STATUS_ORPHAN_NAME_EXHAUSTED = unchecked((int)0xC000080E),
        STATUS_PROACTIVE_SCAN_IN_PROGRESS = unchecked((int)0xC000080F),
        STATUS_ENCRYPTED_IO_NOT_POSSIBLE = unchecked((int)0xC0000810),
        STATUS_CORRUPT_LOG_UPLEVEL_RECORDS = unchecked((int)0xC0000811),
        STATUS_FILE_CHECKED_OUT = unchecked((int)0xC0000901),
        STATUS_CHECKOUT_REQUIRED = unchecked((int)0xC0000902),
        STATUS_BAD_FILE_TYPE = unchecked((int)0xC0000903),
        STATUS_FILE_TOO_LARGE = unchecked((int)0xC0000904),
        STATUS_FORMS_AUTH_REQUIRED = unchecked((int)0xC0000905),
        STATUS_VIRUS_INFECTED = unchecked((int)0xC0000906),
        STATUS_VIRUS_DELETED = unchecked((int)0xC0000907),
        STATUS_BAD_MCFG_TABLE = unchecked((int)0xC0000908),
        STATUS_CANNOT_BREAK_OPLOCK = unchecked((int)0xC0000909),
        STATUS_BAD_KEY = unchecked((int)0xC000090A),
        STATUS_BAD_DATA = unchecked((int)0xC000090B),
        STATUS_NO_KEY = unchecked((int)0xC000090C),
        STATUS_FILE_HANDLE_REVOKED = unchecked((int)0xC0000910),
        STATUS_SECTION_DIRECT_MAP_ONLY = unchecked((int)0xC0000911),
        STATUS_VRF_VOLATILE_CFG_AND_IO_ENABLED = unchecked((int)0xC0000C08),
        STATUS_VRF_VOLATILE_NOT_STOPPABLE = unchecked((int)0xC0000C09),
        STATUS_VRF_VOLATILE_SAFE_MODE = unchecked((int)0xC0000C0A),
        STATUS_VRF_VOLATILE_NOT_RUNNABLE_SYSTEM = unchecked((int)0xC0000C0B),
        STATUS_VRF_VOLATILE_NOT_SUPPORTED_RULECLASS = unchecked((int)0xC0000C0C),
        STATUS_VRF_VOLATILE_PROTECTED_DRIVER = unchecked((int)0xC0000C0D),
        STATUS_VRF_VOLATILE_NMI_REGISTERED = unchecked((int)0xC0000C0E),
        STATUS_VRF_VOLATILE_SETTINGS_CONFLICT = unchecked((int)0xC0000C0F),
        STATUS_DIF_IOCALLBACK_NOT_REPLACED = unchecked((int)0xC0000C76),
        STATUS_DIF_LIVEDUMP_LIMIT_EXCEEDED = unchecked((int)0xC0000C77),
        STATUS_DIF_VOLATILE_SECTION_NOT_LOCKED = unchecked((int)0xC0000C78),
        STATUS_DIF_VOLATILE_DRIVER_HOTPATCHED = unchecked((int)0xC0000C79),
        STATUS_DIF_VOLATILE_INVALID_INFO = unchecked((int)0xC0000C7A),
        STATUS_DIF_VOLATILE_DRIVER_IS_NOT_RUNNING = unchecked((int)0xC0000C7B),
        STATUS_DIF_VOLATILE_PLUGIN_IS_NOT_RUNNING = unchecked((int)0xC0000C7C),
        STATUS_DIF_VOLATILE_PLUGIN_CHANGE_NOT_ALLOWED = unchecked((int)0xC0000C7D),
        STATUS_DIF_VOLATILE_NOT_ALLOWED = unchecked((int)0xC0000C7E),
        STATUS_DIF_BINDING_API_NOT_FOUND = unchecked((int)0xC0000C7F),
        STATUS_WOW_ASSERTION = unchecked((int)0xC0009898),
        STATUS_INVALID_SIGNATURE = unchecked((int)0xC000A000),
        STATUS_HMAC_NOT_SUPPORTED = unchecked((int)0xC000A001),
        STATUS_AUTH_TAG_MISMATCH = unchecked((int)0xC000A002),
        STATUS_INVALID_STATE_TRANSITION = unchecked((int)0xC000A003),
        STATUS_INVALID_KERNEL_INFO_VERSION = unchecked((int)0xC000A004),
        STATUS_INVALID_PEP_INFO_VERSION = unchecked((int)0xC000A005),
        STATUS_HANDLE_REVOKED = unchecked((int)0xC000A006),
        STATUS_EOF_ON_GHOSTED_RANGE = unchecked((int)0xC000A007),
        STATUS_CC_NEEDS_CALLBACK_SECTION_DRAIN = unchecked((int)0xC000A008),
        STATUS_IPSEC_QUEUE_OVERFLOW = unchecked((int)0xC000A010),
        STATUS_ND_QUEUE_OVERFLOW = unchecked((int)0xC000A011),
        STATUS_HOPLIMIT_EXCEEDED = unchecked((int)0xC000A012),
        STATUS_PROTOCOL_NOT_SUPPORTED = unchecked((int)0xC000A013),
        STATUS_FASTPATH_REJECTED = unchecked((int)0xC000A014),
        STATUS_LOST_WRITEBEHIND_DATA_NETWORK_DISCONNECTED = unchecked((int)0xC000A080),
        STATUS_LOST_WRITEBEHIND_DATA_NETWORK_SERVER_ERROR = unchecked((int)0xC000A081),
        STATUS_LOST_WRITEBEHIND_DATA_LOCAL_DISK_ERROR = unchecked((int)0xC000A082),
        STATUS_XML_PARSE_ERROR = unchecked((int)0xC000A083),
        STATUS_XMLDSIG_ERROR = unchecked((int)0xC000A084),
        STATUS_WRONG_COMPARTMENT = unchecked((int)0xC000A085),
        STATUS_AUTHIP_FAILURE = unchecked((int)0xC000A086),
        STATUS_DS_OID_MAPPED_GROUP_CANT_HAVE_MEMBERS = unchecked((int)0xC000A087),
        STATUS_DS_OID_NOT_FOUND = unchecked((int)0xC000A088),
        STATUS_INCORRECT_ACCOUNT_TYPE = unchecked((int)0xC000A089),
        STATUS_HASH_NOT_SUPPORTED = unchecked((int)0xC000A100),
        STATUS_HASH_NOT_PRESENT = unchecked((int)0xC000A101),
        STATUS_SECONDARY_IC_PROVIDER_NOT_REGISTERED = unchecked((int)0xC000A121),
        STATUS_GPIO_CLIENT_INFORMATION_INVALID = unchecked((int)0xC000A122),
        STATUS_GPIO_VERSION_NOT_SUPPORTED = unchecked((int)0xC000A123),
        STATUS_GPIO_INVALID_REGISTRATION_PACKET = unchecked((int)0xC000A124),
        STATUS_GPIO_OPERATION_DENIED = unchecked((int)0xC000A125),
        STATUS_GPIO_INCOMPATIBLE_CONNECT_MODE = unchecked((int)0xC000A126),
        STATUS_GPIO_INTERRUPT_ALREADY_UNMASKED = unchecked((int)0x8000A127),
        STATUS_CANNOT_SWITCH_RUNLEVEL = unchecked((int)0xC000A141),
        STATUS_INVALID_RUNLEVEL_SETTING = unchecked((int)0xC000A142),
        STATUS_RUNLEVEL_SWITCH_TIMEOUT = unchecked((int)0xC000A143),
        STATUS_SERVICES_FAILED_AUTOSTART = unchecked((int)0x4000A144),
        STATUS_RUNLEVEL_SWITCH_AGENT_TIMEOUT = unchecked((int)0xC000A145),
        STATUS_RUNLEVEL_SWITCH_IN_PROGRESS = unchecked((int)0xC000A146),
        STATUS_NOT_APPCONTAINER = unchecked((int)0xC000A200),
        STATUS_NOT_SUPPORTED_IN_APPCONTAINER = unchecked((int)0xC000A201),
        STATUS_INVALID_PACKAGE_SID_LENGTH = unchecked((int)0xC000A202),
        STATUS_LPAC_ACCESS_DENIED = unchecked((int)0xC000A203),
        STATUS_ADMINLESS_ACCESS_DENIED = unchecked((int)0xC000A204),
        STATUS_APP_DATA_NOT_FOUND = unchecked((int)0xC000A281),
        STATUS_APP_DATA_EXPIRED = unchecked((int)0xC000A282),
        STATUS_APP_DATA_CORRUPT = unchecked((int)0xC000A283),
        STATUS_APP_DATA_LIMIT_EXCEEDED = unchecked((int)0xC000A284),
        STATUS_APP_DATA_REBOOT_REQUIRED = unchecked((int)0xC000A285),
        STATUS_OFFLOAD_READ_FLT_NOT_SUPPORTED = unchecked((int)0xC000A2A1),
        STATUS_OFFLOAD_WRITE_FLT_NOT_SUPPORTED = unchecked((int)0xC000A2A2),
        STATUS_OFFLOAD_READ_FILE_NOT_SUPPORTED = unchecked((int)0xC000A2A3),
        STATUS_OFFLOAD_WRITE_FILE_NOT_SUPPORTED = unchecked((int)0xC000A2A4),
        STATUS_WOF_WIM_HEADER_CORRUPT = unchecked((int)0xC000A2A5),
        STATUS_WOF_WIM_RESOURCE_TABLE_CORRUPT = unchecked((int)0xC000A2A6),
        STATUS_WOF_FILE_RESOURCE_TABLE_CORRUPT = unchecked((int)0xC000A2A7),
        STATUS_CIMFS_IMAGE_CORRUPT = unchecked((int)0xC000C001),
        STATUS_CIMFS_IMAGE_VERSION_NOT_SUPPORTED = unchecked((int)0xC000C002),
        STATUS_FILE_SYSTEM_VIRTUALIZATION_UNAVAILABLE = unchecked((int)0xC000CE01),
        STATUS_FILE_SYSTEM_VIRTUALIZATION_METADATA_CORRUPT = unchecked((int)0xC000CE02),
        STATUS_FILE_SYSTEM_VIRTUALIZATION_BUSY = unchecked((int)0xC000CE03),
        STATUS_FILE_SYSTEM_VIRTUALIZATION_PROVIDER_UNKNOWN = unchecked((int)0xC000CE04),
        STATUS_FILE_SYSTEM_VIRTUALIZATION_INVALID_OPERATION = unchecked((int)0xC000CE05),
        STATUS_CLOUD_FILE_SYNC_ROOT_METADATA_CORRUPT = unchecked((int)0xC000CF00),
        STATUS_CLOUD_FILE_PROVIDER_NOT_RUNNING = unchecked((int)0xC000CF01),
        STATUS_CLOUD_FILE_METADATA_CORRUPT = unchecked((int)0xC000CF02),
        STATUS_CLOUD_FILE_METADATA_TOO_LARGE = unchecked((int)0xC000CF03),
        STATUS_CLOUD_FILE_PROPERTY_BLOB_TOO_LARGE = unchecked((int)0x8000CF04),
        STATUS_CLOUD_FILE_TOO_MANY_PROPERTY_BLOBS = unchecked((int)0x8000CF05),
        STATUS_CLOUD_FILE_PROPERTY_VERSION_NOT_SUPPORTED = unchecked((int)0xC000CF06),
        STATUS_NOT_A_CLOUD_FILE = unchecked((int)0xC000CF07),
        STATUS_CLOUD_FILE_NOT_IN_SYNC = unchecked((int)0xC000CF08),
        STATUS_CLOUD_FILE_ALREADY_CONNECTED = unchecked((int)0xC000CF09),
        STATUS_CLOUD_FILE_NOT_SUPPORTED = unchecked((int)0xC000CF0A),
        STATUS_CLOUD_FILE_INVALID_REQUEST = unchecked((int)0xC000CF0B),
        STATUS_CLOUD_FILE_READ_ONLY_VOLUME = unchecked((int)0xC000CF0C),
        STATUS_CLOUD_FILE_CONNECTED_PROVIDER_ONLY = unchecked((int)0xC000CF0D),
        STATUS_CLOUD_FILE_VALIDATION_FAILED = unchecked((int)0xC000CF0E),
        STATUS_CLOUD_FILE_AUTHENTICATION_FAILED = unchecked((int)0xC000CF0F),
        STATUS_CLOUD_FILE_INSUFFICIENT_RESOURCES = unchecked((int)0xC000CF10),
        STATUS_CLOUD_FILE_NETWORK_UNAVAILABLE = unchecked((int)0xC000CF11),
        STATUS_CLOUD_FILE_UNSUCCESSFUL = unchecked((int)0xC000CF12),
        STATUS_CLOUD_FILE_NOT_UNDER_SYNC_ROOT = unchecked((int)0xC000CF13),
        STATUS_CLOUD_FILE_IN_USE = unchecked((int)0xC000CF14),
        STATUS_CLOUD_FILE_PINNED = unchecked((int)0xC000CF15),
        STATUS_CLOUD_FILE_REQUEST_ABORTED = unchecked((int)0xC000CF16),
        STATUS_CLOUD_FILE_PROPERTY_CORRUPT = unchecked((int)0xC000CF17),
        STATUS_CLOUD_FILE_ACCESS_DENIED = unchecked((int)0xC000CF18),
        STATUS_CLOUD_FILE_INCOMPATIBLE_HARDLINKS = unchecked((int)0xC000CF19),
        STATUS_CLOUD_FILE_PROPERTY_LOCK_CONFLICT = unchecked((int)0xC000CF1A),
        STATUS_CLOUD_FILE_REQUEST_CANCELED = unchecked((int)0xC000CF1B),
        STATUS_CLOUD_FILE_PROVIDER_TERMINATED = unchecked((int)0xC000CF1D),
        STATUS_NOT_A_CLOUD_SYNC_ROOT = unchecked((int)0xC000CF1E),
        STATUS_CLOUD_FILE_REQUEST_TIMEOUT = unchecked((int)0xC000CF1F),
        STATUS_CLOUD_FILE_DEHYDRATION_DISALLOWED = unchecked((int)0xC000CF20),
        STATUS_FILE_SNAP_IN_PROGRESS = unchecked((int)0xC000F500),
        STATUS_FILE_SNAP_USER_SECTION_NOT_SUPPORTED = unchecked((int)0xC000F501),
        STATUS_FILE_SNAP_MODIFY_NOT_SUPPORTED = unchecked((int)0xC000F502),
        STATUS_FILE_SNAP_IO_NOT_COORDINATED = unchecked((int)0xC000F503),
        STATUS_FILE_SNAP_UNEXPECTED_ERROR = unchecked((int)0xC000F504),
        STATUS_FILE_SNAP_INVALID_PARAMETER = unchecked((int)0xC000F505),
        STATUS_ACPI_INVALID_OPCODE = unchecked((int)0xC0140001),
        STATUS_ACPI_STACK_OVERFLOW = unchecked((int)0xC0140002),
        STATUS_ACPI_ASSERT_FAILED = unchecked((int)0xC0140003),
        STATUS_ACPI_INVALID_INDEX = unchecked((int)0xC0140004),
        STATUS_ACPI_INVALID_ARGUMENT = unchecked((int)0xC0140005),
        STATUS_ACPI_FATAL = unchecked((int)0xC0140006),
        STATUS_ACPI_INVALID_SUPERNAME = unchecked((int)0xC0140007),
        STATUS_ACPI_INVALID_ARGTYPE = unchecked((int)0xC0140008),
        STATUS_ACPI_INVALID_OBJTYPE = unchecked((int)0xC0140009),
        STATUS_ACPI_INVALID_TARGETTYPE = unchecked((int)0xC014000A),
        STATUS_ACPI_INCORRECT_ARGUMENT_COUNT = unchecked((int)0xC014000B),
        STATUS_ACPI_ADDRESS_NOT_MAPPED = unchecked((int)0xC014000C),
        STATUS_ACPI_INVALID_EVENTTYPE = unchecked((int)0xC014000D),
        STATUS_ACPI_HANDLER_COLLISION = unchecked((int)0xC014000E),
        STATUS_ACPI_INVALID_DATA = unchecked((int)0xC014000F),
        STATUS_ACPI_INVALID_REGION = unchecked((int)0xC0140010),
        STATUS_ACPI_INVALID_ACCESS_SIZE = unchecked((int)0xC0140011),
        STATUS_ACPI_ACQUIRE_GLOBAL_LOCK = unchecked((int)0xC0140012),
        STATUS_ACPI_ALREADY_INITIALIZED = unchecked((int)0xC0140013),
        STATUS_ACPI_NOT_INITIALIZED = unchecked((int)0xC0140014),
        STATUS_ACPI_INVALID_MUTEX_LEVEL = unchecked((int)0xC0140015),
        STATUS_ACPI_MUTEX_NOT_OWNED = unchecked((int)0xC0140016),
        STATUS_ACPI_MUTEX_NOT_OWNER = unchecked((int)0xC0140017),
        STATUS_ACPI_RS_ACCESS = unchecked((int)0xC0140018),
        STATUS_ACPI_INVALID_TABLE = unchecked((int)0xC0140019),
        STATUS_ACPI_REG_HANDLER_FAILED = unchecked((int)0xC0140020),
        STATUS_ACPI_POWER_REQUEST_FAILED = unchecked((int)0xC0140021),
        STATUS_CTX_WINSTATION_NAME_INVALID = unchecked((int)0xC00A0001),
        STATUS_CTX_INVALID_PD = unchecked((int)0xC00A0002),
        STATUS_CTX_PD_NOT_FOUND = unchecked((int)0xC00A0003),
        STATUS_CTX_CDM_CONNECT = unchecked((int)0x400A0004),
        STATUS_CTX_CDM_DISCONNECT = unchecked((int)0x400A0005),
        STATUS_CTX_CLOSE_PENDING = unchecked((int)0xC00A0006),
        STATUS_CTX_NO_OUTBUF = unchecked((int)0xC00A0007),
        STATUS_CTX_MODEM_INF_NOT_FOUND = unchecked((int)0xC00A0008),
        STATUS_CTX_INVALID_MODEMNAME = unchecked((int)0xC00A0009),
        STATUS_CTX_RESPONSE_ERROR = unchecked((int)0xC00A000A),
        STATUS_CTX_MODEM_RESPONSE_TIMEOUT = unchecked((int)0xC00A000B),
        STATUS_CTX_MODEM_RESPONSE_NO_CARRIER = unchecked((int)0xC00A000C),
        STATUS_CTX_MODEM_RESPONSE_NO_DIALTONE = unchecked((int)0xC00A000D),
        STATUS_CTX_MODEM_RESPONSE_BUSY = unchecked((int)0xC00A000E),
        STATUS_CTX_MODEM_RESPONSE_VOICE = unchecked((int)0xC00A000F),
        STATUS_CTX_TD_ERROR = unchecked((int)0xC00A0010),
        STATUS_CTX_LICENSE_CLIENT_INVALID = unchecked((int)0xC00A0012),
        STATUS_CTX_LICENSE_NOT_AVAILABLE = unchecked((int)0xC00A0013),
        STATUS_CTX_LICENSE_EXPIRED = unchecked((int)0xC00A0014),
        STATUS_CTX_WINSTATION_NOT_FOUND = unchecked((int)0xC00A0015),
        STATUS_CTX_WINSTATION_NAME_COLLISION = unchecked((int)0xC00A0016),
        STATUS_CTX_WINSTATION_BUSY = unchecked((int)0xC00A0017),
        STATUS_CTX_BAD_VIDEO_MODE = unchecked((int)0xC00A0018),
        STATUS_CTX_GRAPHICS_INVALID = unchecked((int)0xC00A0022),
        STATUS_CTX_NOT_CONSOLE = unchecked((int)0xC00A0024),
        STATUS_CTX_CLIENT_QUERY_TIMEOUT = unchecked((int)0xC00A0026),
        STATUS_CTX_CONSOLE_DISCONNECT = unchecked((int)0xC00A0027),
        STATUS_CTX_CONSOLE_CONNECT = unchecked((int)0xC00A0028),
        STATUS_CTX_SHADOW_DENIED = unchecked((int)0xC00A002A),
        STATUS_CTX_WINSTATION_ACCESS_DENIED = unchecked((int)0xC00A002B),
        STATUS_CTX_INVALID_WD = unchecked((int)0xC00A002E),
        STATUS_CTX_WD_NOT_FOUND = unchecked((int)0xC00A002F),
        STATUS_CTX_SHADOW_INVALID = unchecked((int)0xC00A0030),
        STATUS_CTX_SHADOW_DISABLED = unchecked((int)0xC00A0031),
        STATUS_RDP_PROTOCOL_ERROR = unchecked((int)0xC00A0032),
        STATUS_CTX_CLIENT_LICENSE_NOT_SET = unchecked((int)0xC00A0033),
        STATUS_CTX_CLIENT_LICENSE_IN_USE = unchecked((int)0xC00A0034),
        STATUS_CTX_SHADOW_ENDED_BY_MODE_CHANGE = unchecked((int)0xC00A0035),
        STATUS_CTX_SHADOW_NOT_RUNNING = unchecked((int)0xC00A0036),
        STATUS_CTX_LOGON_DISABLED = unchecked((int)0xC00A0037),
        STATUS_CTX_SECURITY_LAYER_ERROR = unchecked((int)0xC00A0038),
        STATUS_TS_INCOMPATIBLE_SESSIONS = unchecked((int)0xC00A0039),
        STATUS_TS_VIDEO_SUBSYSTEM_ERROR = unchecked((int)0xC00A003A),
        STATUS_PNP_BAD_MPS_TABLE = unchecked((int)0xC0040035),
        STATUS_PNP_TRANSLATION_FAILED = unchecked((int)0xC0040036),
        STATUS_PNP_IRQ_TRANSLATION_FAILED = unchecked((int)0xC0040037),
        STATUS_PNP_INVALID_ID = unchecked((int)0xC0040038),
        STATUS_IO_REISSUE_AS_CACHED = unchecked((int)0xC0040039),
        STATUS_MUI_FILE_NOT_FOUND = unchecked((int)0xC00B0001),
        STATUS_MUI_INVALID_FILE = unchecked((int)0xC00B0002),
        STATUS_MUI_INVALID_RC_CONFIG = unchecked((int)0xC00B0003),
        STATUS_MUI_INVALID_LOCALE_NAME = unchecked((int)0xC00B0004),
        STATUS_MUI_INVALID_ULTIMATEFALLBACK_NAME = unchecked((int)0xC00B0005),
        STATUS_MUI_FILE_NOT_LOADED = unchecked((int)0xC00B0006),
        STATUS_RESOURCE_ENUM_USER_STOP = unchecked((int)0xC00B0007),
        STATUS_FLT_NO_HANDLER_DEFINED = unchecked((int)0xC01C0001),
        STATUS_FLT_CONTEXT_ALREADY_DEFINED = unchecked((int)0xC01C0002),
        STATUS_FLT_INVALID_ASYNCHRONOUS_REQUEST = unchecked((int)0xC01C0003),
        STATUS_FLT_DISALLOW_FAST_IO = unchecked((int)0xC01C0004),
        STATUS_FLT_INVALID_NAME_REQUEST = unchecked((int)0xC01C0005),
        STATUS_FLT_NOT_SAFE_TO_POST_OPERATION = unchecked((int)0xC01C0006),
        STATUS_FLT_NOT_INITIALIZED = unchecked((int)0xC01C0007),
        STATUS_FLT_FILTER_NOT_READY = unchecked((int)0xC01C0008),
        STATUS_FLT_POST_OPERATION_CLEANUP = unchecked((int)0xC01C0009),
        STATUS_FLT_INTERNAL_ERROR = unchecked((int)0xC01C000A),
        STATUS_FLT_DELETING_OBJECT = unchecked((int)0xC01C000B),
        STATUS_FLT_MUST_BE_NONPAGED_POOL = unchecked((int)0xC01C000C),
        STATUS_FLT_DUPLICATE_ENTRY = unchecked((int)0xC01C000D),
        STATUS_FLT_CBDQ_DISABLED = unchecked((int)0xC01C000E),
        STATUS_FLT_DO_NOT_ATTACH = unchecked((int)0xC01C000F),
        STATUS_FLT_DO_NOT_DETACH = unchecked((int)0xC01C0010),
        STATUS_FLT_INSTANCE_ALTITUDE_COLLISION = unchecked((int)0xC01C0011),
        STATUS_FLT_INSTANCE_NAME_COLLISION = unchecked((int)0xC01C0012),
        STATUS_FLT_FILTER_NOT_FOUND = unchecked((int)0xC01C0013),
        STATUS_FLT_VOLUME_NOT_FOUND = unchecked((int)0xC01C0014),
        STATUS_FLT_INSTANCE_NOT_FOUND = unchecked((int)0xC01C0015),
        STATUS_FLT_CONTEXT_ALLOCATION_NOT_FOUND = unchecked((int)0xC01C0016),
        STATUS_FLT_INVALID_CONTEXT_REGISTRATION = unchecked((int)0xC01C0017),
        STATUS_FLT_NAME_CACHE_MISS = unchecked((int)0xC01C0018),
        STATUS_FLT_NO_DEVICE_OBJECT = unchecked((int)0xC01C0019),
        STATUS_FLT_VOLUME_ALREADY_MOUNTED = unchecked((int)0xC01C001A),
        STATUS_FLT_ALREADY_ENLISTED = unchecked((int)0xC01C001B),
        STATUS_FLT_CONTEXT_ALREADY_LINKED = unchecked((int)0xC01C001C),
        STATUS_FLT_NO_WAITER_FOR_REPLY = unchecked((int)0xC01C0020),
        STATUS_FLT_REGISTRATION_BUSY = unchecked((int)0xC01C0023),
        STATUS_FLT_WCOS_NOT_SUPPORTED = unchecked((int)0xC01C0024),
        STATUS_SXS_SECTION_NOT_FOUND = unchecked((int)0xC0150001),
        STATUS_SXS_CANT_GEN_ACTCTX = unchecked((int)0xC0150002),
        STATUS_SXS_INVALID_ACTCTXDATA_FORMAT = unchecked((int)0xC0150003),
        STATUS_SXS_ASSEMBLY_NOT_FOUND = unchecked((int)0xC0150004),
        STATUS_SXS_MANIFEST_FORMAT_ERROR = unchecked((int)0xC0150005),
        STATUS_SXS_MANIFEST_PARSE_ERROR = unchecked((int)0xC0150006),
        STATUS_SXS_ACTIVATION_CONTEXT_DISABLED = unchecked((int)0xC0150007),
        STATUS_SXS_KEY_NOT_FOUND = unchecked((int)0xC0150008),
        STATUS_SXS_VERSION_CONFLICT = unchecked((int)0xC0150009),
        STATUS_SXS_WRONG_SECTION_TYPE = unchecked((int)0xC015000A),
        STATUS_SXS_THREAD_QUERIES_DISABLED = unchecked((int)0xC015000B),
        STATUS_SXS_ASSEMBLY_MISSING = unchecked((int)0xC015000C),
        STATUS_SXS_RELEASE_ACTIVATION_CONTEXT = unchecked((int)0x4015000D),
        STATUS_SXS_PROCESS_DEFAULT_ALREADY_SET = unchecked((int)0xC015000E),
        STATUS_SXS_EARLY_DEACTIVATION = unchecked((int)0xC015000F),
        STATUS_SXS_INVALID_DEACTIVATION = unchecked((int)0xC0150010),
        STATUS_SXS_MULTIPLE_DEACTIVATION = unchecked((int)0xC0150011),
        STATUS_SXS_SYSTEM_DEFAULT_ACTIVATION_CONTEXT_EMPTY = unchecked((int)0xC0150012),
        STATUS_SXS_PROCESS_TERMINATION_REQUESTED = unchecked((int)0xC0150013),
        STATUS_SXS_CORRUPT_ACTIVATION_STACK = unchecked((int)0xC0150014),
        STATUS_SXS_CORRUPTION = unchecked((int)0xC0150015),
        STATUS_SXS_INVALID_IDENTITY_ATTRIBUTE_VALUE = unchecked((int)0xC0150016),
        STATUS_SXS_INVALID_IDENTITY_ATTRIBUTE_NAME = unchecked((int)0xC0150017),
        STATUS_SXS_IDENTITY_DUPLICATE_ATTRIBUTE = unchecked((int)0xC0150018),
        STATUS_SXS_IDENTITY_PARSE_ERROR = unchecked((int)0xC0150019),
        STATUS_SXS_COMPONENT_STORE_CORRUPT = unchecked((int)0xC015001A),
        STATUS_SXS_FILE_HASH_MISMATCH = unchecked((int)0xC015001B),
        STATUS_SXS_MANIFEST_IDENTITY_SAME_BUT_CONTENTS_DIFFERENT = unchecked((int)0xC015001C),
        STATUS_SXS_IDENTITIES_DIFFERENT = unchecked((int)0xC015001D),
        STATUS_SXS_ASSEMBLY_IS_NOT_A_DEPLOYMENT = unchecked((int)0xC015001E),
        STATUS_SXS_FILE_NOT_PART_OF_ASSEMBLY = unchecked((int)0xC015001F),
        STATUS_ADVANCED_INSTALLER_FAILED = unchecked((int)0xC0150020),
        STATUS_XML_ENCODING_MISMATCH = unchecked((int)0xC0150021),
        STATUS_SXS_MANIFEST_TOO_BIG = unchecked((int)0xC0150022),
        STATUS_SXS_SETTING_NOT_REGISTERED = unchecked((int)0xC0150023),
        STATUS_SXS_TRANSACTION_CLOSURE_INCOMPLETE = unchecked((int)0xC0150024),
        STATUS_SMI_PRIMITIVE_INSTALLER_FAILED = unchecked((int)0xC0150025),
        STATUS_GENERIC_COMMAND_FAILED = unchecked((int)0xC0150026),
        STATUS_SXS_FILE_HASH_MISSING = unchecked((int)0xC0150027),
        STATUS_CLUSTER_INVALID_NODE = unchecked((int)0xC0130001),
        STATUS_CLUSTER_NODE_EXISTS = unchecked((int)0xC0130002),
        STATUS_CLUSTER_JOIN_IN_PROGRESS = unchecked((int)0xC0130003),
        STATUS_CLUSTER_NODE_NOT_FOUND = unchecked((int)0xC0130004),
        STATUS_CLUSTER_LOCAL_NODE_NOT_FOUND = unchecked((int)0xC0130005),
        STATUS_CLUSTER_NETWORK_EXISTS = unchecked((int)0xC0130006),
        STATUS_CLUSTER_NETWORK_NOT_FOUND = unchecked((int)0xC0130007),
        STATUS_CLUSTER_NETINTERFACE_EXISTS = unchecked((int)0xC0130008),
        STATUS_CLUSTER_NETINTERFACE_NOT_FOUND = unchecked((int)0xC0130009),
        STATUS_CLUSTER_INVALID_REQUEST = unchecked((int)0xC013000A),
        STATUS_CLUSTER_INVALID_NETWORK_PROVIDER = unchecked((int)0xC013000B),
        STATUS_CLUSTER_NODE_DOWN = unchecked((int)0xC013000C),
        STATUS_CLUSTER_NODE_UNREACHABLE = unchecked((int)0xC013000D),
        STATUS_CLUSTER_NODE_NOT_MEMBER = unchecked((int)0xC013000E),
        STATUS_CLUSTER_JOIN_NOT_IN_PROGRESS = unchecked((int)0xC013000F),
        STATUS_CLUSTER_INVALID_NETWORK = unchecked((int)0xC0130010),
        STATUS_CLUSTER_NO_NET_ADAPTERS = unchecked((int)0xC0130011),
        STATUS_CLUSTER_NODE_UP = unchecked((int)0xC0130012),
        STATUS_CLUSTER_NODE_PAUSED = unchecked((int)0xC0130013),
        STATUS_CLUSTER_NODE_NOT_PAUSED = unchecked((int)0xC0130014),
        STATUS_CLUSTER_NO_SECURITY_CONTEXT = unchecked((int)0xC0130015),
        STATUS_CLUSTER_NETWORK_NOT_INTERNAL = unchecked((int)0xC0130016),
        STATUS_CLUSTER_POISONED = unchecked((int)0xC0130017),
        STATUS_CLUSTER_NON_CSV_PATH = unchecked((int)0xC0130018),
        STATUS_CLUSTER_CSV_VOLUME_NOT_LOCAL = unchecked((int)0xC0130019),
        STATUS_CLUSTER_CSV_READ_OPLOCK_BREAK_IN_PROGRESS = unchecked((int)0xC0130020),
        STATUS_CLUSTER_CSV_AUTO_PAUSE_ERROR = unchecked((int)0xC0130021),
        STATUS_CLUSTER_CSV_REDIRECTED = unchecked((int)0xC0130022),
        STATUS_CLUSTER_CSV_NOT_REDIRECTED = unchecked((int)0xC0130023),
        STATUS_CLUSTER_CSV_VOLUME_DRAINING = unchecked((int)0xC0130024),
        STATUS_CLUSTER_CSV_SNAPSHOT_CREATION_IN_PROGRESS = unchecked((int)0xC0130025),
        STATUS_CLUSTER_CSV_VOLUME_DRAINING_SUCCEEDED_DOWNLEVEL = unchecked((int)0xC0130026),
        STATUS_CLUSTER_CSV_NO_SNAPSHOTS = unchecked((int)0xC0130027),
        STATUS_CSV_IO_PAUSE_TIMEOUT = unchecked((int)0xC0130028),
        STATUS_CLUSTER_CSV_INVALID_HANDLE = unchecked((int)0xC0130029),
        STATUS_CLUSTER_CSV_SUPPORTED_ONLY_ON_COORDINATOR = unchecked((int)0xC0130030),
        STATUS_CLUSTER_CAM_TICKET_REPLAY_DETECTED = unchecked((int)0xC0130031),
        STATUS_TRANSACTIONAL_CONFLICT = unchecked((int)0xC0190001),
        STATUS_INVALID_TRANSACTION = unchecked((int)0xC0190002),
        STATUS_TRANSACTION_NOT_ACTIVE = unchecked((int)0xC0190003),
        STATUS_TM_INITIALIZATION_FAILED = unchecked((int)0xC0190004),
        STATUS_RM_NOT_ACTIVE = unchecked((int)0xC0190005),
        STATUS_RM_METADATA_CORRUPT = unchecked((int)0xC0190006),
        STATUS_TRANSACTION_NOT_JOINED = unchecked((int)0xC0190007),
        STATUS_DIRECTORY_NOT_RM = unchecked((int)0xC0190008),
        STATUS_COULD_NOT_RESIZE_LOG = unchecked((int)0x80190009),
        STATUS_TRANSACTIONS_UNSUPPORTED_REMOTE = unchecked((int)0xC019000A),
        STATUS_LOG_RESIZE_INVALID_SIZE = unchecked((int)0xC019000B),
        STATUS_REMOTE_FILE_VERSION_MISMATCH = unchecked((int)0xC019000C),
        STATUS_CRM_PROTOCOL_ALREADY_EXISTS = unchecked((int)0xC019000F),
        STATUS_TRANSACTION_PROPAGATION_FAILED = unchecked((int)0xC0190010),
        STATUS_CRM_PROTOCOL_NOT_FOUND = unchecked((int)0xC0190011),
        STATUS_TRANSACTION_SUPERIOR_EXISTS = unchecked((int)0xC0190012),
        STATUS_TRANSACTION_REQUEST_NOT_VALID = unchecked((int)0xC0190013),
        STATUS_TRANSACTION_NOT_REQUESTED = unchecked((int)0xC0190014),
        STATUS_TRANSACTION_ALREADY_ABORTED = unchecked((int)0xC0190015),
        STATUS_TRANSACTION_ALREADY_COMMITTED = unchecked((int)0xC0190016),
        STATUS_TRANSACTION_INVALID_MARSHALL_BUFFER = unchecked((int)0xC0190017),
        STATUS_CURRENT_TRANSACTION_NOT_VALID = unchecked((int)0xC0190018),
        STATUS_LOG_GROWTH_FAILED = unchecked((int)0xC0190019),
        STATUS_OBJECT_NO_LONGER_EXISTS = unchecked((int)0xC0190021),
        STATUS_STREAM_MINIVERSION_NOT_FOUND = unchecked((int)0xC0190022),
        STATUS_STREAM_MINIVERSION_NOT_VALID = unchecked((int)0xC0190023),
        STATUS_MINIVERSION_INACCESSIBLE_FROM_SPECIFIED_TRANSACTION = unchecked((int)0xC0190024),
        STATUS_CANT_OPEN_MINIVERSION_WITH_MODIFY_INTENT = unchecked((int)0xC0190025),
        STATUS_CANT_CREATE_MORE_STREAM_MINIVERSIONS = unchecked((int)0xC0190026),
        STATUS_HANDLE_NO_LONGER_VALID = unchecked((int)0xC0190028),
        STATUS_NO_TXF_METADATA = unchecked((int)0x80190029),
        STATUS_LOG_CORRUPTION_DETECTED = unchecked((int)0xC0190030),
        STATUS_CANT_RECOVER_WITH_HANDLE_OPEN = unchecked((int)0x80190031),
        STATUS_RM_DISCONNECTED = unchecked((int)0xC0190032),
        STATUS_ENLISTMENT_NOT_SUPERIOR = unchecked((int)0xC0190033),
        STATUS_RECOVERY_NOT_NEEDED = unchecked((int)0x40190034),
        STATUS_RM_ALREADY_STARTED = unchecked((int)0x40190035),
        STATUS_FILE_IDENTITY_NOT_PERSISTENT = unchecked((int)0xC0190036),
        STATUS_CANT_BREAK_TRANSACTIONAL_DEPENDENCY = unchecked((int)0xC0190037),
        STATUS_CANT_CROSS_RM_BOUNDARY = unchecked((int)0xC0190038),
        STATUS_TXF_DIR_NOT_EMPTY = unchecked((int)0xC0190039),
        STATUS_INDOUBT_TRANSACTIONS_EXIST = unchecked((int)0xC019003A),
        STATUS_TM_VOLATILE = unchecked((int)0xC019003B),
        STATUS_ROLLBACK_TIMER_EXPIRED = unchecked((int)0xC019003C),
        STATUS_TXF_ATTRIBUTE_CORRUPT = unchecked((int)0xC019003D),
        STATUS_EFS_NOT_ALLOWED_IN_TRANSACTION = unchecked((int)0xC019003E),
        STATUS_TRANSACTIONAL_OPEN_NOT_ALLOWED = unchecked((int)0xC019003F),
        STATUS_TRANSACTED_MAPPING_UNSUPPORTED_REMOTE = unchecked((int)0xC0190040),
        STATUS_TXF_METADATA_ALREADY_PRESENT = unchecked((int)0x80190041),
        STATUS_TRANSACTION_SCOPE_CALLBACKS_NOT_SET = unchecked((int)0x80190042),
        STATUS_TRANSACTION_REQUIRED_PROMOTION = unchecked((int)0xC0190043),
        STATUS_CANNOT_EXECUTE_FILE_IN_TRANSACTION = unchecked((int)0xC0190044),
        STATUS_TRANSACTIONS_NOT_FROZEN = unchecked((int)0xC0190045),
        STATUS_TRANSACTION_FREEZE_IN_PROGRESS = unchecked((int)0xC0190046),
        STATUS_NOT_SNAPSHOT_VOLUME = unchecked((int)0xC0190047),
        STATUS_NO_SAVEPOINT_WITH_OPEN_FILES = unchecked((int)0xC0190048),
        STATUS_SPARSE_NOT_ALLOWED_IN_TRANSACTION = unchecked((int)0xC0190049),
        STATUS_TM_IDENTITY_MISMATCH = unchecked((int)0xC019004A),
        STATUS_FLOATED_SECTION = unchecked((int)0xC019004B),
        STATUS_CANNOT_ACCEPT_TRANSACTED_WORK = unchecked((int)0xC019004C),
        STATUS_CANNOT_ABORT_TRANSACTIONS = unchecked((int)0xC019004D),
        STATUS_TRANSACTION_NOT_FOUND = unchecked((int)0xC019004E),
        STATUS_RESOURCEMANAGER_NOT_FOUND = unchecked((int)0xC019004F),
        STATUS_ENLISTMENT_NOT_FOUND = unchecked((int)0xC0190050),
        STATUS_TRANSACTIONMANAGER_NOT_FOUND = unchecked((int)0xC0190051),
        STATUS_TRANSACTIONMANAGER_NOT_ONLINE = unchecked((int)0xC0190052),
        STATUS_TRANSACTIONMANAGER_RECOVERY_NAME_COLLISION = unchecked((int)0xC0190053),
        STATUS_TRANSACTION_NOT_ROOT = unchecked((int)0xC0190054),
        STATUS_TRANSACTION_OBJECT_EXPIRED = unchecked((int)0xC0190055),
        STATUS_COMPRESSION_NOT_ALLOWED_IN_TRANSACTION = unchecked((int)0xC0190056),
        STATUS_TRANSACTION_RESPONSE_NOT_ENLISTED = unchecked((int)0xC0190057),
        STATUS_TRANSACTION_RECORD_TOO_LONG = unchecked((int)0xC0190058),
        STATUS_NO_LINK_TRACKING_IN_TRANSACTION = unchecked((int)0xC0190059),
        STATUS_OPERATION_NOT_SUPPORTED_IN_TRANSACTION = unchecked((int)0xC019005A),
        STATUS_TRANSACTION_INTEGRITY_VIOLATED = unchecked((int)0xC019005B),
        STATUS_TRANSACTIONMANAGER_IDENTITY_MISMATCH = unchecked((int)0xC019005C),
        STATUS_RM_CANNOT_BE_FROZEN_FOR_SNAPSHOT = unchecked((int)0xC019005D),
        STATUS_TRANSACTION_MUST_WRITETHROUGH = unchecked((int)0xC019005E),
        STATUS_TRANSACTION_NO_SUPERIOR = unchecked((int)0xC019005F),
        STATUS_EXPIRED_HANDLE = unchecked((int)0xC0190060),
        STATUS_TRANSACTION_NOT_ENLISTED = unchecked((int)0xC0190061),
        STATUS_LOG_SECTOR_INVALID = unchecked((int)0xC01A0001),
        STATUS_LOG_SECTOR_PARITY_INVALID = unchecked((int)0xC01A0002),
        STATUS_LOG_SECTOR_REMAPPED = unchecked((int)0xC01A0003),
        STATUS_LOG_BLOCK_INCOMPLETE = unchecked((int)0xC01A0004),
        STATUS_LOG_INVALID_RANGE = unchecked((int)0xC01A0005),
        STATUS_LOG_BLOCKS_EXHAUSTED = unchecked((int)0xC01A0006),
        STATUS_LOG_READ_CONTEXT_INVALID = unchecked((int)0xC01A0007),
        STATUS_LOG_RESTART_INVALID = unchecked((int)0xC01A0008),
        STATUS_LOG_BLOCK_VERSION = unchecked((int)0xC01A0009),
        STATUS_LOG_BLOCK_INVALID = unchecked((int)0xC01A000A),
        STATUS_LOG_READ_MODE_INVALID = unchecked((int)0xC01A000B),
        STATUS_LOG_NO_RESTART = unchecked((int)0x401A000C),
        STATUS_LOG_METADATA_CORRUPT = unchecked((int)0xC01A000D),
        STATUS_LOG_METADATA_INVALID = unchecked((int)0xC01A000E),
        STATUS_LOG_METADATA_INCONSISTENT = unchecked((int)0xC01A000F),
        STATUS_LOG_RESERVATION_INVALID = unchecked((int)0xC01A0010),
        STATUS_LOG_CANT_DELETE = unchecked((int)0xC01A0011),
        STATUS_LOG_CONTAINER_LIMIT_EXCEEDED = unchecked((int)0xC01A0012),
        STATUS_LOG_START_OF_LOG = unchecked((int)0xC01A0013),
        STATUS_LOG_POLICY_ALREADY_INSTALLED = unchecked((int)0xC01A0014),
        STATUS_LOG_POLICY_NOT_INSTALLED = unchecked((int)0xC01A0015),
        STATUS_LOG_POLICY_INVALID = unchecked((int)0xC01A0016),
        STATUS_LOG_POLICY_CONFLICT = unchecked((int)0xC01A0017),
        STATUS_LOG_PINNED_ARCHIVE_TAIL = unchecked((int)0xC01A0018),
        STATUS_LOG_RECORD_NONEXISTENT = unchecked((int)0xC01A0019),
        STATUS_LOG_RECORDS_RESERVED_INVALID = unchecked((int)0xC01A001A),
        STATUS_LOG_SPACE_RESERVED_INVALID = unchecked((int)0xC01A001B),
        STATUS_LOG_TAIL_INVALID = unchecked((int)0xC01A001C),
        STATUS_LOG_FULL = unchecked((int)0xC01A001D),
        STATUS_LOG_MULTIPLEXED = unchecked((int)0xC01A001E),
        STATUS_LOG_DEDICATED = unchecked((int)0xC01A001F),
        STATUS_LOG_ARCHIVE_NOT_IN_PROGRESS = unchecked((int)0xC01A0020),
        STATUS_LOG_ARCHIVE_IN_PROGRESS = unchecked((int)0xC01A0021),
        STATUS_LOG_EPHEMERAL = unchecked((int)0xC01A0022),
        STATUS_LOG_NOT_ENOUGH_CONTAINERS = unchecked((int)0xC01A0023),
        STATUS_LOG_CLIENT_ALREADY_REGISTERED = unchecked((int)0xC01A0024),
        STATUS_LOG_CLIENT_NOT_REGISTERED = unchecked((int)0xC01A0025),
        STATUS_LOG_FULL_HANDLER_IN_PROGRESS = unchecked((int)0xC01A0026),
        STATUS_LOG_CONTAINER_READ_FAILED = unchecked((int)0xC01A0027),
        STATUS_LOG_CONTAINER_WRITE_FAILED = unchecked((int)0xC01A0028),
        STATUS_LOG_CONTAINER_OPEN_FAILED = unchecked((int)0xC01A0029),
        STATUS_LOG_CONTAINER_STATE_INVALID = unchecked((int)0xC01A002A),
        STATUS_LOG_STATE_INVALID = unchecked((int)0xC01A002B),
        STATUS_LOG_PINNED = unchecked((int)0xC01A002C),
        STATUS_LOG_METADATA_FLUSH_FAILED = unchecked((int)0xC01A002D),
        STATUS_LOG_INCONSISTENT_SECURITY = unchecked((int)0xC01A002E),
        STATUS_LOG_APPENDED_FLUSH_FAILED = unchecked((int)0xC01A002F),
        STATUS_LOG_PINNED_RESERVATION = unchecked((int)0xC01A0030),
        STATUS_VIDEO_HUNG_DISPLAY_DRIVER_THREAD = unchecked((int)0xC01B00EA),
        STATUS_VIDEO_HUNG_DISPLAY_DRIVER_THREAD_RECOVERED = unchecked((int)0x801B00EB),
        STATUS_VIDEO_DRIVER_DEBUG_REPORT_REQUEST = unchecked((int)0x401B00EC),
        STATUS_MONITOR_NO_DESCRIPTOR = unchecked((int)0xC01D0001),
        STATUS_MONITOR_UNKNOWN_DESCRIPTOR_FORMAT = unchecked((int)0xC01D0002),
        STATUS_MONITOR_INVALID_DESCRIPTOR_CHECKSUM = unchecked((int)0xC01D0003),
        STATUS_MONITOR_INVALID_STANDARD_TIMING_BLOCK = unchecked((int)0xC01D0004),
        STATUS_MONITOR_WMI_DATABLOCK_REGISTRATION_FAILED = unchecked((int)0xC01D0005),
        STATUS_MONITOR_INVALID_SERIAL_NUMBER_MONDSC_BLOCK = unchecked((int)0xC01D0006),
        STATUS_MONITOR_INVALID_USER_FRIENDLY_MONDSC_BLOCK = unchecked((int)0xC01D0007),
        STATUS_MONITOR_NO_MORE_DESCRIPTOR_DATA = unchecked((int)0xC01D0008),
        STATUS_MONITOR_INVALID_DETAILED_TIMING_BLOCK = unchecked((int)0xC01D0009),
        STATUS_MONITOR_INVALID_MANUFACTURE_DATE = unchecked((int)0xC01D000A),
        STATUS_GRAPHICS_NOT_EXCLUSIVE_MODE_OWNER = unchecked((int)0xC01E0000),
        STATUS_GRAPHICS_INSUFFICIENT_DMA_BUFFER = unchecked((int)0xC01E0001),
        STATUS_GRAPHICS_INVALID_DISPLAY_ADAPTER = unchecked((int)0xC01E0002),
        STATUS_GRAPHICS_ADAPTER_WAS_RESET = unchecked((int)0xC01E0003),
        STATUS_GRAPHICS_INVALID_DRIVER_MODEL = unchecked((int)0xC01E0004),
        STATUS_GRAPHICS_PRESENT_MODE_CHANGED = unchecked((int)0xC01E0005),
        STATUS_GRAPHICS_PRESENT_OCCLUDED = unchecked((int)0xC01E0006),
        STATUS_GRAPHICS_PRESENT_DENIED = unchecked((int)0xC01E0007),
        STATUS_GRAPHICS_CANNOTCOLORCONVERT = unchecked((int)0xC01E0008),
        STATUS_GRAPHICS_DRIVER_MISMATCH = unchecked((int)0xC01E0009),
        STATUS_GRAPHICS_PARTIAL_DATA_POPULATED = unchecked((int)0x401E000A),
        STATUS_GRAPHICS_PRESENT_REDIRECTION_DISABLED = unchecked((int)0xC01E000B),
        STATUS_GRAPHICS_PRESENT_UNOCCLUDED = unchecked((int)0xC01E000C),
        STATUS_GRAPHICS_WINDOWDC_NOT_AVAILABLE = unchecked((int)0xC01E000D),
        STATUS_GRAPHICS_WINDOWLESS_PRESENT_DISABLED = unchecked((int)0xC01E000E),
        STATUS_GRAPHICS_PRESENT_INVALID_WINDOW = unchecked((int)0xC01E000F),
        STATUS_GRAPHICS_PRESENT_BUFFER_NOT_BOUND = unchecked((int)0xC01E0010),
        STATUS_GRAPHICS_VAIL_STATE_CHANGED = unchecked((int)0xC01E0011),
        STATUS_GRAPHICS_INDIRECT_DISPLAY_ABANDON_SWAPCHAIN = unchecked((int)0xC01E0012),
        STATUS_GRAPHICS_INDIRECT_DISPLAY_DEVICE_STOPPED = unchecked((int)0xC01E0013),
        STATUS_GRAPHICS_NO_VIDEO_MEMORY = unchecked((int)0xC01E0100),
        STATUS_GRAPHICS_CANT_LOCK_MEMORY = unchecked((int)0xC01E0101),
        STATUS_GRAPHICS_ALLOCATION_BUSY = unchecked((int)0xC01E0102),
        STATUS_GRAPHICS_TOO_MANY_REFERENCES = unchecked((int)0xC01E0103),
        STATUS_GRAPHICS_TRY_AGAIN_LATER = unchecked((int)0xC01E0104),
        STATUS_GRAPHICS_TRY_AGAIN_NOW = unchecked((int)0xC01E0105),
        STATUS_GRAPHICS_ALLOCATION_INVALID = unchecked((int)0xC01E0106),
        STATUS_GRAPHICS_UNSWIZZLING_APERTURE_UNAVAILABLE = unchecked((int)0xC01E0107),
        STATUS_GRAPHICS_UNSWIZZLING_APERTURE_UNSUPPORTED = unchecked((int)0xC01E0108),
        STATUS_GRAPHICS_CANT_EVICT_PINNED_ALLOCATION = unchecked((int)0xC01E0109),
        STATUS_GRAPHICS_INVALID_ALLOCATION_USAGE = unchecked((int)0xC01E0110),
        STATUS_GRAPHICS_CANT_RENDER_LOCKED_ALLOCATION = unchecked((int)0xC01E0111),
        STATUS_GRAPHICS_ALLOCATION_CLOSED = unchecked((int)0xC01E0112),
        STATUS_GRAPHICS_INVALID_ALLOCATION_INSTANCE = unchecked((int)0xC01E0113),
        STATUS_GRAPHICS_INVALID_ALLOCATION_HANDLE = unchecked((int)0xC01E0114),
        STATUS_GRAPHICS_WRONG_ALLOCATION_DEVICE = unchecked((int)0xC01E0115),
        STATUS_GRAPHICS_ALLOCATION_CONTENT_LOST = unchecked((int)0xC01E0116),
        STATUS_GRAPHICS_GPU_EXCEPTION_ON_DEVICE = unchecked((int)0xC01E0200),
        STATUS_GRAPHICS_SKIP_ALLOCATION_PREPARATION = unchecked((int)0x401E0201),
        STATUS_GRAPHICS_INVALID_VIDPN_TOPOLOGY = unchecked((int)0xC01E0300),
        STATUS_GRAPHICS_VIDPN_TOPOLOGY_NOT_SUPPORTED = unchecked((int)0xC01E0301),
        STATUS_GRAPHICS_VIDPN_TOPOLOGY_CURRENTLY_NOT_SUPPORTED = unchecked((int)0xC01E0302),
        STATUS_GRAPHICS_INVALID_VIDPN = unchecked((int)0xC01E0303),
        STATUS_GRAPHICS_INVALID_VIDEO_PRESENT_SOURCE = unchecked((int)0xC01E0304),
        STATUS_GRAPHICS_INVALID_VIDEO_PRESENT_TARGET = unchecked((int)0xC01E0305),
        STATUS_GRAPHICS_VIDPN_MODALITY_NOT_SUPPORTED = unchecked((int)0xC01E0306),
        STATUS_GRAPHICS_MODE_NOT_PINNED = unchecked((int)0x401E0307),
        STATUS_GRAPHICS_INVALID_VIDPN_SOURCEMODESET = unchecked((int)0xC01E0308),
        STATUS_GRAPHICS_INVALID_VIDPN_TARGETMODESET = unchecked((int)0xC01E0309),
        STATUS_GRAPHICS_INVALID_FREQUENCY = unchecked((int)0xC01E030A),
        STATUS_GRAPHICS_INVALID_ACTIVE_REGION = unchecked((int)0xC01E030B),
        STATUS_GRAPHICS_INVALID_TOTAL_REGION = unchecked((int)0xC01E030C),
        STATUS_GRAPHICS_INVALID_VIDEO_PRESENT_SOURCE_MODE = unchecked((int)0xC01E0310),
        STATUS_GRAPHICS_INVALID_VIDEO_PRESENT_TARGET_MODE = unchecked((int)0xC01E0311),
        STATUS_GRAPHICS_PINNED_MODE_MUST_REMAIN_IN_SET = unchecked((int)0xC01E0312),
        STATUS_GRAPHICS_PATH_ALREADY_IN_TOPOLOGY = unchecked((int)0xC01E0313),
        STATUS_GRAPHICS_MODE_ALREADY_IN_MODESET = unchecked((int)0xC01E0314),
        STATUS_GRAPHICS_INVALID_VIDEOPRESENTSOURCESET = unchecked((int)0xC01E0315),
        STATUS_GRAPHICS_INVALID_VIDEOPRESENTTARGETSET = unchecked((int)0xC01E0316),
        STATUS_GRAPHICS_SOURCE_ALREADY_IN_SET = unchecked((int)0xC01E0317),
        STATUS_GRAPHICS_TARGET_ALREADY_IN_SET = unchecked((int)0xC01E0318),
        STATUS_GRAPHICS_INVALID_VIDPN_PRESENT_PATH = unchecked((int)0xC01E0319),
        STATUS_GRAPHICS_NO_RECOMMENDED_VIDPN_TOPOLOGY = unchecked((int)0xC01E031A),
        STATUS_GRAPHICS_INVALID_MONITOR_FREQUENCYRANGESET = unchecked((int)0xC01E031B),
        STATUS_GRAPHICS_INVALID_MONITOR_FREQUENCYRANGE = unchecked((int)0xC01E031C),
        STATUS_GRAPHICS_FREQUENCYRANGE_NOT_IN_SET = unchecked((int)0xC01E031D),
        STATUS_GRAPHICS_NO_PREFERRED_MODE = unchecked((int)0x401E031E),
        STATUS_GRAPHICS_FREQUENCYRANGE_ALREADY_IN_SET = unchecked((int)0xC01E031F),
        STATUS_GRAPHICS_STALE_MODESET = unchecked((int)0xC01E0320),
        STATUS_GRAPHICS_INVALID_MONITOR_SOURCEMODESET = unchecked((int)0xC01E0321),
        STATUS_GRAPHICS_INVALID_MONITOR_SOURCE_MODE = unchecked((int)0xC01E0322),
        STATUS_GRAPHICS_NO_RECOMMENDED_FUNCTIONAL_VIDPN = unchecked((int)0xC01E0323),
        STATUS_GRAPHICS_MODE_ID_MUST_BE_UNIQUE = unchecked((int)0xC01E0324),
        STATUS_GRAPHICS_EMPTY_ADAPTER_MONITOR_MODE_SUPPORT_INTERSECTION = unchecked((int)0xC01E0325),
        STATUS_GRAPHICS_VIDEO_PRESENT_TARGETS_LESS_THAN_SOURCES = unchecked((int)0xC01E0326),
        STATUS_GRAPHICS_PATH_NOT_IN_TOPOLOGY = unchecked((int)0xC01E0327),
        STATUS_GRAPHICS_ADAPTER_MUST_HAVE_AT_LEAST_ONE_SOURCE = unchecked((int)0xC01E0328),
        STATUS_GRAPHICS_ADAPTER_MUST_HAVE_AT_LEAST_ONE_TARGET = unchecked((int)0xC01E0329),
        STATUS_GRAPHICS_INVALID_MONITORDESCRIPTORSET = unchecked((int)0xC01E032A),
        STATUS_GRAPHICS_INVALID_MONITORDESCRIPTOR = unchecked((int)0xC01E032B),
        STATUS_GRAPHICS_MONITORDESCRIPTOR_NOT_IN_SET = unchecked((int)0xC01E032C),
        STATUS_GRAPHICS_MONITORDESCRIPTOR_ALREADY_IN_SET = unchecked((int)0xC01E032D),
        STATUS_GRAPHICS_MONITORDESCRIPTOR_ID_MUST_BE_UNIQUE = unchecked((int)0xC01E032E),
        STATUS_GRAPHICS_INVALID_VIDPN_TARGET_SUBSET_TYPE = unchecked((int)0xC01E032F),
        STATUS_GRAPHICS_RESOURCES_NOT_RELATED = unchecked((int)0xC01E0330),
        STATUS_GRAPHICS_SOURCE_ID_MUST_BE_UNIQUE = unchecked((int)0xC01E0331),
        STATUS_GRAPHICS_TARGET_ID_MUST_BE_UNIQUE = unchecked((int)0xC01E0332),
        STATUS_GRAPHICS_NO_AVAILABLE_VIDPN_TARGET = unchecked((int)0xC01E0333),
        STATUS_GRAPHICS_MONITOR_COULD_NOT_BE_ASSOCIATED_WITH_ADAPTER = unchecked((int)0xC01E0334),
        STATUS_GRAPHICS_NO_VIDPNMGR = unchecked((int)0xC01E0335),
        STATUS_GRAPHICS_NO_ACTIVE_VIDPN = unchecked((int)0xC01E0336),
        STATUS_GRAPHICS_STALE_VIDPN_TOPOLOGY = unchecked((int)0xC01E0337),
        STATUS_GRAPHICS_MONITOR_NOT_CONNECTED = unchecked((int)0xC01E0338),
        STATUS_GRAPHICS_SOURCE_NOT_IN_TOPOLOGY = unchecked((int)0xC01E0339),
        STATUS_GRAPHICS_INVALID_PRIMARYSURFACE_SIZE = unchecked((int)0xC01E033A),
        STATUS_GRAPHICS_INVALID_VISIBLEREGION_SIZE = unchecked((int)0xC01E033B),
        STATUS_GRAPHICS_INVALID_STRIDE = unchecked((int)0xC01E033C),
        STATUS_GRAPHICS_INVALID_PIXELFORMAT = unchecked((int)0xC01E033D),
        STATUS_GRAPHICS_INVALID_COLORBASIS = unchecked((int)0xC01E033E),
        STATUS_GRAPHICS_INVALID_PIXELVALUEACCESSMODE = unchecked((int)0xC01E033F),
        STATUS_GRAPHICS_TARGET_NOT_IN_TOPOLOGY = unchecked((int)0xC01E0340),
        STATUS_GRAPHICS_NO_DISPLAY_MODE_MANAGEMENT_SUPPORT = unchecked((int)0xC01E0341),
        STATUS_GRAPHICS_VIDPN_SOURCE_IN_USE = unchecked((int)0xC01E0342),
        STATUS_GRAPHICS_CANT_ACCESS_ACTIVE_VIDPN = unchecked((int)0xC01E0343),
        STATUS_GRAPHICS_INVALID_PATH_IMPORTANCE_ORDINAL = unchecked((int)0xC01E0344),
        STATUS_GRAPHICS_INVALID_PATH_CONTENT_GEOMETRY_TRANSFORMATION = unchecked((int)0xC01E0345),
        STATUS_GRAPHICS_PATH_CONTENT_GEOMETRY_TRANSFORMATION_NOT_SUPPORTED = unchecked((int)0xC01E0346),
        STATUS_GRAPHICS_INVALID_GAMMA_RAMP = unchecked((int)0xC01E0347),
        STATUS_GRAPHICS_GAMMA_RAMP_NOT_SUPPORTED = unchecked((int)0xC01E0348),
        STATUS_GRAPHICS_MULTISAMPLING_NOT_SUPPORTED = unchecked((int)0xC01E0349),
        STATUS_GRAPHICS_MODE_NOT_IN_MODESET = unchecked((int)0xC01E034A),
        STATUS_GRAPHICS_DATASET_IS_EMPTY = unchecked((int)0x401E034B),
        STATUS_GRAPHICS_NO_MORE_ELEMENTS_IN_DATASET = unchecked((int)0x401E034C),
        STATUS_GRAPHICS_INVALID_VIDPN_TOPOLOGY_RECOMMENDATION_REASON = unchecked((int)0xC01E034D),
        STATUS_GRAPHICS_INVALID_PATH_CONTENT_TYPE = unchecked((int)0xC01E034E),
        STATUS_GRAPHICS_INVALID_COPYPROTECTION_TYPE = unchecked((int)0xC01E034F),
        STATUS_GRAPHICS_UNASSIGNED_MODESET_ALREADY_EXISTS = unchecked((int)0xC01E0350),
        STATUS_GRAPHICS_PATH_CONTENT_GEOMETRY_TRANSFORMATION_NOT_PINNED = unchecked((int)0x401E0351),
        STATUS_GRAPHICS_INVALID_SCANLINE_ORDERING = unchecked((int)0xC01E0352),
        STATUS_GRAPHICS_TOPOLOGY_CHANGES_NOT_ALLOWED = unchecked((int)0xC01E0353),
        STATUS_GRAPHICS_NO_AVAILABLE_IMPORTANCE_ORDINALS = unchecked((int)0xC01E0354),
        STATUS_GRAPHICS_INCOMPATIBLE_PRIVATE_FORMAT = unchecked((int)0xC01E0355),
        STATUS_GRAPHICS_INVALID_MODE_PRUNING_ALGORITHM = unchecked((int)0xC01E0356),
        STATUS_GRAPHICS_INVALID_MONITOR_CAPABILITY_ORIGIN = unchecked((int)0xC01E0357),
        STATUS_GRAPHICS_INVALID_MONITOR_FREQUENCYRANGE_CONSTRAINT = unchecked((int)0xC01E0358),
        STATUS_GRAPHICS_MAX_NUM_PATHS_REACHED = unchecked((int)0xC01E0359),
        STATUS_GRAPHICS_CANCEL_VIDPN_TOPOLOGY_AUGMENTATION = unchecked((int)0xC01E035A),
        STATUS_GRAPHICS_INVALID_CLIENT_TYPE = unchecked((int)0xC01E035B),
        STATUS_GRAPHICS_CLIENTVIDPN_NOT_SET = unchecked((int)0xC01E035C),
        STATUS_GRAPHICS_SPECIFIED_CHILD_ALREADY_CONNECTED = unchecked((int)0xC01E0400),
        STATUS_GRAPHICS_CHILD_DESCRIPTOR_NOT_SUPPORTED = unchecked((int)0xC01E0401),
        STATUS_GRAPHICS_UNKNOWN_CHILD_STATUS = unchecked((int)0x401E042F),
        STATUS_GRAPHICS_NOT_A_LINKED_ADAPTER = unchecked((int)0xC01E0430),
        STATUS_GRAPHICS_LEADLINK_NOT_ENUMERATED = unchecked((int)0xC01E0431),
        STATUS_GRAPHICS_CHAINLINKS_NOT_ENUMERATED = unchecked((int)0xC01E0432),
        STATUS_GRAPHICS_ADAPTER_CHAIN_NOT_READY = unchecked((int)0xC01E0433),
        STATUS_GRAPHICS_CHAINLINKS_NOT_STARTED = unchecked((int)0xC01E0434),
        STATUS_GRAPHICS_CHAINLINKS_NOT_POWERED_ON = unchecked((int)0xC01E0435),
        STATUS_GRAPHICS_INCONSISTENT_DEVICE_LINK_STATE = unchecked((int)0xC01E0436),
        STATUS_GRAPHICS_LEADLINK_START_DEFERRED = unchecked((int)0x401E0437),
        STATUS_GRAPHICS_NOT_POST_DEVICE_DRIVER = unchecked((int)0xC01E0438),
        STATUS_GRAPHICS_POLLING_TOO_FREQUENTLY = unchecked((int)0x401E0439),
        STATUS_GRAPHICS_START_DEFERRED = unchecked((int)0x401E043A),
        STATUS_GRAPHICS_ADAPTER_ACCESS_NOT_EXCLUDED = unchecked((int)0xC01E043B),
        STATUS_GRAPHICS_DEPENDABLE_CHILD_STATUS = unchecked((int)0x401E043C),
        STATUS_GRAPHICS_OPM_NOT_SUPPORTED = unchecked((int)0xC01E0500),
        STATUS_GRAPHICS_COPP_NOT_SUPPORTED = unchecked((int)0xC01E0501),
        STATUS_GRAPHICS_UAB_NOT_SUPPORTED = unchecked((int)0xC01E0502),
        STATUS_GRAPHICS_OPM_INVALID_ENCRYPTED_PARAMETERS = unchecked((int)0xC01E0503),
        STATUS_GRAPHICS_OPM_NO_PROTECTED_OUTPUTS_EXIST = unchecked((int)0xC01E0505),
        STATUS_GRAPHICS_OPM_INTERNAL_ERROR = unchecked((int)0xC01E050B),
        STATUS_GRAPHICS_OPM_INVALID_HANDLE = unchecked((int)0xC01E050C),
        STATUS_GRAPHICS_PVP_INVALID_CERTIFICATE_LENGTH = unchecked((int)0xC01E050E),
        STATUS_GRAPHICS_OPM_SPANNING_MODE_ENABLED = unchecked((int)0xC01E050F),
        STATUS_GRAPHICS_OPM_THEATER_MODE_ENABLED = unchecked((int)0xC01E0510),
        STATUS_GRAPHICS_PVP_HFS_FAILED = unchecked((int)0xC01E0511),
        STATUS_GRAPHICS_OPM_INVALID_SRM = unchecked((int)0xC01E0512),
        STATUS_GRAPHICS_OPM_OUTPUT_DOES_NOT_SUPPORT_HDCP = unchecked((int)0xC01E0513),
        STATUS_GRAPHICS_OPM_OUTPUT_DOES_NOT_SUPPORT_ACP = unchecked((int)0xC01E0514),
        STATUS_GRAPHICS_OPM_OUTPUT_DOES_NOT_SUPPORT_CGMSA = unchecked((int)0xC01E0515),
        STATUS_GRAPHICS_OPM_HDCP_SRM_NEVER_SET = unchecked((int)0xC01E0516),
        STATUS_GRAPHICS_OPM_RESOLUTION_TOO_HIGH = unchecked((int)0xC01E0517),
        STATUS_GRAPHICS_OPM_ALL_HDCP_HARDWARE_ALREADY_IN_USE = unchecked((int)0xC01E0518),
        STATUS_GRAPHICS_OPM_PROTECTED_OUTPUT_NO_LONGER_EXISTS = unchecked((int)0xC01E051A),
        STATUS_GRAPHICS_OPM_PROTECTED_OUTPUT_DOES_NOT_HAVE_COPP_SEMANTICS = unchecked((int)0xC01E051C),
        STATUS_GRAPHICS_OPM_INVALID_INFORMATION_REQUEST = unchecked((int)0xC01E051D),
        STATUS_GRAPHICS_OPM_DRIVER_INTERNAL_ERROR = unchecked((int)0xC01E051E),
        STATUS_GRAPHICS_OPM_PROTECTED_OUTPUT_DOES_NOT_HAVE_OPM_SEMANTICS = unchecked((int)0xC01E051F),
        STATUS_GRAPHICS_OPM_SIGNALING_NOT_SUPPORTED = unchecked((int)0xC01E0520),
        STATUS_GRAPHICS_OPM_INVALID_CONFIGURATION_REQUEST = unchecked((int)0xC01E0521),
        STATUS_GRAPHICS_I2C_NOT_SUPPORTED = unchecked((int)0xC01E0580),
        STATUS_GRAPHICS_I2C_DEVICE_DOES_NOT_EXIST = unchecked((int)0xC01E0581),
        STATUS_GRAPHICS_I2C_ERROR_TRANSMITTING_DATA = unchecked((int)0xC01E0582),
        STATUS_GRAPHICS_I2C_ERROR_RECEIVING_DATA = unchecked((int)0xC01E0583),
        STATUS_GRAPHICS_DDCCI_VCP_NOT_SUPPORTED = unchecked((int)0xC01E0584),
        STATUS_GRAPHICS_DDCCI_INVALID_DATA = unchecked((int)0xC01E0585),
        STATUS_GRAPHICS_DDCCI_MONITOR_RETURNED_INVALID_TIMING_STATUS_BYTE = unchecked((int)0xC01E0586),
        STATUS_GRAPHICS_DDCCI_INVALID_CAPABILITIES_STRING = unchecked((int)0xC01E0587),
        STATUS_GRAPHICS_MCA_INTERNAL_ERROR = unchecked((int)0xC01E0588),
        STATUS_GRAPHICS_DDCCI_INVALID_MESSAGE_COMMAND = unchecked((int)0xC01E0589),
        STATUS_GRAPHICS_DDCCI_INVALID_MESSAGE_LENGTH = unchecked((int)0xC01E058A),
        STATUS_GRAPHICS_DDCCI_INVALID_MESSAGE_CHECKSUM = unchecked((int)0xC01E058B),
        STATUS_GRAPHICS_INVALID_PHYSICAL_MONITOR_HANDLE = unchecked((int)0xC01E058C),
        STATUS_GRAPHICS_MONITOR_NO_LONGER_EXISTS = unchecked((int)0xC01E058D),
        STATUS_GRAPHICS_ONLY_CONSOLE_SESSION_SUPPORTED = unchecked((int)0xC01E05E0),
        STATUS_GRAPHICS_NO_DISPLAY_DEVICE_CORRESPONDS_TO_NAME = unchecked((int)0xC01E05E1),
        STATUS_GRAPHICS_DISPLAY_DEVICE_NOT_ATTACHED_TO_DESKTOP = unchecked((int)0xC01E05E2),
        STATUS_GRAPHICS_MIRRORING_DEVICES_NOT_SUPPORTED = unchecked((int)0xC01E05E3),
        STATUS_GRAPHICS_INVALID_POINTER = unchecked((int)0xC01E05E4),
        STATUS_GRAPHICS_NO_MONITORS_CORRESPOND_TO_DISPLAY_DEVICE = unchecked((int)0xC01E05E5),
        STATUS_GRAPHICS_PARAMETER_ARRAY_TOO_SMALL = unchecked((int)0xC01E05E6),
        STATUS_GRAPHICS_INTERNAL_ERROR = unchecked((int)0xC01E05E7),
        STATUS_GRAPHICS_SESSION_TYPE_CHANGE_IN_PROGRESS = unchecked((int)0xC01E05E8),
        STATUS_FVE_LOCKED_VOLUME = unchecked((int)0xC0210000),
        STATUS_FVE_NOT_ENCRYPTED = unchecked((int)0xC0210001),
        STATUS_FVE_BAD_INFORMATION = unchecked((int)0xC0210002),
        STATUS_FVE_TOO_SMALL = unchecked((int)0xC0210003),
        STATUS_FVE_FAILED_WRONG_FS = unchecked((int)0xC0210004),
        STATUS_FVE_BAD_PARTITION_SIZE = unchecked((int)0xC0210005),
        STATUS_FVE_FS_NOT_EXTENDED = unchecked((int)0xC0210006),
        STATUS_FVE_FS_MOUNTED = unchecked((int)0xC0210007),
        STATUS_FVE_NO_LICENSE = unchecked((int)0xC0210008),
        STATUS_FVE_ACTION_NOT_ALLOWED = unchecked((int)0xC0210009),
        STATUS_FVE_BAD_DATA = unchecked((int)0xC021000A),
        STATUS_FVE_VOLUME_NOT_BOUND = unchecked((int)0xC021000B),
        STATUS_FVE_NOT_DATA_VOLUME = unchecked((int)0xC021000C),
        STATUS_FVE_CONV_READ_ERROR = unchecked((int)0xC021000D),
        STATUS_FVE_CONV_WRITE_ERROR = unchecked((int)0xC021000E),
        STATUS_FVE_OVERLAPPED_UPDATE = unchecked((int)0xC021000F),
        STATUS_FVE_FAILED_SECTOR_SIZE = unchecked((int)0xC0210010),
        STATUS_FVE_FAILED_AUTHENTICATION = unchecked((int)0xC0210011),
        STATUS_FVE_NOT_OS_VOLUME = unchecked((int)0xC0210012),
        STATUS_FVE_KEYFILE_NOT_FOUND = unchecked((int)0xC0210013),
        STATUS_FVE_KEYFILE_INVALID = unchecked((int)0xC0210014),
        STATUS_FVE_KEYFILE_NO_VMK = unchecked((int)0xC0210015),
        STATUS_FVE_TPM_DISABLED = unchecked((int)0xC0210016),
        STATUS_FVE_TPM_SRK_AUTH_NOT_ZERO = unchecked((int)0xC0210017),
        STATUS_FVE_TPM_INVALID_PCR = unchecked((int)0xC0210018),
        STATUS_FVE_TPM_NO_VMK = unchecked((int)0xC0210019),
        STATUS_FVE_PIN_INVALID = unchecked((int)0xC021001A),
        STATUS_FVE_AUTH_INVALID_APPLICATION = unchecked((int)0xC021001B),
        STATUS_FVE_AUTH_INVALID_CONFIG = unchecked((int)0xC021001C),
        STATUS_FVE_DEBUGGER_ENABLED = unchecked((int)0xC021001D),
        STATUS_FVE_DRY_RUN_FAILED = unchecked((int)0xC021001E),
        STATUS_FVE_BAD_METADATA_POINTER = unchecked((int)0xC021001F),
        STATUS_FVE_OLD_METADATA_COPY = unchecked((int)0xC0210020),
        STATUS_FVE_REBOOT_REQUIRED = unchecked((int)0xC0210021),
        STATUS_FVE_RAW_ACCESS = unchecked((int)0xC0210022),
        STATUS_FVE_RAW_BLOCKED = unchecked((int)0xC0210023),
        STATUS_FVE_NO_AUTOUNLOCK_MASTER_KEY = unchecked((int)0xC0210024),
        STATUS_FVE_MOR_FAILED = unchecked((int)0xC0210025),
        STATUS_FVE_NO_FEATURE_LICENSE = unchecked((int)0xC0210026),
        STATUS_FVE_POLICY_USER_DISABLE_RDV_NOT_ALLOWED = unchecked((int)0xC0210027),
        STATUS_FVE_CONV_RECOVERY_FAILED = unchecked((int)0xC0210028),
        STATUS_FVE_VIRTUALIZED_SPACE_TOO_BIG = unchecked((int)0xC0210029),
        STATUS_FVE_INVALID_DATUM_TYPE = unchecked((int)0xC021002A),
        STATUS_FVE_VOLUME_TOO_SMALL = unchecked((int)0xC0210030),
        STATUS_FVE_ENH_PIN_INVALID = unchecked((int)0xC0210031),
        STATUS_FVE_FULL_ENCRYPTION_NOT_ALLOWED_ON_TP_STORAGE = unchecked((int)0xC0210032),
        STATUS_FVE_WIPE_NOT_ALLOWED_ON_TP_STORAGE = unchecked((int)0xC0210033),
        STATUS_FVE_NOT_ALLOWED_ON_CSV_STACK = unchecked((int)0xC0210034),
        STATUS_FVE_NOT_ALLOWED_ON_CLUSTER = unchecked((int)0xC0210035),
        STATUS_FVE_NOT_ALLOWED_TO_UPGRADE_WHILE_CONVERTING = unchecked((int)0xC0210036),
        STATUS_FVE_WIPE_CANCEL_NOT_APPLICABLE = unchecked((int)0xC0210037),
        STATUS_FVE_EDRIVE_DRY_RUN_FAILED = unchecked((int)0xC0210038),
        STATUS_FVE_SECUREBOOT_DISABLED = unchecked((int)0xC0210039),
        STATUS_FVE_SECUREBOOT_CONFIG_CHANGE = unchecked((int)0xC021003A),
        STATUS_FVE_DEVICE_LOCKEDOUT = unchecked((int)0xC021003B),
        STATUS_FVE_VOLUME_EXTEND_PREVENTS_EOW_DECRYPT = unchecked((int)0xC021003C),
        STATUS_FVE_NOT_DE_VOLUME = unchecked((int)0xC021003D),
        STATUS_FVE_PROTECTION_DISABLED = unchecked((int)0xC021003E),
        STATUS_FVE_PROTECTION_CANNOT_BE_DISABLED = unchecked((int)0xC021003F),
        STATUS_FVE_OSV_KSR_NOT_ALLOWED = unchecked((int)0xC0210040),
        STATUS_FVE_EDRIVE_BAND_ENUMERATION_FAILED = unchecked((int)0xC0210041),
        STATUS_FWP_CALLOUT_NOT_FOUND = unchecked((int)0xC0220001),
        STATUS_FWP_CONDITION_NOT_FOUND = unchecked((int)0xC0220002),
        STATUS_FWP_FILTER_NOT_FOUND = unchecked((int)0xC0220003),
        STATUS_FWP_LAYER_NOT_FOUND = unchecked((int)0xC0220004),
        STATUS_FWP_PROVIDER_NOT_FOUND = unchecked((int)0xC0220005),
        STATUS_FWP_PROVIDER_CONTEXT_NOT_FOUND = unchecked((int)0xC0220006),
        STATUS_FWP_SUBLAYER_NOT_FOUND = unchecked((int)0xC0220007),
        STATUS_FWP_NOT_FOUND = unchecked((int)0xC0220008),
        STATUS_FWP_ALREADY_EXISTS = unchecked((int)0xC0220009),
        STATUS_FWP_IN_USE = unchecked((int)0xC022000A),
        STATUS_FWP_DYNAMIC_SESSION_IN_PROGRESS = unchecked((int)0xC022000B),
        STATUS_FWP_WRONG_SESSION = unchecked((int)0xC022000C),
        STATUS_FWP_NO_TXN_IN_PROGRESS = unchecked((int)0xC022000D),
        STATUS_FWP_TXN_IN_PROGRESS = unchecked((int)0xC022000E),
        STATUS_FWP_TXN_ABORTED = unchecked((int)0xC022000F),
        STATUS_FWP_SESSION_ABORTED = unchecked((int)0xC0220010),
        STATUS_FWP_INCOMPATIBLE_TXN = unchecked((int)0xC0220011),
        STATUS_FWP_TIMEOUT = unchecked((int)0xC0220012),
        STATUS_FWP_NET_EVENTS_DISABLED = unchecked((int)0xC0220013),
        STATUS_FWP_INCOMPATIBLE_LAYER = unchecked((int)0xC0220014),
        STATUS_FWP_KM_CLIENTS_ONLY = unchecked((int)0xC0220015),
        STATUS_FWP_LIFETIME_MISMATCH = unchecked((int)0xC0220016),
        STATUS_FWP_BUILTIN_OBJECT = unchecked((int)0xC0220017),
        STATUS_FWP_TOO_MANY_CALLOUTS = unchecked((int)0xC0220018),
        STATUS_FWP_NOTIFICATION_DROPPED = unchecked((int)0xC0220019),
        STATUS_FWP_TRAFFIC_MISMATCH = unchecked((int)0xC022001A),
        STATUS_FWP_INCOMPATIBLE_SA_STATE = unchecked((int)0xC022001B),
        STATUS_FWP_NULL_POINTER = unchecked((int)0xC022001C),
        STATUS_FWP_INVALID_ENUMERATOR = unchecked((int)0xC022001D),
        STATUS_FWP_INVALID_FLAGS = unchecked((int)0xC022001E),
        STATUS_FWP_INVALID_NET_MASK = unchecked((int)0xC022001F),
        STATUS_FWP_INVALID_RANGE = unchecked((int)0xC0220020),
        STATUS_FWP_INVALID_INTERVAL = unchecked((int)0xC0220021),
        STATUS_FWP_ZERO_LENGTH_ARRAY = unchecked((int)0xC0220022),
        STATUS_FWP_NULL_DISPLAY_NAME = unchecked((int)0xC0220023),
        STATUS_FWP_INVALID_ACTION_TYPE = unchecked((int)0xC0220024),
        STATUS_FWP_INVALID_WEIGHT = unchecked((int)0xC0220025),
        STATUS_FWP_MATCH_TYPE_MISMATCH = unchecked((int)0xC0220026),
        STATUS_FWP_TYPE_MISMATCH = unchecked((int)0xC0220027),
        STATUS_FWP_OUT_OF_BOUNDS = unchecked((int)0xC0220028),
        STATUS_FWP_RESERVED = unchecked((int)0xC0220029),
        STATUS_FWP_DUPLICATE_CONDITION = unchecked((int)0xC022002A),
        STATUS_FWP_DUPLICATE_KEYMOD = unchecked((int)0xC022002B),
        STATUS_FWP_ACTION_INCOMPATIBLE_WITH_LAYER = unchecked((int)0xC022002C),
        STATUS_FWP_ACTION_INCOMPATIBLE_WITH_SUBLAYER = unchecked((int)0xC022002D),
        STATUS_FWP_CONTEXT_INCOMPATIBLE_WITH_LAYER = unchecked((int)0xC022002E),
        STATUS_FWP_CONTEXT_INCOMPATIBLE_WITH_CALLOUT = unchecked((int)0xC022002F),
        STATUS_FWP_INCOMPATIBLE_AUTH_METHOD = unchecked((int)0xC0220030),
        STATUS_FWP_INCOMPATIBLE_DH_GROUP = unchecked((int)0xC0220031),
        STATUS_FWP_EM_NOT_SUPPORTED = unchecked((int)0xC0220032),
        STATUS_FWP_NEVER_MATCH = unchecked((int)0xC0220033),
        STATUS_FWP_PROVIDER_CONTEXT_MISMATCH = unchecked((int)0xC0220034),
        STATUS_FWP_INVALID_PARAMETER = unchecked((int)0xC0220035),
        STATUS_FWP_TOO_MANY_SUBLAYERS = unchecked((int)0xC0220036),
        STATUS_FWP_CALLOUT_NOTIFICATION_FAILED = unchecked((int)0xC0220037),
        STATUS_FWP_INVALID_AUTH_TRANSFORM = unchecked((int)0xC0220038),
        STATUS_FWP_INVALID_CIPHER_TRANSFORM = unchecked((int)0xC0220039),
        STATUS_FWP_INCOMPATIBLE_CIPHER_TRANSFORM = unchecked((int)0xC022003A),
        STATUS_FWP_INVALID_TRANSFORM_COMBINATION = unchecked((int)0xC022003B),
        STATUS_FWP_DUPLICATE_AUTH_METHOD = unchecked((int)0xC022003C),
        STATUS_FWP_INVALID_TUNNEL_ENDPOINT = unchecked((int)0xC022003D),
        STATUS_FWP_L2_DRIVER_NOT_READY = unchecked((int)0xC022003E),
        STATUS_FWP_KEY_DICTATOR_ALREADY_REGISTERED = unchecked((int)0xC022003F),
        STATUS_FWP_KEY_DICTATION_INVALID_KEYING_MATERIAL = unchecked((int)0xC0220040),
        STATUS_FWP_CONNECTIONS_DISABLED = unchecked((int)0xC0220041),
        STATUS_FWP_INVALID_DNS_NAME = unchecked((int)0xC0220042),
        STATUS_FWP_STILL_ON = unchecked((int)0xC0220043),
        STATUS_FWP_IKEEXT_NOT_RUNNING = unchecked((int)0xC0220044),
        STATUS_FWP_TCPIP_NOT_READY = unchecked((int)0xC0220100),
        STATUS_FWP_INJECT_HANDLE_CLOSING = unchecked((int)0xC0220101),
        STATUS_FWP_INJECT_HANDLE_STALE = unchecked((int)0xC0220102),
        STATUS_FWP_CANNOT_PEND = unchecked((int)0xC0220103),
        STATUS_FWP_DROP_NOICMP = unchecked((int)0xC0220104),
        STATUS_NDIS_CLOSING = unchecked((int)0xC0230002),
        STATUS_NDIS_BAD_VERSION = unchecked((int)0xC0230004),
        STATUS_NDIS_BAD_CHARACTERISTICS = unchecked((int)0xC0230005),
        STATUS_NDIS_ADAPTER_NOT_FOUND = unchecked((int)0xC0230006),
        STATUS_NDIS_OPEN_FAILED = unchecked((int)0xC0230007),
        STATUS_NDIS_DEVICE_FAILED = unchecked((int)0xC0230008),
        STATUS_NDIS_MULTICAST_FULL = unchecked((int)0xC0230009),
        STATUS_NDIS_MULTICAST_EXISTS = unchecked((int)0xC023000A),
        STATUS_NDIS_MULTICAST_NOT_FOUND = unchecked((int)0xC023000B),
        STATUS_NDIS_REQUEST_ABORTED = unchecked((int)0xC023000C),
        STATUS_NDIS_RESET_IN_PROGRESS = unchecked((int)0xC023000D),
        STATUS_NDIS_NOT_SUPPORTED = unchecked((int)0xC02300BB),
        STATUS_NDIS_INVALID_PACKET = unchecked((int)0xC023000F),
        STATUS_NDIS_ADAPTER_NOT_READY = unchecked((int)0xC0230011),
        STATUS_NDIS_INVALID_LENGTH = unchecked((int)0xC0230014),
        STATUS_NDIS_INVALID_DATA = unchecked((int)0xC0230015),
        STATUS_NDIS_BUFFER_TOO_SHORT = unchecked((int)0xC0230016),
        STATUS_NDIS_INVALID_OID = unchecked((int)0xC0230017),
        STATUS_NDIS_ADAPTER_REMOVED = unchecked((int)0xC0230018),
        STATUS_NDIS_UNSUPPORTED_MEDIA = unchecked((int)0xC0230019),
        STATUS_NDIS_GROUP_ADDRESS_IN_USE = unchecked((int)0xC023001A),
        STATUS_NDIS_FILE_NOT_FOUND = unchecked((int)0xC023001B),
        STATUS_NDIS_ERROR_READING_FILE = unchecked((int)0xC023001C),
        STATUS_NDIS_ALREADY_MAPPED = unchecked((int)0xC023001D),
        STATUS_NDIS_RESOURCE_CONFLICT = unchecked((int)0xC023001E),
        STATUS_NDIS_MEDIA_DISCONNECTED = unchecked((int)0xC023001F),
        STATUS_NDIS_INVALID_ADDRESS = unchecked((int)0xC0230022),
        STATUS_NDIS_INVALID_DEVICE_REQUEST = unchecked((int)0xC0230010),
        STATUS_NDIS_PAUSED = unchecked((int)0xC023002A),
        STATUS_NDIS_INTERFACE_NOT_FOUND = unchecked((int)0xC023002B),
        STATUS_NDIS_UNSUPPORTED_REVISION = unchecked((int)0xC023002C),
        STATUS_NDIS_INVALID_PORT = unchecked((int)0xC023002D),
        STATUS_NDIS_INVALID_PORT_STATE = unchecked((int)0xC023002E),
        STATUS_NDIS_LOW_POWER_STATE = unchecked((int)0xC023002F),
        STATUS_NDIS_REINIT_REQUIRED = unchecked((int)0xC0230030),
        STATUS_NDIS_NO_QUEUES = unchecked((int)0xC0230031),
        STATUS_NDIS_DOT11_AUTO_CONFIG_ENABLED = unchecked((int)0xC0232000),
        STATUS_NDIS_DOT11_MEDIA_IN_USE = unchecked((int)0xC0232001),
        STATUS_NDIS_DOT11_POWER_STATE_INVALID = unchecked((int)0xC0232002),
        STATUS_NDIS_PM_WOL_PATTERN_LIST_FULL = unchecked((int)0xC0232003),
        STATUS_NDIS_PM_PROTOCOL_OFFLOAD_LIST_FULL = unchecked((int)0xC0232004),
        STATUS_NDIS_DOT11_AP_CHANNEL_CURRENTLY_NOT_AVAILABLE = unchecked((int)0xC0232005),
        STATUS_NDIS_DOT11_AP_BAND_CURRENTLY_NOT_AVAILABLE = unchecked((int)0xC0232006),
        STATUS_NDIS_DOT11_AP_CHANNEL_NOT_ALLOWED = unchecked((int)0xC0232007),
        STATUS_NDIS_DOT11_AP_BAND_NOT_ALLOWED = unchecked((int)0xC0232008),
        STATUS_NDIS_INDICATION_REQUIRED = unchecked((int)0x40230001),
        STATUS_NDIS_OFFLOAD_POLICY = unchecked((int)0xC023100F),
        STATUS_NDIS_OFFLOAD_CONNECTION_REJECTED = unchecked((int)0xC0231012),
        STATUS_NDIS_OFFLOAD_PATH_REJECTED = unchecked((int)0xC0231013),
        STATUS_TPM_ERROR_MASK = unchecked((int)0xC0290000),
        STATUS_TPM_AUTHFAIL = unchecked((int)0xC0290001),
        STATUS_TPM_BADINDEX = unchecked((int)0xC0290002),
        STATUS_TPM_BAD_PARAMETER = unchecked((int)0xC0290003),
        STATUS_TPM_AUDITFAILURE = unchecked((int)0xC0290004),
        STATUS_TPM_CLEAR_DISABLED = unchecked((int)0xC0290005),
        STATUS_TPM_DEACTIVATED = unchecked((int)0xC0290006),
        STATUS_TPM_DISABLED = unchecked((int)0xC0290007),
        STATUS_TPM_DISABLED_CMD = unchecked((int)0xC0290008),
        STATUS_TPM_FAIL = unchecked((int)0xC0290009),
        STATUS_TPM_BAD_ORDINAL = unchecked((int)0xC029000A),
        STATUS_TPM_INSTALL_DISABLED = unchecked((int)0xC029000B),
        STATUS_TPM_INVALID_KEYHANDLE = unchecked((int)0xC029000C),
        STATUS_TPM_KEYNOTFOUND = unchecked((int)0xC029000D),
        STATUS_TPM_INAPPROPRIATE_ENC = unchecked((int)0xC029000E),
        STATUS_TPM_MIGRATEFAIL = unchecked((int)0xC029000F),
        STATUS_TPM_INVALID_PCR_INFO = unchecked((int)0xC0290010),
        STATUS_TPM_NOSPACE = unchecked((int)0xC0290011),
        STATUS_TPM_NOSRK = unchecked((int)0xC0290012),
        STATUS_TPM_NOTSEALED_BLOB = unchecked((int)0xC0290013),
        STATUS_TPM_OWNER_SET = unchecked((int)0xC0290014),
        STATUS_TPM_RESOURCES = unchecked((int)0xC0290015),
        STATUS_TPM_SHORTRANDOM = unchecked((int)0xC0290016),
        STATUS_TPM_SIZE = unchecked((int)0xC0290017),
        STATUS_TPM_WRONGPCRVAL = unchecked((int)0xC0290018),
        STATUS_TPM_BAD_PARAM_SIZE = unchecked((int)0xC0290019),
        STATUS_TPM_SHA_THREAD = unchecked((int)0xC029001A),
        STATUS_TPM_SHA_ERROR = unchecked((int)0xC029001B),
        STATUS_TPM_FAILEDSELFTEST = unchecked((int)0xC029001C),
        STATUS_TPM_AUTH2FAIL = unchecked((int)0xC029001D),
        STATUS_TPM_BADTAG = unchecked((int)0xC029001E),
        STATUS_TPM_IOERROR = unchecked((int)0xC029001F),
        STATUS_TPM_ENCRYPT_ERROR = unchecked((int)0xC0290020),
        STATUS_TPM_DECRYPT_ERROR = unchecked((int)0xC0290021),
        STATUS_TPM_INVALID_AUTHHANDLE = unchecked((int)0xC0290022),
        STATUS_TPM_NO_ENDORSEMENT = unchecked((int)0xC0290023),
        STATUS_TPM_INVALID_KEYUSAGE = unchecked((int)0xC0290024),
        STATUS_TPM_WRONG_ENTITYTYPE = unchecked((int)0xC0290025),
        STATUS_TPM_INVALID_POSTINIT = unchecked((int)0xC0290026),
        STATUS_TPM_INAPPROPRIATE_SIG = unchecked((int)0xC0290027),
        STATUS_TPM_BAD_KEY_PROPERTY = unchecked((int)0xC0290028),
        STATUS_TPM_BAD_MIGRATION = unchecked((int)0xC0290029),
        STATUS_TPM_BAD_SCHEME = unchecked((int)0xC029002A),
        STATUS_TPM_BAD_DATASIZE = unchecked((int)0xC029002B),
        STATUS_TPM_BAD_MODE = unchecked((int)0xC029002C),
        STATUS_TPM_BAD_PRESENCE = unchecked((int)0xC029002D),
        STATUS_TPM_BAD_VERSION = unchecked((int)0xC029002E),
        STATUS_TPM_NO_WRAP_TRANSPORT = unchecked((int)0xC029002F),
        STATUS_TPM_AUDITFAIL_UNSUCCESSFUL = unchecked((int)0xC0290030),
        STATUS_TPM_AUDITFAIL_SUCCESSFUL = unchecked((int)0xC0290031),
        STATUS_TPM_NOTRESETABLE = unchecked((int)0xC0290032),
        STATUS_TPM_NOTLOCAL = unchecked((int)0xC0290033),
        STATUS_TPM_BAD_TYPE = unchecked((int)0xC0290034),
        STATUS_TPM_INVALID_RESOURCE = unchecked((int)0xC0290035),
        STATUS_TPM_NOTFIPS = unchecked((int)0xC0290036),
        STATUS_TPM_INVALID_FAMILY = unchecked((int)0xC0290037),
        STATUS_TPM_NO_NV_PERMISSION = unchecked((int)0xC0290038),
        STATUS_TPM_REQUIRES_SIGN = unchecked((int)0xC0290039),
        STATUS_TPM_KEY_NOTSUPPORTED = unchecked((int)0xC029003A),
        STATUS_TPM_AUTH_CONFLICT = unchecked((int)0xC029003B),
        STATUS_TPM_AREA_LOCKED = unchecked((int)0xC029003C),
        STATUS_TPM_BAD_LOCALITY = unchecked((int)0xC029003D),
        STATUS_TPM_READ_ONLY = unchecked((int)0xC029003E),
        STATUS_TPM_PER_NOWRITE = unchecked((int)0xC029003F),
        STATUS_TPM_FAMILYCOUNT = unchecked((int)0xC0290040),
        STATUS_TPM_WRITE_LOCKED = unchecked((int)0xC0290041),
        STATUS_TPM_BAD_ATTRIBUTES = unchecked((int)0xC0290042),
        STATUS_TPM_INVALID_STRUCTURE = unchecked((int)0xC0290043),
        STATUS_TPM_KEY_OWNER_CONTROL = unchecked((int)0xC0290044),
        STATUS_TPM_BAD_COUNTER = unchecked((int)0xC0290045),
        STATUS_TPM_NOT_FULLWRITE = unchecked((int)0xC0290046),
        STATUS_TPM_CONTEXT_GAP = unchecked((int)0xC0290047),
        STATUS_TPM_MAXNVWRITES = unchecked((int)0xC0290048),
        STATUS_TPM_NOOPERATOR = unchecked((int)0xC0290049),
        STATUS_TPM_RESOURCEMISSING = unchecked((int)0xC029004A),
        STATUS_TPM_DELEGATE_LOCK = unchecked((int)0xC029004B),
        STATUS_TPM_DELEGATE_FAMILY = unchecked((int)0xC029004C),
        STATUS_TPM_DELEGATE_ADMIN = unchecked((int)0xC029004D),
        STATUS_TPM_TRANSPORT_NOTEXCLUSIVE = unchecked((int)0xC029004E),
        STATUS_TPM_OWNER_CONTROL = unchecked((int)0xC029004F),
        STATUS_TPM_DAA_RESOURCES = unchecked((int)0xC0290050),
        STATUS_TPM_DAA_INPUT_DATA0 = unchecked((int)0xC0290051),
        STATUS_TPM_DAA_INPUT_DATA1 = unchecked((int)0xC0290052),
        STATUS_TPM_DAA_ISSUER_SETTINGS = unchecked((int)0xC0290053),
        STATUS_TPM_DAA_TPM_SETTINGS = unchecked((int)0xC0290054),
        STATUS_TPM_DAA_STAGE = unchecked((int)0xC0290055),
        STATUS_TPM_DAA_ISSUER_VALIDITY = unchecked((int)0xC0290056),
        STATUS_TPM_DAA_WRONG_W = unchecked((int)0xC0290057),
        STATUS_TPM_BAD_HANDLE = unchecked((int)0xC0290058),
        STATUS_TPM_BAD_DELEGATE = unchecked((int)0xC0290059),
        STATUS_TPM_BADCONTEXT = unchecked((int)0xC029005A),
        STATUS_TPM_TOOMANYCONTEXTS = unchecked((int)0xC029005B),
        STATUS_TPM_MA_TICKET_SIGNATURE = unchecked((int)0xC029005C),
        STATUS_TPM_MA_DESTINATION = unchecked((int)0xC029005D),
        STATUS_TPM_MA_SOURCE = unchecked((int)0xC029005E),
        STATUS_TPM_MA_AUTHORITY = unchecked((int)0xC029005F),
        STATUS_TPM_PERMANENTEK = unchecked((int)0xC0290061),
        STATUS_TPM_BAD_SIGNATURE = unchecked((int)0xC0290062),
        STATUS_TPM_NOCONTEXTSPACE = unchecked((int)0xC0290063),
        STATUS_TPM_20_E_ASYMMETRIC = unchecked((int)0xC0290081),
        STATUS_TPM_20_E_ATTRIBUTES = unchecked((int)0xC0290082),
        STATUS_TPM_20_E_HASH = unchecked((int)0xC0290083),
        STATUS_TPM_20_E_VALUE = unchecked((int)0xC0290084),
        STATUS_TPM_20_E_HIERARCHY = unchecked((int)0xC0290085),
        STATUS_TPM_20_E_KEY_SIZE = unchecked((int)0xC0290087),
        STATUS_TPM_20_E_MGF = unchecked((int)0xC0290088),
        STATUS_TPM_20_E_MODE = unchecked((int)0xC0290089),
        STATUS_TPM_20_E_TYPE = unchecked((int)0xC029008A),
        STATUS_TPM_20_E_HANDLE = unchecked((int)0xC029008B),
        STATUS_TPM_20_E_KDF = unchecked((int)0xC029008C),
        STATUS_TPM_20_E_RANGE = unchecked((int)0xC029008D),
        STATUS_TPM_20_E_AUTH_FAIL = unchecked((int)0xC029008E),
        STATUS_TPM_20_E_NONCE = unchecked((int)0xC029008F),
        STATUS_TPM_20_E_PP = unchecked((int)0xC0290090),
        STATUS_TPM_20_E_SCHEME = unchecked((int)0xC0290092),
        STATUS_TPM_20_E_SIZE = unchecked((int)0xC0290095),
        STATUS_TPM_20_E_SYMMETRIC = unchecked((int)0xC0290096),
        STATUS_TPM_20_E_TAG = unchecked((int)0xC0290097),
        STATUS_TPM_20_E_SELECTOR = unchecked((int)0xC0290098),
        STATUS_TPM_20_E_INSUFFICIENT = unchecked((int)0xC029009A),
        STATUS_TPM_20_E_SIGNATURE = unchecked((int)0xC029009B),
        STATUS_TPM_20_E_KEY = unchecked((int)0xC029009C),
        STATUS_TPM_20_E_POLICY_FAIL = unchecked((int)0xC029009D),
        STATUS_TPM_20_E_INTEGRITY = unchecked((int)0xC029009F),
        STATUS_TPM_20_E_TICKET = unchecked((int)0xC02900A0),
        STATUS_TPM_20_E_RESERVED_BITS = unchecked((int)0xC02900A1),
        STATUS_TPM_20_E_BAD_AUTH = unchecked((int)0xC02900A2),
        STATUS_TPM_20_E_EXPIRED = unchecked((int)0xC02900A3),
        STATUS_TPM_20_E_POLICY_CC = unchecked((int)0xC02900A4),
        STATUS_TPM_20_E_BINDING = unchecked((int)0xC02900A5),
        STATUS_TPM_20_E_CURVE = unchecked((int)0xC02900A6),
        STATUS_TPM_20_E_ECC_POINT = unchecked((int)0xC02900A7),
        STATUS_TPM_20_E_INITIALIZE = unchecked((int)0xC0290100),
        STATUS_TPM_20_E_FAILURE = unchecked((int)0xC0290101),
        STATUS_TPM_20_E_SEQUENCE = unchecked((int)0xC0290103),
        STATUS_TPM_20_E_PRIVATE = unchecked((int)0xC029010B),
        STATUS_TPM_20_E_HMAC = unchecked((int)0xC0290119),
        STATUS_TPM_20_E_DISABLED = unchecked((int)0xC0290120),
        STATUS_TPM_20_E_EXCLUSIVE = unchecked((int)0xC0290121),
        STATUS_TPM_20_E_ECC_CURVE = unchecked((int)0xC0290123),
        STATUS_TPM_20_E_AUTH_TYPE = unchecked((int)0xC0290124),
        STATUS_TPM_20_E_AUTH_MISSING = unchecked((int)0xC0290125),
        STATUS_TPM_20_E_POLICY = unchecked((int)0xC0290126),
        STATUS_TPM_20_E_PCR = unchecked((int)0xC0290127),
        STATUS_TPM_20_E_PCR_CHANGED = unchecked((int)0xC0290128),
        STATUS_TPM_20_E_UPGRADE = unchecked((int)0xC029012D),
        STATUS_TPM_20_E_TOO_MANY_CONTEXTS = unchecked((int)0xC029012E),
        STATUS_TPM_20_E_AUTH_UNAVAILABLE = unchecked((int)0xC029012F),
        STATUS_TPM_20_E_REBOOT = unchecked((int)0xC0290130),
        STATUS_TPM_20_E_UNBALANCED = unchecked((int)0xC0290131),
        STATUS_TPM_20_E_COMMAND_SIZE = unchecked((int)0xC0290142),
        STATUS_TPM_20_E_COMMAND_CODE = unchecked((int)0xC0290143),
        STATUS_TPM_20_E_AUTHSIZE = unchecked((int)0xC0290144),
        STATUS_TPM_20_E_AUTH_CONTEXT = unchecked((int)0xC0290145),
        STATUS_TPM_20_E_NV_RANGE = unchecked((int)0xC0290146),
        STATUS_TPM_20_E_NV_SIZE = unchecked((int)0xC0290147),
        STATUS_TPM_20_E_NV_LOCKED = unchecked((int)0xC0290148),
        STATUS_TPM_20_E_NV_AUTHORIZATION = unchecked((int)0xC0290149),
        STATUS_TPM_20_E_NV_UNINITIALIZED = unchecked((int)0xC029014A),
        STATUS_TPM_20_E_NV_SPACE = unchecked((int)0xC029014B),
        STATUS_TPM_20_E_NV_DEFINED = unchecked((int)0xC029014C),
        STATUS_TPM_20_E_BAD_CONTEXT = unchecked((int)0xC0290150),
        STATUS_TPM_20_E_CPHASH = unchecked((int)0xC0290151),
        STATUS_TPM_20_E_PARENT = unchecked((int)0xC0290152),
        STATUS_TPM_20_E_NEEDS_TEST = unchecked((int)0xC0290153),
        STATUS_TPM_20_E_NO_RESULT = unchecked((int)0xC0290154),
        STATUS_TPM_20_E_SENSITIVE = unchecked((int)0xC0290155),
        STATUS_TPM_COMMAND_BLOCKED = unchecked((int)0xC0290400),
        STATUS_TPM_INVALID_HANDLE = unchecked((int)0xC0290401),
        STATUS_TPM_DUPLICATE_VHANDLE = unchecked((int)0xC0290402),
        STATUS_TPM_EMBEDDED_COMMAND_BLOCKED = unchecked((int)0xC0290403),
        STATUS_TPM_EMBEDDED_COMMAND_UNSUPPORTED = unchecked((int)0xC0290404),
        STATUS_TPM_RETRY = unchecked((int)0xC0290800),
        STATUS_TPM_NEEDS_SELFTEST = unchecked((int)0xC0290801),
        STATUS_TPM_DOING_SELFTEST = unchecked((int)0xC0290802),
        STATUS_TPM_DEFEND_LOCK_RUNNING = unchecked((int)0xC0290803),
        STATUS_TPM_COMMAND_CANCELED = unchecked((int)0xC0291001),
        STATUS_TPM_TOO_MANY_CONTEXTS = unchecked((int)0xC0291002),
        STATUS_TPM_NOT_FOUND = unchecked((int)0xC0291003),
        STATUS_TPM_ACCESS_DENIED = unchecked((int)0xC0291004),
        STATUS_TPM_INSUFFICIENT_BUFFER = unchecked((int)0xC0291005),
        STATUS_TPM_PPI_FUNCTION_UNSUPPORTED = unchecked((int)0xC0291006),
        STATUS_PCP_ERROR_MASK = unchecked((int)0xC0292000),
        STATUS_PCP_DEVICE_NOT_READY = unchecked((int)0xC0292001),
        STATUS_PCP_INVALID_HANDLE = unchecked((int)0xC0292002),
        STATUS_PCP_INVALID_PARAMETER = unchecked((int)0xC0292003),
        STATUS_PCP_FLAG_NOT_SUPPORTED = unchecked((int)0xC0292004),
        STATUS_PCP_NOT_SUPPORTED = unchecked((int)0xC0292005),
        STATUS_PCP_BUFFER_TOO_SMALL = unchecked((int)0xC0292006),
        STATUS_PCP_INTERNAL_ERROR = unchecked((int)0xC0292007),
        STATUS_PCP_AUTHENTICATION_FAILED = unchecked((int)0xC0292008),
        STATUS_PCP_AUTHENTICATION_IGNORED = unchecked((int)0xC0292009),
        STATUS_PCP_POLICY_NOT_FOUND = unchecked((int)0xC029200A),
        STATUS_PCP_PROFILE_NOT_FOUND = unchecked((int)0xC029200B),
        STATUS_PCP_VALIDATION_FAILED = unchecked((int)0xC029200C),
        STATUS_PCP_DEVICE_NOT_FOUND = unchecked((int)0xC029200D),
        STATUS_PCP_WRONG_PARENT = unchecked((int)0xC029200E),
        STATUS_PCP_KEY_NOT_LOADED = unchecked((int)0xC029200F),
        STATUS_PCP_NO_KEY_CERTIFICATION = unchecked((int)0xC0292010),
        STATUS_PCP_KEY_NOT_FINALIZED = unchecked((int)0xC0292011),
        STATUS_PCP_ATTESTATION_CHALLENGE_NOT_SET = unchecked((int)0xC0292012),
        STATUS_PCP_NOT_PCR_BOUND = unchecked((int)0xC0292013),
        STATUS_PCP_KEY_ALREADY_FINALIZED = unchecked((int)0xC0292014),
        STATUS_PCP_KEY_USAGE_POLICY_NOT_SUPPORTED = unchecked((int)0xC0292015),
        STATUS_PCP_KEY_USAGE_POLICY_INVALID = unchecked((int)0xC0292016),
        STATUS_PCP_SOFT_KEY_ERROR = unchecked((int)0xC0292017),
        STATUS_PCP_KEY_NOT_AUTHENTICATED = unchecked((int)0xC0292018),
        STATUS_PCP_KEY_NOT_AIK = unchecked((int)0xC0292019),
        STATUS_PCP_KEY_NOT_SIGNING_KEY = unchecked((int)0xC029201A),
        STATUS_PCP_LOCKED_OUT = unchecked((int)0xC029201B),
        STATUS_PCP_CLAIM_TYPE_NOT_SUPPORTED = unchecked((int)0xC029201C),
        STATUS_PCP_TPM_VERSION_NOT_SUPPORTED = unchecked((int)0xC029201D),
        STATUS_PCP_BUFFER_LENGTH_MISMATCH = unchecked((int)0xC029201E),
        STATUS_PCP_IFX_RSA_KEY_CREATION_BLOCKED = unchecked((int)0xC029201F),
        STATUS_PCP_TICKET_MISSING = unchecked((int)0xC0292020),
        STATUS_PCP_RAW_POLICY_NOT_SUPPORTED = unchecked((int)0xC0292021),
        STATUS_PCP_KEY_HANDLE_INVALIDATED = unchecked((int)0xC0292022),
        STATUS_PCP_UNSUPPORTED_PSS_SALT = unchecked((int)0x40292023),
        STATUS_RTPM_CONTEXT_CONTINUE = unchecked((int)0x00293000),
        STATUS_RTPM_CONTEXT_COMPLETE = unchecked((int)0x00293001),
        STATUS_RTPM_NO_RESULT = unchecked((int)0xC0293002),
        STATUS_RTPM_PCR_READ_INCOMPLETE = unchecked((int)0xC0293003),
        STATUS_RTPM_INVALID_CONTEXT = unchecked((int)0xC0293004),
        STATUS_RTPM_UNSUPPORTED_CMD = unchecked((int)0xC0293005),
        STATUS_TPM_ZERO_EXHAUST_ENABLED = unchecked((int)0xC0294000),
        STATUS_HV_INVALID_HYPERCALL_CODE = unchecked((int)0xC0350002),
        STATUS_HV_INVALID_HYPERCALL_INPUT = unchecked((int)0xC0350003),
        STATUS_HV_INVALID_ALIGNMENT = unchecked((int)0xC0350004),
        STATUS_HV_INVALID_PARAMETER = unchecked((int)0xC0350005),
        STATUS_HV_ACCESS_DENIED = unchecked((int)0xC0350006),
        STATUS_HV_INVALID_PARTITION_STATE = unchecked((int)0xC0350007),
        STATUS_HV_OPERATION_DENIED = unchecked((int)0xC0350008),
        STATUS_HV_UNKNOWN_PROPERTY = unchecked((int)0xC0350009),
        STATUS_HV_PROPERTY_VALUE_OUT_OF_RANGE = unchecked((int)0xC035000A),
        STATUS_HV_INSUFFICIENT_MEMORY = unchecked((int)0xC035000B),
        STATUS_HV_PARTITION_TOO_DEEP = unchecked((int)0xC035000C),
        STATUS_HV_INVALID_PARTITION_ID = unchecked((int)0xC035000D),
        STATUS_HV_INVALID_VP_INDEX = unchecked((int)0xC035000E),
        STATUS_HV_INVALID_PORT_ID = unchecked((int)0xC0350011),
        STATUS_HV_INVALID_CONNECTION_ID = unchecked((int)0xC0350012),
        STATUS_HV_INSUFFICIENT_BUFFERS = unchecked((int)0xC0350013),
        STATUS_HV_NOT_ACKNOWLEDGED = unchecked((int)0xC0350014),
        STATUS_HV_INVALID_VP_STATE = unchecked((int)0xC0350015),
        STATUS_HV_ACKNOWLEDGED = unchecked((int)0xC0350016),
        STATUS_HV_INVALID_SAVE_RESTORE_STATE = unchecked((int)0xC0350017),
        STATUS_HV_INVALID_SYNIC_STATE = unchecked((int)0xC0350018),
        STATUS_HV_OBJECT_IN_USE = unchecked((int)0xC0350019),
        STATUS_HV_INVALID_PROXIMITY_DOMAIN_INFO = unchecked((int)0xC035001A),
        STATUS_HV_NO_DATA = unchecked((int)0xC035001B),
        STATUS_HV_INACTIVE = unchecked((int)0xC035001C),
        STATUS_HV_NO_RESOURCES = unchecked((int)0xC035001D),
        STATUS_HV_FEATURE_UNAVAILABLE = unchecked((int)0xC035001E),
        STATUS_HV_INSUFFICIENT_BUFFER = unchecked((int)0xC0350033),
        STATUS_HV_INSUFFICIENT_DEVICE_DOMAINS = unchecked((int)0xC0350038),
        STATUS_HV_CPUID_FEATURE_VALIDATION_ERROR = unchecked((int)0xC035003C),
        STATUS_HV_CPUID_XSAVE_FEATURE_VALIDATION_ERROR = unchecked((int)0xC035003D),
        STATUS_HV_PROCESSOR_STARTUP_TIMEOUT = unchecked((int)0xC035003E),
        STATUS_HV_SMX_ENABLED = unchecked((int)0xC035003F),
        STATUS_HV_INVALID_LP_INDEX = unchecked((int)0xC0350041),
        STATUS_HV_INVALID_REGISTER_VALUE = unchecked((int)0xC0350050),
        STATUS_HV_INVALID_VTL_STATE = unchecked((int)0xC0350051),
        STATUS_HV_NX_NOT_DETECTED = unchecked((int)0xC0350055),
        STATUS_HV_INVALID_DEVICE_ID = unchecked((int)0xC0350057),
        STATUS_HV_INVALID_DEVICE_STATE = unchecked((int)0xC0350058),
        STATUS_HV_PENDING_PAGE_REQUESTS = unchecked((int)0x00350059),
        STATUS_HV_PAGE_REQUEST_INVALID = unchecked((int)0xC0350060),
        STATUS_HV_INVALID_CPU_GROUP_ID = unchecked((int)0xC035006F),
        STATUS_HV_INVALID_CPU_GROUP_STATE = unchecked((int)0xC0350070),
        STATUS_HV_OPERATION_FAILED = unchecked((int)0xC0350071),
        STATUS_HV_NOT_ALLOWED_WITH_NESTED_VIRT_ACTIVE = unchecked((int)0xC0350072),
        STATUS_HV_INSUFFICIENT_ROOT_MEMORY = unchecked((int)0xC0350073),
        STATUS_HV_EVENT_BUFFER_ALREADY_FREED = unchecked((int)0xC0350074),
        STATUS_HV_INSUFFICIENT_CONTIGUOUS_MEMORY = unchecked((int)0xC0350075),
        STATUS_HV_DEVICE_NOT_IN_DOMAIN = unchecked((int)0xC0350076),
        STATUS_HV_NESTED_VM_EXIT = unchecked((int)0xC0350077),
        STATUS_HV_CALL_PENDING = unchecked((int)0xC0350079),
        STATUS_HV_MSR_ACCESS_FAILED = unchecked((int)0xC0350080),
        STATUS_HV_NOT_PRESENT = unchecked((int)0xC0351000),
        STATUS_VID_DUPLICATE_HANDLER = unchecked((int)0xC0370001),
        STATUS_VID_TOO_MANY_HANDLERS = unchecked((int)0xC0370002),
        STATUS_VID_QUEUE_FULL = unchecked((int)0xC0370003),
        STATUS_VID_HANDLER_NOT_PRESENT = unchecked((int)0xC0370004),
        STATUS_VID_INVALID_OBJECT_NAME = unchecked((int)0xC0370005),
        STATUS_VID_PARTITION_NAME_TOO_LONG = unchecked((int)0xC0370006),
        STATUS_VID_MESSAGE_QUEUE_NAME_TOO_LONG = unchecked((int)0xC0370007),
        STATUS_VID_PARTITION_ALREADY_EXISTS = unchecked((int)0xC0370008),
        STATUS_VID_PARTITION_DOES_NOT_EXIST = unchecked((int)0xC0370009),
        STATUS_VID_PARTITION_NAME_NOT_FOUND = unchecked((int)0xC037000A),
        STATUS_VID_MESSAGE_QUEUE_ALREADY_EXISTS = unchecked((int)0xC037000B),
        STATUS_VID_EXCEEDED_MBP_ENTRY_MAP_LIMIT = unchecked((int)0xC037000C),
        STATUS_VID_MB_STILL_REFERENCED = unchecked((int)0xC037000D),
        STATUS_VID_CHILD_GPA_PAGE_SET_CORRUPTED = unchecked((int)0xC037000E),
        STATUS_VID_INVALID_NUMA_SETTINGS = unchecked((int)0xC037000F),
        STATUS_VID_INVALID_NUMA_NODE_INDEX = unchecked((int)0xC0370010),
        STATUS_VID_NOTIFICATION_QUEUE_ALREADY_ASSOCIATED = unchecked((int)0xC0370011),
        STATUS_VID_INVALID_MEMORY_BLOCK_HANDLE = unchecked((int)0xC0370012),
        STATUS_VID_PAGE_RANGE_OVERFLOW = unchecked((int)0xC0370013),
        STATUS_VID_INVALID_MESSAGE_QUEUE_HANDLE = unchecked((int)0xC0370014),
        STATUS_VID_INVALID_GPA_RANGE_HANDLE = unchecked((int)0xC0370015),
        STATUS_VID_NO_MEMORY_BLOCK_NOTIFICATION_QUEUE = unchecked((int)0xC0370016),
        STATUS_VID_MEMORY_BLOCK_LOCK_COUNT_EXCEEDED = unchecked((int)0xC0370017),
        STATUS_VID_INVALID_PPM_HANDLE = unchecked((int)0xC0370018),
        STATUS_VID_MBPS_ARE_LOCKED = unchecked((int)0xC0370019),
        STATUS_VID_MESSAGE_QUEUE_CLOSED = unchecked((int)0xC037001A),
        STATUS_VID_VIRTUAL_PROCESSOR_LIMIT_EXCEEDED = unchecked((int)0xC037001B),
        STATUS_VID_STOP_PENDING = unchecked((int)0xC037001C),
        STATUS_VID_INVALID_PROCESSOR_STATE = unchecked((int)0xC037001D),
        STATUS_VID_EXCEEDED_KM_CONTEXT_COUNT_LIMIT = unchecked((int)0xC037001E),
        STATUS_VID_KM_INTERFACE_ALREADY_INITIALIZED = unchecked((int)0xC037001F),
        STATUS_VID_MB_PROPERTY_ALREADY_SET_RESET = unchecked((int)0xC0370020),
        STATUS_VID_MMIO_RANGE_DESTROYED = unchecked((int)0xC0370021),
        STATUS_VID_INVALID_CHILD_GPA_PAGE_SET = unchecked((int)0xC0370022),
        STATUS_VID_RESERVE_PAGE_SET_IS_BEING_USED = unchecked((int)0xC0370023),
        STATUS_VID_RESERVE_PAGE_SET_TOO_SMALL = unchecked((int)0xC0370024),
        STATUS_VID_MBP_ALREADY_LOCKED_USING_RESERVED_PAGE = unchecked((int)0xC0370025),
        STATUS_VID_MBP_COUNT_EXCEEDED_LIMIT = unchecked((int)0xC0370026),
        STATUS_VID_SAVED_STATE_CORRUPT = unchecked((int)0xC0370027),
        STATUS_VID_SAVED_STATE_UNRECOGNIZED_ITEM = unchecked((int)0xC0370028),
        STATUS_VID_SAVED_STATE_INCOMPATIBLE = unchecked((int)0xC0370029),
        STATUS_VID_VTL_ACCESS_DENIED = unchecked((int)0xC037002A),
        STATUS_VID_REMOTE_NODE_PARENT_GPA_PAGES_USED = unchecked((int)0x80370001),
        STATUS_IPSEC_BAD_SPI = unchecked((int)0xC0360001),
        STATUS_IPSEC_SA_LIFETIME_EXPIRED = unchecked((int)0xC0360002),
        STATUS_IPSEC_WRONG_SA = unchecked((int)0xC0360003),
        STATUS_IPSEC_REPLAY_CHECK_FAILED = unchecked((int)0xC0360004),
        STATUS_IPSEC_INVALID_PACKET = unchecked((int)0xC0360005),
        STATUS_IPSEC_INTEGRITY_CHECK_FAILED = unchecked((int)0xC0360006),
        STATUS_IPSEC_CLEAR_TEXT_DROP = unchecked((int)0xC0360007),
        STATUS_IPSEC_AUTH_FIREWALL_DROP = unchecked((int)0xC0360008),
        STATUS_IPSEC_THROTTLE_DROP = unchecked((int)0xC0360009),
        STATUS_IPSEC_DOSP_BLOCK = unchecked((int)0xC0368000),
        STATUS_IPSEC_DOSP_RECEIVED_MULTICAST = unchecked((int)0xC0368001),
        STATUS_IPSEC_DOSP_INVALID_PACKET = unchecked((int)0xC0368002),
        STATUS_IPSEC_DOSP_STATE_LOOKUP_FAILED = unchecked((int)0xC0368003),
        STATUS_IPSEC_DOSP_MAX_ENTRIES = unchecked((int)0xC0368004),
        STATUS_IPSEC_DOSP_KEYMOD_NOT_ALLOWED = unchecked((int)0xC0368005),
        STATUS_IPSEC_DOSP_MAX_PER_IP_RATELIMIT_QUEUES = unchecked((int)0xC0368006),
        STATUS_VOLMGR_INCOMPLETE_REGENERATION = unchecked((int)0x80380001),
        STATUS_VOLMGR_INCOMPLETE_DISK_MIGRATION = unchecked((int)0x80380002),
        STATUS_VOLMGR_DATABASE_FULL = unchecked((int)0xC0380001),
        STATUS_VOLMGR_DISK_CONFIGURATION_CORRUPTED = unchecked((int)0xC0380002),
        STATUS_VOLMGR_DISK_CONFIGURATION_NOT_IN_SYNC = unchecked((int)0xC0380003),
        STATUS_VOLMGR_PACK_CONFIG_UPDATE_FAILED = unchecked((int)0xC0380004),
        STATUS_VOLMGR_DISK_CONTAINS_NON_SIMPLE_VOLUME = unchecked((int)0xC0380005),
        STATUS_VOLMGR_DISK_DUPLICATE = unchecked((int)0xC0380006),
        STATUS_VOLMGR_DISK_DYNAMIC = unchecked((int)0xC0380007),
        STATUS_VOLMGR_DISK_ID_INVALID = unchecked((int)0xC0380008),
        STATUS_VOLMGR_DISK_INVALID = unchecked((int)0xC0380009),
        STATUS_VOLMGR_DISK_LAST_VOTER = unchecked((int)0xC038000A),
        STATUS_VOLMGR_DISK_LAYOUT_INVALID = unchecked((int)0xC038000B),
        STATUS_VOLMGR_DISK_LAYOUT_NON_BASIC_BETWEEN_BASIC_PARTITIONS = unchecked((int)0xC038000C),
        STATUS_VOLMGR_DISK_LAYOUT_NOT_CYLINDER_ALIGNED = unchecked((int)0xC038000D),
        STATUS_VOLMGR_DISK_LAYOUT_PARTITIONS_TOO_SMALL = unchecked((int)0xC038000E),
        STATUS_VOLMGR_DISK_LAYOUT_PRIMARY_BETWEEN_LOGICAL_PARTITIONS = unchecked((int)0xC038000F),
        STATUS_VOLMGR_DISK_LAYOUT_TOO_MANY_PARTITIONS = unchecked((int)0xC0380010),
        STATUS_VOLMGR_DISK_MISSING = unchecked((int)0xC0380011),
        STATUS_VOLMGR_DISK_NOT_EMPTY = unchecked((int)0xC0380012),
        STATUS_VOLMGR_DISK_NOT_ENOUGH_SPACE = unchecked((int)0xC0380013),
        STATUS_VOLMGR_DISK_REVECTORING_FAILED = unchecked((int)0xC0380014),
        STATUS_VOLMGR_DISK_SECTOR_SIZE_INVALID = unchecked((int)0xC0380015),
        STATUS_VOLMGR_DISK_SET_NOT_CONTAINED = unchecked((int)0xC0380016),
        STATUS_VOLMGR_DISK_USED_BY_MULTIPLE_MEMBERS = unchecked((int)0xC0380017),
        STATUS_VOLMGR_DISK_USED_BY_MULTIPLE_PLEXES = unchecked((int)0xC0380018),
        STATUS_VOLMGR_DYNAMIC_DISK_NOT_SUPPORTED = unchecked((int)0xC0380019),
        STATUS_VOLMGR_EXTENT_ALREADY_USED = unchecked((int)0xC038001A),
        STATUS_VOLMGR_EXTENT_NOT_CONTIGUOUS = unchecked((int)0xC038001B),
        STATUS_VOLMGR_EXTENT_NOT_IN_PUBLIC_REGION = unchecked((int)0xC038001C),
        STATUS_VOLMGR_EXTENT_NOT_SECTOR_ALIGNED = unchecked((int)0xC038001D),
        STATUS_VOLMGR_EXTENT_OVERLAPS_EBR_PARTITION = unchecked((int)0xC038001E),
        STATUS_VOLMGR_EXTENT_VOLUME_LENGTHS_DO_NOT_MATCH = unchecked((int)0xC038001F),
        STATUS_VOLMGR_FAULT_TOLERANT_NOT_SUPPORTED = unchecked((int)0xC0380020),
        STATUS_VOLMGR_INTERLEAVE_LENGTH_INVALID = unchecked((int)0xC0380021),
        STATUS_VOLMGR_MAXIMUM_REGISTERED_USERS = unchecked((int)0xC0380022),
        STATUS_VOLMGR_MEMBER_IN_SYNC = unchecked((int)0xC0380023),
        STATUS_VOLMGR_MEMBER_INDEX_DUPLICATE = unchecked((int)0xC0380024),
        STATUS_VOLMGR_MEMBER_INDEX_INVALID = unchecked((int)0xC0380025),
        STATUS_VOLMGR_MEMBER_MISSING = unchecked((int)0xC0380026),
        STATUS_VOLMGR_MEMBER_NOT_DETACHED = unchecked((int)0xC0380027),
        STATUS_VOLMGR_MEMBER_REGENERATING = unchecked((int)0xC0380028),
        STATUS_VOLMGR_ALL_DISKS_FAILED = unchecked((int)0xC0380029),
        STATUS_VOLMGR_NO_REGISTERED_USERS = unchecked((int)0xC038002A),
        STATUS_VOLMGR_NO_SUCH_USER = unchecked((int)0xC038002B),
        STATUS_VOLMGR_NOTIFICATION_RESET = unchecked((int)0xC038002C),
        STATUS_VOLMGR_NUMBER_OF_MEMBERS_INVALID = unchecked((int)0xC038002D),
        STATUS_VOLMGR_NUMBER_OF_PLEXES_INVALID = unchecked((int)0xC038002E),
        STATUS_VOLMGR_PACK_DUPLICATE = unchecked((int)0xC038002F),
        STATUS_VOLMGR_PACK_ID_INVALID = unchecked((int)0xC0380030),
        STATUS_VOLMGR_PACK_INVALID = unchecked((int)0xC0380031),
        STATUS_VOLMGR_PACK_NAME_INVALID = unchecked((int)0xC0380032),
        STATUS_VOLMGR_PACK_OFFLINE = unchecked((int)0xC0380033),
        STATUS_VOLMGR_PACK_HAS_QUORUM = unchecked((int)0xC0380034),
        STATUS_VOLMGR_PACK_WITHOUT_QUORUM = unchecked((int)0xC0380035),
        STATUS_VOLMGR_PARTITION_STYLE_INVALID = unchecked((int)0xC0380036),
        STATUS_VOLMGR_PARTITION_UPDATE_FAILED = unchecked((int)0xC0380037),
        STATUS_VOLMGR_PLEX_IN_SYNC = unchecked((int)0xC0380038),
        STATUS_VOLMGR_PLEX_INDEX_DUPLICATE = unchecked((int)0xC0380039),
        STATUS_VOLMGR_PLEX_INDEX_INVALID = unchecked((int)0xC038003A),
        STATUS_VOLMGR_PLEX_LAST_ACTIVE = unchecked((int)0xC038003B),
        STATUS_VOLMGR_PLEX_MISSING = unchecked((int)0xC038003C),
        STATUS_VOLMGR_PLEX_REGENERATING = unchecked((int)0xC038003D),
        STATUS_VOLMGR_PLEX_TYPE_INVALID = unchecked((int)0xC038003E),
        STATUS_VOLMGR_PLEX_NOT_RAID5 = unchecked((int)0xC038003F),
        STATUS_VOLMGR_PLEX_NOT_SIMPLE = unchecked((int)0xC0380040),
        STATUS_VOLMGR_STRUCTURE_SIZE_INVALID = unchecked((int)0xC0380041),
        STATUS_VOLMGR_TOO_MANY_NOTIFICATION_REQUESTS = unchecked((int)0xC0380042),
        STATUS_VOLMGR_TRANSACTION_IN_PROGRESS = unchecked((int)0xC0380043),
        STATUS_VOLMGR_UNEXPECTED_DISK_LAYOUT_CHANGE = unchecked((int)0xC0380044),
        STATUS_VOLMGR_VOLUME_CONTAINS_MISSING_DISK = unchecked((int)0xC0380045),
        STATUS_VOLMGR_VOLUME_ID_INVALID = unchecked((int)0xC0380046),
        STATUS_VOLMGR_VOLUME_LENGTH_INVALID = unchecked((int)0xC0380047),
        STATUS_VOLMGR_VOLUME_LENGTH_NOT_SECTOR_SIZE_MULTIPLE = unchecked((int)0xC0380048),
        STATUS_VOLMGR_VOLUME_NOT_MIRRORED = unchecked((int)0xC0380049),
        STATUS_VOLMGR_VOLUME_NOT_RETAINED = unchecked((int)0xC038004A),
        STATUS_VOLMGR_VOLUME_OFFLINE = unchecked((int)0xC038004B),
        STATUS_VOLMGR_VOLUME_RETAINED = unchecked((int)0xC038004C),
        STATUS_VOLMGR_NUMBER_OF_EXTENTS_INVALID = unchecked((int)0xC038004D),
        STATUS_VOLMGR_DIFFERENT_SECTOR_SIZE = unchecked((int)0xC038004E),
        STATUS_VOLMGR_BAD_BOOT_DISK = unchecked((int)0xC038004F),
        STATUS_VOLMGR_PACK_CONFIG_OFFLINE = unchecked((int)0xC0380050),
        STATUS_VOLMGR_PACK_CONFIG_ONLINE = unchecked((int)0xC0380051),
        STATUS_VOLMGR_NOT_PRIMARY_PACK = unchecked((int)0xC0380052),
        STATUS_VOLMGR_PACK_LOG_UPDATE_FAILED = unchecked((int)0xC0380053),
        STATUS_VOLMGR_NUMBER_OF_DISKS_IN_PLEX_INVALID = unchecked((int)0xC0380054),
        STATUS_VOLMGR_NUMBER_OF_DISKS_IN_MEMBER_INVALID = unchecked((int)0xC0380055),
        STATUS_VOLMGR_VOLUME_MIRRORED = unchecked((int)0xC0380056),
        STATUS_VOLMGR_PLEX_NOT_SIMPLE_SPANNED = unchecked((int)0xC0380057),
        STATUS_VOLMGR_NO_VALID_LOG_COPIES = unchecked((int)0xC0380058),
        STATUS_VOLMGR_PRIMARY_PACK_PRESENT = unchecked((int)0xC0380059),
        STATUS_VOLMGR_NUMBER_OF_DISKS_INVALID = unchecked((int)0xC038005A),
        STATUS_VOLMGR_MIRROR_NOT_SUPPORTED = unchecked((int)0xC038005B),
        STATUS_VOLMGR_RAID5_NOT_SUPPORTED = unchecked((int)0xC038005C),
        STATUS_BCD_NOT_ALL_ENTRIES_IMPORTED = unchecked((int)0x80390001),
        STATUS_BCD_TOO_MANY_ELEMENTS = unchecked((int)0xC0390002),
        STATUS_BCD_NOT_ALL_ENTRIES_SYNCHRONIZED = unchecked((int)0x80390003),
        STATUS_VHD_DRIVE_FOOTER_MISSING = unchecked((int)0xC03A0001),
        STATUS_VHD_DRIVE_FOOTER_CHECKSUM_MISMATCH = unchecked((int)0xC03A0002),
        STATUS_VHD_DRIVE_FOOTER_CORRUPT = unchecked((int)0xC03A0003),
        STATUS_VHD_FORMAT_UNKNOWN = unchecked((int)0xC03A0004),
        STATUS_VHD_FORMAT_UNSUPPORTED_VERSION = unchecked((int)0xC03A0005),
        STATUS_VHD_SPARSE_HEADER_CHECKSUM_MISMATCH = unchecked((int)0xC03A0006),
        STATUS_VHD_SPARSE_HEADER_UNSUPPORTED_VERSION = unchecked((int)0xC03A0007),
        STATUS_VHD_SPARSE_HEADER_CORRUPT = unchecked((int)0xC03A0008),
        STATUS_VHD_BLOCK_ALLOCATION_FAILURE = unchecked((int)0xC03A0009),
        STATUS_VHD_BLOCK_ALLOCATION_TABLE_CORRUPT = unchecked((int)0xC03A000A),
        STATUS_VHD_INVALID_BLOCK_SIZE = unchecked((int)0xC03A000B),
        STATUS_VHD_BITMAP_MISMATCH = unchecked((int)0xC03A000C),
        STATUS_VHD_PARENT_VHD_NOT_FOUND = unchecked((int)0xC03A000D),
        STATUS_VHD_CHILD_PARENT_ID_MISMATCH = unchecked((int)0xC03A000E),
        STATUS_VHD_CHILD_PARENT_TIMESTAMP_MISMATCH = unchecked((int)0xC03A000F),
        STATUS_VHD_METADATA_READ_FAILURE = unchecked((int)0xC03A0010),
        STATUS_VHD_METADATA_WRITE_FAILURE = unchecked((int)0xC03A0011),
        STATUS_VHD_INVALID_SIZE = unchecked((int)0xC03A0012),
        STATUS_VHD_INVALID_FILE_SIZE = unchecked((int)0xC03A0013),
        STATUS_VIRTDISK_PROVIDER_NOT_FOUND = unchecked((int)0xC03A0014),
        STATUS_VIRTDISK_NOT_VIRTUAL_DISK = unchecked((int)0xC03A0015),
        STATUS_VHD_PARENT_VHD_ACCESS_DENIED = unchecked((int)0xC03A0016),
        STATUS_VHD_CHILD_PARENT_SIZE_MISMATCH = unchecked((int)0xC03A0017),
        STATUS_VHD_DIFFERENCING_CHAIN_CYCLE_DETECTED = unchecked((int)0xC03A0018),
        STATUS_VHD_DIFFERENCING_CHAIN_ERROR_IN_PARENT = unchecked((int)0xC03A0019),
        STATUS_VIRTUAL_DISK_LIMITATION = unchecked((int)0xC03A001A),
        STATUS_VHD_INVALID_TYPE = unchecked((int)0xC03A001B),
        STATUS_VHD_INVALID_STATE = unchecked((int)0xC03A001C),
        STATUS_VIRTDISK_UNSUPPORTED_DISK_SECTOR_SIZE = unchecked((int)0xC03A001D),
        STATUS_VIRTDISK_DISK_ALREADY_OWNED = unchecked((int)0xC03A001E),
        STATUS_VIRTDISK_DISK_ONLINE_AND_WRITABLE = unchecked((int)0xC03A001F),
        STATUS_CTLOG_TRACKING_NOT_INITIALIZED = unchecked((int)0xC03A0020),
        STATUS_CTLOG_LOGFILE_SIZE_EXCEEDED_MAXSIZE = unchecked((int)0xC03A0021),
        STATUS_CTLOG_VHD_CHANGED_OFFLINE = unchecked((int)0xC03A0022),
        STATUS_CTLOG_INVALID_TRACKING_STATE = unchecked((int)0xC03A0023),
        STATUS_CTLOG_INCONSISTENT_TRACKING_FILE = unchecked((int)0xC03A0024),
        STATUS_VHD_METADATA_FULL = unchecked((int)0xC03A0028),
        STATUS_VHD_INVALID_CHANGE_TRACKING_ID = unchecked((int)0xC03A0029),
        STATUS_VHD_CHANGE_TRACKING_DISABLED = unchecked((int)0xC03A002A),
        STATUS_VHD_MISSING_CHANGE_TRACKING_INFORMATION = unchecked((int)0xC03A0030),
        STATUS_VHD_RESIZE_WOULD_TRUNCATE_DATA = unchecked((int)0xC03A0031),
        STATUS_VHD_COULD_NOT_COMPUTE_MINIMUM_VIRTUAL_SIZE = unchecked((int)0xC03A0032),
        STATUS_VHD_ALREADY_AT_OR_BELOW_MINIMUM_VIRTUAL_SIZE = unchecked((int)0xC03A0033),
        STATUS_QUERY_STORAGE_ERROR = unchecked((int)0x803A0001),
        STATUS_GDI_HANDLE_LEAK = unchecked((int)0x803F0001),
        STATUS_RKF_KEY_NOT_FOUND = unchecked((int)0xC0400001),
        STATUS_RKF_DUPLICATE_KEY = unchecked((int)0xC0400002),
        STATUS_RKF_BLOB_FULL = unchecked((int)0xC0400003),
        STATUS_RKF_STORE_FULL = unchecked((int)0xC0400004),
        STATUS_RKF_FILE_BLOCKED = unchecked((int)0xC0400005),
        STATUS_RKF_ACTIVE_KEY = unchecked((int)0xC0400006),
        STATUS_RDBSS_RESTART_OPERATION = unchecked((int)0xC0410001),
        STATUS_RDBSS_CONTINUE_OPERATION = unchecked((int)0xC0410002),
        STATUS_RDBSS_POST_OPERATION = unchecked((int)0xC0410003),
        STATUS_RDBSS_RETRY_LOOKUP = unchecked((int)0xC0410004),
        STATUS_BTH_ATT_INVALID_HANDLE = unchecked((int)0xC0420001),
        STATUS_BTH_ATT_READ_NOT_PERMITTED = unchecked((int)0xC0420002),
        STATUS_BTH_ATT_WRITE_NOT_PERMITTED = unchecked((int)0xC0420003),
        STATUS_BTH_ATT_INVALID_PDU = unchecked((int)0xC0420004),
        STATUS_BTH_ATT_INSUFFICIENT_AUTHENTICATION = unchecked((int)0xC0420005),
        STATUS_BTH_ATT_REQUEST_NOT_SUPPORTED = unchecked((int)0xC0420006),
        STATUS_BTH_ATT_INVALID_OFFSET = unchecked((int)0xC0420007),
        STATUS_BTH_ATT_INSUFFICIENT_AUTHORIZATION = unchecked((int)0xC0420008),
        STATUS_BTH_ATT_PREPARE_QUEUE_FULL = unchecked((int)0xC0420009),
        STATUS_BTH_ATT_ATTRIBUTE_NOT_FOUND = unchecked((int)0xC042000A),
        STATUS_BTH_ATT_ATTRIBUTE_NOT_LONG = unchecked((int)0xC042000B),
        STATUS_BTH_ATT_INSUFFICIENT_ENCRYPTION_KEY_SIZE = unchecked((int)0xC042000C),
        STATUS_BTH_ATT_INVALID_ATTRIBUTE_VALUE_LENGTH = unchecked((int)0xC042000D),
        STATUS_BTH_ATT_UNLIKELY = unchecked((int)0xC042000E),
        STATUS_BTH_ATT_INSUFFICIENT_ENCRYPTION = unchecked((int)0xC042000F),
        STATUS_BTH_ATT_UNSUPPORTED_GROUP_TYPE = unchecked((int)0xC0420010),
        STATUS_BTH_ATT_INSUFFICIENT_RESOURCES = unchecked((int)0xC0420011),
        STATUS_BTH_ATT_UNKNOWN_ERROR = unchecked((int)0xC0421000),
        STATUS_SECUREBOOT_ROLLBACK_DETECTED = unchecked((int)0xC0430001),
        STATUS_SECUREBOOT_POLICY_VIOLATION = unchecked((int)0xC0430002),
        STATUS_SECUREBOOT_INVALID_POLICY = unchecked((int)0xC0430003),
        STATUS_SECUREBOOT_POLICY_PUBLISHER_NOT_FOUND = unchecked((int)0xC0430004),
        STATUS_SECUREBOOT_POLICY_NOT_SIGNED = unchecked((int)0xC0430005),
        STATUS_SECUREBOOT_NOT_ENABLED = unchecked((int)0x80430006),
        STATUS_SECUREBOOT_FILE_REPLACED = unchecked((int)0xC0430007),
        STATUS_SECUREBOOT_POLICY_NOT_AUTHORIZED = unchecked((int)0xC0430008),
        STATUS_SECUREBOOT_POLICY_UNKNOWN = unchecked((int)0xC0430009),
        STATUS_SECUREBOOT_POLICY_MISSING_ANTIROLLBACKVERSION = unchecked((int)0xC043000A),
        STATUS_SECUREBOOT_PLATFORM_ID_MISMATCH = unchecked((int)0xC043000B),
        STATUS_SECUREBOOT_POLICY_ROLLBACK_DETECTED = unchecked((int)0xC043000C),
        STATUS_SECUREBOOT_POLICY_UPGRADE_MISMATCH = unchecked((int)0xC043000D),
        STATUS_SECUREBOOT_REQUIRED_POLICY_FILE_MISSING = unchecked((int)0xC043000E),
        STATUS_SECUREBOOT_NOT_BASE_POLICY = unchecked((int)0xC043000F),
        STATUS_SECUREBOOT_NOT_SUPPLEMENTAL_POLICY = unchecked((int)0xC0430010),
        STATUS_PLATFORM_MANIFEST_NOT_AUTHORIZED = unchecked((int)0xC0EB0001),
        STATUS_PLATFORM_MANIFEST_INVALID = unchecked((int)0xC0EB0002),
        STATUS_PLATFORM_MANIFEST_FILE_NOT_AUTHORIZED = unchecked((int)0xC0EB0003),
        STATUS_PLATFORM_MANIFEST_CATALOG_NOT_AUTHORIZED = unchecked((int)0xC0EB0004),
        STATUS_PLATFORM_MANIFEST_BINARY_ID_NOT_FOUND = unchecked((int)0xC0EB0005),
        STATUS_PLATFORM_MANIFEST_NOT_ACTIVE = unchecked((int)0xC0EB0006),
        STATUS_PLATFORM_MANIFEST_NOT_SIGNED = unchecked((int)0xC0EB0007),
        STATUS_SYSTEM_INTEGRITY_ROLLBACK_DETECTED = unchecked((int)0xC0E90001),
        STATUS_SYSTEM_INTEGRITY_POLICY_VIOLATION = unchecked((int)0xC0E90002),
        STATUS_SYSTEM_INTEGRITY_INVALID_POLICY = unchecked((int)0xC0E90003),
        STATUS_SYSTEM_INTEGRITY_POLICY_NOT_SIGNED = unchecked((int)0xC0E90004),
        STATUS_SYSTEM_INTEGRITY_TOO_MANY_POLICIES = unchecked((int)0xC0E90005),
        STATUS_SYSTEM_INTEGRITY_SUPPLEMENTAL_POLICY_NOT_AUTHORIZED = unchecked((int)0xC0E90006),
        STATUS_SYSTEM_INTEGRITY_REPUTATION_MALICIOUS = unchecked((int)0xC0E90007),
        STATUS_SYSTEM_INTEGRITY_REPUTATION_PUA = unchecked((int)0xC0E90008),
        STATUS_SYSTEM_INTEGRITY_REPUTATION_DANGEROUS_EXT = unchecked((int)0xC0E90009),
        STATUS_SYSTEM_INTEGRITY_REPUTATION_OFFLINE = unchecked((int)0xC0E9000A),
        STATUS_NO_APPLICABLE_APP_LICENSES_FOUND = unchecked((int)0xC0EA0001),
        STATUS_CLIP_LICENSE_NOT_FOUND = unchecked((int)0xC0EA0002),
        STATUS_CLIP_DEVICE_LICENSE_MISSING = unchecked((int)0xC0EA0003),
        STATUS_CLIP_LICENSE_INVALID_SIGNATURE = unchecked((int)0xC0EA0004),
        STATUS_CLIP_KEYHOLDER_LICENSE_MISSING_OR_INVALID = unchecked((int)0xC0EA0005),
        STATUS_CLIP_LICENSE_EXPIRED = unchecked((int)0xC0EA0006),
        STATUS_CLIP_LICENSE_SIGNED_BY_UNKNOWN_SOURCE = unchecked((int)0xC0EA0007),
        STATUS_CLIP_LICENSE_NOT_SIGNED = unchecked((int)0xC0EA0008),
        STATUS_CLIP_LICENSE_HARDWARE_ID_OUT_OF_TOLERANCE = unchecked((int)0xC0EA0009),
        STATUS_CLIP_LICENSE_DEVICE_ID_MISMATCH = unchecked((int)0xC0EA000A),
        STATUS_AUDIO_ENGINE_NODE_NOT_FOUND = unchecked((int)0xC0440001),
        STATUS_HDAUDIO_EMPTY_CONNECTION_LIST = unchecked((int)0xC0440002),
        STATUS_HDAUDIO_CONNECTION_LIST_NOT_SUPPORTED = unchecked((int)0xC0440003),
        STATUS_HDAUDIO_NO_LOGICAL_DEVICES_CREATED = unchecked((int)0xC0440004),
        STATUS_HDAUDIO_NULL_LINKED_LIST_ENTRY = unchecked((int)0xC0440005),
        STATUS_SPACES_REPAIRED = unchecked((int)0x00E70000),
        STATUS_SPACES_PAUSE = unchecked((int)0x00E70001),
        STATUS_SPACES_COMPLETE = unchecked((int)0x00E70002),
        STATUS_SPACES_REDIRECT = unchecked((int)0x00E70003),
        STATUS_SPACES_FAULT_DOMAIN_TYPE_INVALID = unchecked((int)0xC0E70001),
        STATUS_SPACES_RESILIENCY_TYPE_INVALID = unchecked((int)0xC0E70003),
        STATUS_SPACES_DRIVE_SECTOR_SIZE_INVALID = unchecked((int)0xC0E70004),
        STATUS_SPACES_DRIVE_REDUNDANCY_INVALID = unchecked((int)0xC0E70006),
        STATUS_SPACES_NUMBER_OF_DATA_COPIES_INVALID = unchecked((int)0xC0E70007),
        STATUS_SPACES_INTERLEAVE_LENGTH_INVALID = unchecked((int)0xC0E70009),
        STATUS_SPACES_NUMBER_OF_COLUMNS_INVALID = unchecked((int)0xC0E7000A),
        STATUS_SPACES_NOT_ENOUGH_DRIVES = unchecked((int)0xC0E7000B),
        STATUS_SPACES_EXTENDED_ERROR = unchecked((int)0xC0E7000C),
        STATUS_SPACES_PROVISIONING_TYPE_INVALID = unchecked((int)0xC0E7000D),
        STATUS_SPACES_ALLOCATION_SIZE_INVALID = unchecked((int)0xC0E7000E),
        STATUS_SPACES_ENCLOSURE_AWARE_INVALID = unchecked((int)0xC0E7000F),
        STATUS_SPACES_WRITE_CACHE_SIZE_INVALID = unchecked((int)0xC0E70010),
        STATUS_SPACES_NUMBER_OF_GROUPS_INVALID = unchecked((int)0xC0E70011),
        STATUS_SPACES_DRIVE_OPERATIONAL_STATE_INVALID = unchecked((int)0xC0E70012),
        STATUS_SPACES_UPDATE_COLUMN_STATE = unchecked((int)0xC0E70013),
        STATUS_SPACES_MAP_REQUIRED = unchecked((int)0xC0E70014),
        STATUS_SPACES_UNSUPPORTED_VERSION = unchecked((int)0xC0E70015),
        STATUS_SPACES_CORRUPT_METADATA = unchecked((int)0xC0E70016),
        STATUS_SPACES_DRT_FULL = unchecked((int)0xC0E70017),
        STATUS_SPACES_INCONSISTENCY = unchecked((int)0xC0E70018),
        STATUS_SPACES_LOG_NOT_READY = unchecked((int)0xC0E70019),
        STATUS_SPACES_NO_REDUNDANCY = unchecked((int)0xC0E7001A),
        STATUS_SPACES_DRIVE_NOT_READY = unchecked((int)0xC0E7001B),
        STATUS_SPACES_DRIVE_SPLIT = unchecked((int)0xC0E7001C),
        STATUS_SPACES_DRIVE_LOST_DATA = unchecked((int)0xC0E7001D),
        STATUS_SPACES_ENTRY_INCOMPLETE = unchecked((int)0xC0E7001E),
        STATUS_SPACES_ENTRY_INVALID = unchecked((int)0xC0E7001F),
        STATUS_SPACES_MARK_DIRTY = unchecked((int)0xC0E70020),
        STATUS_SPACES_PD_NOT_FOUND = unchecked((int)0xC0E70021),
        STATUS_SPACES_PD_LENGTH_MISMATCH = unchecked((int)0xC0E70022),
        STATUS_SPACES_PD_UNSUPPORTED_VERSION = unchecked((int)0xC0E70023),
        STATUS_SPACES_PD_INVALID_DATA = unchecked((int)0xC0E70024),
        STATUS_SPACES_FLUSH_METADATA = unchecked((int)0xC0E70025),
        STATUS_SPACES_CACHE_FULL = unchecked((int)0xC0E70026),
        STATUS_VOLSNAP_BOOTFILE_NOT_VALID = unchecked((int)0xC0500003),
        STATUS_VOLSNAP_ACTIVATION_TIMEOUT = unchecked((int)0xC0500004),
        STATUS_VOLSNAP_NO_BYPASSIO_WITH_SNAPSHOT = unchecked((int)0xC0500005),
        STATUS_IO_PREEMPTED = unchecked((int)0xC0510001),
        STATUS_SVHDX_ERROR_STORED = unchecked((int)0xC05C0000),
        STATUS_SVHDX_ERROR_NOT_AVAILABLE = unchecked((int)0xC05CFF00),
        STATUS_SVHDX_UNIT_ATTENTION_AVAILABLE = unchecked((int)0xC05CFF01),
        STATUS_SVHDX_UNIT_ATTENTION_CAPACITY_DATA_CHANGED = unchecked((int)0xC05CFF02),
        STATUS_SVHDX_UNIT_ATTENTION_RESERVATIONS_PREEMPTED = unchecked((int)0xC05CFF03),
        STATUS_SVHDX_UNIT_ATTENTION_RESERVATIONS_RELEASED = unchecked((int)0xC05CFF04),
        STATUS_SVHDX_UNIT_ATTENTION_REGISTRATIONS_PREEMPTED = unchecked((int)0xC05CFF05),
        STATUS_SVHDX_UNIT_ATTENTION_OPERATING_DEFINITION_CHANGED = unchecked((int)0xC05CFF06),
        STATUS_SVHDX_RESERVATION_CONFLICT = unchecked((int)0xC05CFF07),
        STATUS_SVHDX_WRONG_FILE_TYPE = unchecked((int)0xC05CFF08),
        STATUS_SVHDX_VERSION_MISMATCH = unchecked((int)0xC05CFF09),
        STATUS_VHD_SHARED = unchecked((int)0xC05CFF0A),
        STATUS_SVHDX_NO_INITIATOR = unchecked((int)0xC05CFF0B),
        STATUS_VHDSET_BACKING_STORAGE_NOT_FOUND = unchecked((int)0xC05CFF0C),
        STATUS_SMB_NO_PREAUTH_INTEGRITY_HASH_OVERLAP = unchecked((int)0xC05D0000),
        STATUS_SMB_BAD_CLUSTER_DIALECT = unchecked((int)0xC05D0001),
        STATUS_SMB_GUEST_LOGON_BLOCKED = unchecked((int)0xC05D0002),
        STATUS_SMB_NO_SIGNING_ALGORITHM_OVERLAP = unchecked((int)0xC05D0003),
        STATUS_SECCORE_INVALID_COMMAND = unchecked((int)0xC0E80000),
        STATUS_VSM_NOT_INITIALIZED = unchecked((int)0xC0450000),
        STATUS_VSM_DMA_PROTECTION_NOT_IN_USE = unchecked((int)0xC0450001),
        STATUS_APPEXEC_CONDITION_NOT_SATISFIED = unchecked((int)0xC0EC0000),
        STATUS_APPEXEC_HANDLE_INVALIDATED = unchecked((int)0xC0EC0001),
        STATUS_APPEXEC_INVALID_HOST_GENERATION = unchecked((int)0xC0EC0002),
        STATUS_APPEXEC_UNEXPECTED_PROCESS_REGISTRATION = unchecked((int)0xC0EC0003),
        STATUS_APPEXEC_INVALID_HOST_STATE = unchecked((int)0xC0EC0004),
        STATUS_APPEXEC_NO_DONOR = unchecked((int)0xC0EC0005),
        STATUS_APPEXEC_HOST_ID_MISMATCH = unchecked((int)0xC0EC0006),
        STATUS_APPEXEC_UNKNOWN_USER = unchecked((int)0xC0EC0007),
        STATUS_APPEXEC_APP_COMPAT_BLOCK = unchecked((int)0xC0EC0008),
        STATUS_APPEXEC_CALLER_WAIT_TIMEOUT = unchecked((int)0xC0EC0009),
        STATUS_APPEXEC_CALLER_WAIT_TIMEOUT_TERMINATION = unchecked((int)0xC0EC000A),
        STATUS_APPEXEC_CALLER_WAIT_TIMEOUT_LICENSING = unchecked((int)0xC0EC000B),
        STATUS_APPEXEC_CALLER_WAIT_TIMEOUT_RESOURCES = unchecked((int)0xC0EC000C),
        STATUS_QUIC_HANDSHAKE_FAILURE = unchecked((int)0xC0240000),
        STATUS_QUIC_VER_NEG_FAILURE = unchecked((int)0xC0240001),
        STATUS_QUIC_USER_CANCELED = unchecked((int)0xC0240002),
        STATUS_QUIC_INTERNAL_ERROR = unchecked((int)0xC0240003),
        STATUS_QUIC_PROTOCOL_VIOLATION = unchecked((int)0xC0240004),
        STATUS_QUIC_CONNECTION_IDLE = unchecked((int)0xC0240005),
        STATUS_QUIC_CONNECTION_TIMEOUT = unchecked((int)0xC0240006),
        STATUS_QUIC_ALPN_NEG_FAILURE = unchecked((int)0xC0240007),
        STATUS_IORING_REQUIRED_FLAG_NOT_SUPPORTED = unchecked((int)0xC0460001),
        STATUS_IORING_SUBMISSION_QUEUE_FULL = unchecked((int)0xC0460002),
        STATUS_IORING_VERSION_NOT_SUPPORTED = unchecked((int)0xC0460003),
        STATUS_IORING_SUBMISSION_QUEUE_TOO_BIG = unchecked((int)0xC0460004),
        STATUS_IORING_COMPLETION_QUEUE_TOO_BIG = unchecked((int)0xC0460005),
        STATUS_IORING_SUBMIT_IN_PROGRESS = unchecked((int)0xC0460006),
        STATUS_IORING_CORRUPT = unchecked((int)0xC0460007),
    }
    #endregion enums

    class NtStatusToString {

        public static string StatusToString(NtStatusCodes status)
        {
            switch (status)
            {
                case unchecked((NtStatusCodes)0x00000000): return "STATUS_SUCCESS";
                // case unchecked((NtStatusCodes)0x00000000): return "STATUS_WAIT_0";
                case unchecked((NtStatusCodes)0x00000001): return "STATUS_WAIT_1";
                case unchecked((NtStatusCodes)0x00000002): return "STATUS_WAIT_2";
                case unchecked((NtStatusCodes)0x00000003): return "STATUS_WAIT_3";
                case unchecked((NtStatusCodes)0x0000003F): return "STATUS_WAIT_63";
                case unchecked((NtStatusCodes)0x00000080): return "STATUS_ABANDONED_WAIT_0";
                // case unchecked((NtStatusCodes)0x00000080): return "STATUS_ABANDONED";
                case unchecked((NtStatusCodes)0x000000BF): return "STATUS_ABANDONED_WAIT_63";
                case unchecked((NtStatusCodes)0x000000C0): return "STATUS_USER_APC";
                case unchecked((NtStatusCodes)0x000000FF): return "STATUS_ALREADY_COMPLETE";
                case unchecked((NtStatusCodes)0x00000100): return "STATUS_KERNEL_APC";
                case unchecked((NtStatusCodes)0x00000101): return "STATUS_ALERTED";
                case unchecked((NtStatusCodes)0x00000102): return "STATUS_TIMEOUT";
                case unchecked((NtStatusCodes)0x00000103): return "STATUS_PENDING";
                case unchecked((NtStatusCodes)0x00000104): return "STATUS_REPARSE";
                case unchecked((NtStatusCodes)0x00000105): return "STATUS_MORE_ENTRIES";
                case unchecked((NtStatusCodes)0x00000106): return "STATUS_NOT_ALL_ASSIGNED";
                case unchecked((NtStatusCodes)0x00000107): return "STATUS_SOME_NOT_MAPPED";
                case unchecked((NtStatusCodes)0x00000108): return "STATUS_OPLOCK_BREAK_IN_PROGRESS";
                case unchecked((NtStatusCodes)0x00000109): return "STATUS_VOLUME_MOUNTED";
                case unchecked((NtStatusCodes)0x0000010A): return "STATUS_RXACT_COMMITTED";
                case unchecked((NtStatusCodes)0x0000010B): return "STATUS_NOTIFY_CLEANUP";
                case unchecked((NtStatusCodes)0x0000010C): return "STATUS_NOTIFY_ENUM_DIR";
                case unchecked((NtStatusCodes)0x0000010D): return "STATUS_NO_QUOTAS_FOR_ACCOUNT";
                case unchecked((NtStatusCodes)0x0000010E): return "STATUS_PRIMARY_TRANSPORT_CONNECT_FAILED";
                case unchecked((NtStatusCodes)0x00000110): return "STATUS_PAGE_FAULT_TRANSITION";
                case unchecked((NtStatusCodes)0x00000111): return "STATUS_PAGE_FAULT_DEMAND_ZERO";
                case unchecked((NtStatusCodes)0x00000112): return "STATUS_PAGE_FAULT_COPY_ON_WRITE";
                case unchecked((NtStatusCodes)0x00000113): return "STATUS_PAGE_FAULT_GUARD_PAGE";
                case unchecked((NtStatusCodes)0x00000114): return "STATUS_PAGE_FAULT_PAGING_FILE";
                case unchecked((NtStatusCodes)0x00000115): return "STATUS_CACHE_PAGE_LOCKED";
                case unchecked((NtStatusCodes)0x00000116): return "STATUS_CRASH_DUMP";
                case unchecked((NtStatusCodes)0x00000117): return "STATUS_BUFFER_ALL_ZEROS";
                case unchecked((NtStatusCodes)0x00000118): return "STATUS_REPARSE_OBJECT";
                case unchecked((NtStatusCodes)0x00000119): return "STATUS_RESOURCE_REQUIREMENTS_CHANGED";
                case unchecked((NtStatusCodes)0x00000120): return "STATUS_TRANSLATION_COMPLETE";
                case unchecked((NtStatusCodes)0x00000121): return "STATUS_DS_MEMBERSHIP_EVALUATED_LOCALLY";
                case unchecked((NtStatusCodes)0x00000122): return "STATUS_NOTHING_TO_TERMINATE";
                case unchecked((NtStatusCodes)0x00000123): return "STATUS_PROCESS_NOT_IN_JOB";
                case unchecked((NtStatusCodes)0x00000124): return "STATUS_PROCESS_IN_JOB";
                case unchecked((NtStatusCodes)0x00000125): return "STATUS_VOLSNAP_HIBERNATE_READY";
                case unchecked((NtStatusCodes)0x00000126): return "STATUS_FSFILTER_OP_COMPLETED_SUCCESSFULLY";
                case unchecked((NtStatusCodes)0x00000127): return "STATUS_INTERRUPT_VECTOR_ALREADY_CONNECTED";
                case unchecked((NtStatusCodes)0x00000128): return "STATUS_INTERRUPT_STILL_CONNECTED";
                case unchecked((NtStatusCodes)0x00000129): return "STATUS_PROCESS_CLONED";
                case unchecked((NtStatusCodes)0x0000012A): return "STATUS_FILE_LOCKED_WITH_ONLY_READERS";
                case unchecked((NtStatusCodes)0x0000012B): return "STATUS_FILE_LOCKED_WITH_WRITERS";
                case unchecked((NtStatusCodes)0x0000012C): return "STATUS_VALID_IMAGE_HASH";
                case unchecked((NtStatusCodes)0x0000012D): return "STATUS_VALID_CATALOG_HASH";
                case unchecked((NtStatusCodes)0x0000012E): return "STATUS_VALID_STRONG_CODE_HASH";
                case unchecked((NtStatusCodes)0x0000012F): return "STATUS_GHOSTED";
                case unchecked((NtStatusCodes)0x00000130): return "STATUS_DATA_OVERWRITTEN";
                case unchecked((NtStatusCodes)0x00000202): return "STATUS_RESOURCEMANAGER_READ_ONLY";
                case unchecked((NtStatusCodes)0x00000210): return "STATUS_RING_PREVIOUSLY_EMPTY";
                case unchecked((NtStatusCodes)0x00000211): return "STATUS_RING_PREVIOUSLY_FULL";
                case unchecked((NtStatusCodes)0x00000212): return "STATUS_RING_PREVIOUSLY_ABOVE_QUOTA";
                case unchecked((NtStatusCodes)0x00000213): return "STATUS_RING_NEWLY_EMPTY";
                case unchecked((NtStatusCodes)0x00000214): return "STATUS_RING_SIGNAL_OPPOSITE_ENDPOINT";
                case unchecked((NtStatusCodes)0x00000215): return "STATUS_OPLOCK_SWITCHED_TO_NEW_HANDLE";
                case unchecked((NtStatusCodes)0x00000216): return "STATUS_OPLOCK_HANDLE_CLOSED";
                case unchecked((NtStatusCodes)0x00000367): return "STATUS_WAIT_FOR_OPLOCK";
                case unchecked((NtStatusCodes)0x00000368): return "STATUS_REPARSE_GLOBAL";
                case unchecked((NtStatusCodes)0x001C0001): return "STATUS_FLT_IO_COMPLETE";
                case unchecked((NtStatusCodes)0x40000000): return "STATUS_OBJECT_NAME_EXISTS";
                case unchecked((NtStatusCodes)0x40000001): return "STATUS_THREAD_WAS_SUSPENDED";
                case unchecked((NtStatusCodes)0x40000002): return "STATUS_WORKING_SET_LIMIT_RANGE";
                case unchecked((NtStatusCodes)0x40000003): return "STATUS_IMAGE_NOT_AT_BASE";
                case unchecked((NtStatusCodes)0x40000004): return "STATUS_RXACT_STATE_CREATED";
                case unchecked((NtStatusCodes)0x40000005): return "STATUS_SEGMENT_NOTIFICATION";
                case unchecked((NtStatusCodes)0x40000006): return "STATUS_LOCAL_USER_SESSION_KEY";
                case unchecked((NtStatusCodes)0x40000007): return "STATUS_BAD_CURRENT_DIRECTORY";
                case unchecked((NtStatusCodes)0x40000008): return "STATUS_SERIAL_MORE_WRITES";
                case unchecked((NtStatusCodes)0x40000009): return "STATUS_REGISTRY_RECOVERED";
                case unchecked((NtStatusCodes)0x4000000A): return "STATUS_FT_READ_RECOVERY_FROM_BACKUP";
                case unchecked((NtStatusCodes)0x4000000B): return "STATUS_FT_WRITE_RECOVERY";
                case unchecked((NtStatusCodes)0x4000000C): return "STATUS_SERIAL_COUNTER_TIMEOUT";
                case unchecked((NtStatusCodes)0x4000000D): return "STATUS_NULL_LM_PASSWORD";
                case unchecked((NtStatusCodes)0x4000000E): return "STATUS_IMAGE_MACHINE_TYPE_MISMATCH";
                case unchecked((NtStatusCodes)0x4000000F): return "STATUS_RECEIVE_PARTIAL";
                case unchecked((NtStatusCodes)0x40000010): return "STATUS_RECEIVE_EXPEDITED";
                case unchecked((NtStatusCodes)0x40000011): return "STATUS_RECEIVE_PARTIAL_EXPEDITED";
                case unchecked((NtStatusCodes)0x40000012): return "STATUS_EVENT_DONE";
                case unchecked((NtStatusCodes)0x40000013): return "STATUS_EVENT_PENDING";
                case unchecked((NtStatusCodes)0x40000014): return "STATUS_CHECKING_FILE_SYSTEM";
                case unchecked((NtStatusCodes)0x40000015): return "STATUS_FATAL_APP_EXIT";
                case unchecked((NtStatusCodes)0x40000016): return "STATUS_PREDEFINED_HANDLE";
                case unchecked((NtStatusCodes)0x40000017): return "STATUS_WAS_UNLOCKED";
                case unchecked((NtStatusCodes)0x40000018): return "STATUS_SERVICE_NOTIFICATION";
                case unchecked((NtStatusCodes)0x40000019): return "STATUS_WAS_LOCKED";
                case unchecked((NtStatusCodes)0x4000001A): return "STATUS_LOG_HARD_ERROR";
                case unchecked((NtStatusCodes)0x4000001B): return "STATUS_ALREADY_WIN32";
                case unchecked((NtStatusCodes)0x4000001C): return "STATUS_WX86_UNSIMULATE";
                case unchecked((NtStatusCodes)0x4000001D): return "STATUS_WX86_CONTINUE";
                case unchecked((NtStatusCodes)0x4000001E): return "STATUS_WX86_SINGLE_STEP";
                case unchecked((NtStatusCodes)0x4000001F): return "STATUS_WX86_BREAKPOINT";
                case unchecked((NtStatusCodes)0x40000020): return "STATUS_WX86_EXCEPTION_CONTINUE";
                case unchecked((NtStatusCodes)0x40000021): return "STATUS_WX86_EXCEPTION_LASTCHANCE";
                case unchecked((NtStatusCodes)0x40000022): return "STATUS_WX86_EXCEPTION_CHAIN";
                case unchecked((NtStatusCodes)0x40000023): return "STATUS_IMAGE_MACHINE_TYPE_MISMATCH_EXE";
                case unchecked((NtStatusCodes)0x40000024): return "STATUS_NO_YIELD_PERFORMED";
                case unchecked((NtStatusCodes)0x40000025): return "STATUS_TIMER_RESUME_IGNORED";
                case unchecked((NtStatusCodes)0x40000026): return "STATUS_ARBITRATION_UNHANDLED";
                case unchecked((NtStatusCodes)0x40000027): return "STATUS_CARDBUS_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0x40000028): return "STATUS_WX86_CREATEWX86TIB";
                case unchecked((NtStatusCodes)0x40000029): return "STATUS_MP_PROCESSOR_MISMATCH";
                case unchecked((NtStatusCodes)0x4000002A): return "STATUS_HIBERNATED";
                case unchecked((NtStatusCodes)0x4000002B): return "STATUS_RESUME_HIBERNATION";
                case unchecked((NtStatusCodes)0x4000002C): return "STATUS_FIRMWARE_UPDATED";
                case unchecked((NtStatusCodes)0x4000002D): return "STATUS_DRIVERS_LEAKING_LOCKED_PAGES";
                case unchecked((NtStatusCodes)0x4000002E): return "STATUS_MESSAGE_RETRIEVED";
                case unchecked((NtStatusCodes)0x4000002F): return "STATUS_SYSTEM_POWERSTATE_TRANSITION";
                case unchecked((NtStatusCodes)0x40000030): return "STATUS_ALPC_CHECK_COMPLETION_LIST";
                case unchecked((NtStatusCodes)0x40000031): return "STATUS_SYSTEM_POWERSTATE_COMPLEX_TRANSITION";
                case unchecked((NtStatusCodes)0x40000032): return "STATUS_ACCESS_AUDIT_BY_POLICY";
                case unchecked((NtStatusCodes)0x40000033): return "STATUS_ABANDON_HIBERFILE";
                case unchecked((NtStatusCodes)0x40000034): return "STATUS_BIZRULES_NOT_ENABLED";
                case unchecked((NtStatusCodes)0x40000035): return "STATUS_FT_READ_FROM_COPY";
                case unchecked((NtStatusCodes)0x40000036): return "STATUS_IMAGE_AT_DIFFERENT_BASE";
                case unchecked((NtStatusCodes)0x40000037): return "STATUS_PATCH_DEFERRED";
                case unchecked((NtStatusCodes)0x40000038): return "STATUS_EMULATION_BREAKPOINT";
                case unchecked((NtStatusCodes)0x40000039): return "STATUS_EMULATION_SYSCALL";
                case unchecked((NtStatusCodes)0x40190001): return "STATUS_HEURISTIC_DAMAGE_POSSIBLE";
                case unchecked((NtStatusCodes)0x80000001): return "STATUS_GUARD_PAGE_VIOLATION";
                case unchecked((NtStatusCodes)0x80000002): return "STATUS_DATATYPE_MISALIGNMENT";
                case unchecked((NtStatusCodes)0x80000003): return "STATUS_BREAKPOINT";
                case unchecked((NtStatusCodes)0x80000004): return "STATUS_SINGLE_STEP";
                case unchecked((NtStatusCodes)0x80000005): return "STATUS_BUFFER_OVERFLOW";
                case unchecked((NtStatusCodes)0x80000006): return "STATUS_NO_MORE_FILES";
                case unchecked((NtStatusCodes)0x80000007): return "STATUS_WAKE_SYSTEM_DEBUGGER";
                case unchecked((NtStatusCodes)0x8000000A): return "STATUS_HANDLES_CLOSED";
                case unchecked((NtStatusCodes)0x8000000B): return "STATUS_NO_INHERITANCE";
                case unchecked((NtStatusCodes)0x8000000C): return "STATUS_GUID_SUBSTITUTION_MADE";
                case unchecked((NtStatusCodes)0x8000000D): return "STATUS_PARTIAL_COPY";
                case unchecked((NtStatusCodes)0x8000000E): return "STATUS_DEVICE_PAPER_EMPTY";
                case unchecked((NtStatusCodes)0x8000000F): return "STATUS_DEVICE_POWERED_OFF";
                case unchecked((NtStatusCodes)0x80000010): return "STATUS_DEVICE_OFF_LINE";
                case unchecked((NtStatusCodes)0x80000011): return "STATUS_DEVICE_BUSY";
                case unchecked((NtStatusCodes)0x80000012): return "STATUS_NO_MORE_EAS";
                case unchecked((NtStatusCodes)0x80000013): return "STATUS_INVALID_EA_NAME";
                case unchecked((NtStatusCodes)0x80000014): return "STATUS_EA_LIST_INCONSISTENT";
                case unchecked((NtStatusCodes)0x80000015): return "STATUS_INVALID_EA_FLAG";
                case unchecked((NtStatusCodes)0x80000016): return "STATUS_VERIFY_REQUIRED";
                case unchecked((NtStatusCodes)0x80000017): return "STATUS_EXTRANEOUS_INFORMATION";
                case unchecked((NtStatusCodes)0x80000018): return "STATUS_RXACT_COMMIT_NECESSARY";
                case unchecked((NtStatusCodes)0x8000001A): return "STATUS_NO_MORE_ENTRIES";
                case unchecked((NtStatusCodes)0x8000001B): return "STATUS_FILEMARK_DETECTED";
                case unchecked((NtStatusCodes)0x8000001C): return "STATUS_MEDIA_CHANGED";
                case unchecked((NtStatusCodes)0x8000001D): return "STATUS_BUS_RESET";
                case unchecked((NtStatusCodes)0x8000001E): return "STATUS_END_OF_MEDIA";
                case unchecked((NtStatusCodes)0x8000001F): return "STATUS_BEGINNING_OF_MEDIA";
                case unchecked((NtStatusCodes)0x80000020): return "STATUS_MEDIA_CHECK";
                case unchecked((NtStatusCodes)0x80000021): return "STATUS_SETMARK_DETECTED";
                case unchecked((NtStatusCodes)0x80000022): return "STATUS_NO_DATA_DETECTED";
                case unchecked((NtStatusCodes)0x80000023): return "STATUS_REDIRECTOR_HAS_OPEN_HANDLES";
                case unchecked((NtStatusCodes)0x80000024): return "STATUS_SERVER_HAS_OPEN_HANDLES";
                case unchecked((NtStatusCodes)0x80000025): return "STATUS_ALREADY_DISCONNECTED";
                case unchecked((NtStatusCodes)0x80000026): return "STATUS_LONGJUMP";
                case unchecked((NtStatusCodes)0x80000027): return "STATUS_CLEANER_CARTRIDGE_INSTALLED";
                case unchecked((NtStatusCodes)0x80000028): return "STATUS_PLUGPLAY_QUERY_VETOED";
                case unchecked((NtStatusCodes)0x80000029): return "STATUS_UNWIND_CONSOLIDATE";
                case unchecked((NtStatusCodes)0x8000002A): return "STATUS_REGISTRY_HIVE_RECOVERED";
                case unchecked((NtStatusCodes)0x8000002B): return "STATUS_DLL_MIGHT_BE_INSECURE";
                case unchecked((NtStatusCodes)0x8000002C): return "STATUS_DLL_MIGHT_BE_INCOMPATIBLE";
                case unchecked((NtStatusCodes)0x8000002D): return "STATUS_STOPPED_ON_SYMLINK";
                case unchecked((NtStatusCodes)0x8000002E): return "STATUS_CANNOT_GRANT_REQUESTED_OPLOCK";
                case unchecked((NtStatusCodes)0x8000002F): return "STATUS_NO_ACE_CONDITION";
                case unchecked((NtStatusCodes)0x80000030): return "STATUS_DEVICE_SUPPORT_IN_PROGRESS";
                case unchecked((NtStatusCodes)0x80000031): return "STATUS_DEVICE_POWER_CYCLE_REQUIRED";
                case unchecked((NtStatusCodes)0x80000032): return "STATUS_NO_WORK_DONE";
                case unchecked((NtStatusCodes)0x80000033): return "STATUS_RETURN_ADDRESS_HIJACK_ATTEMPT";
                case unchecked((NtStatusCodes)0x80000034): return "STATUS_RECOVERABLE_BUGCHECK";
                case unchecked((NtStatusCodes)0x80130001): return "STATUS_CLUSTER_NODE_ALREADY_UP";
                case unchecked((NtStatusCodes)0x80130002): return "STATUS_CLUSTER_NODE_ALREADY_DOWN";
                case unchecked((NtStatusCodes)0x80130003): return "STATUS_CLUSTER_NETWORK_ALREADY_ONLINE";
                case unchecked((NtStatusCodes)0x80130004): return "STATUS_CLUSTER_NETWORK_ALREADY_OFFLINE";
                case unchecked((NtStatusCodes)0x80130005): return "STATUS_CLUSTER_NODE_ALREADY_MEMBER";
                case unchecked((NtStatusCodes)0x801C0001): return "STATUS_FLT_BUFFER_TOO_SMALL";
                case unchecked((NtStatusCodes)0x80210001): return "STATUS_FVE_PARTIAL_METADATA";
                case unchecked((NtStatusCodes)0x80210002): return "STATUS_FVE_TRANSIENT_STATE";
                case unchecked((NtStatusCodes)0x8000CF00): return "STATUS_CLOUD_FILE_PROPERTY_BLOB_CHECKSUM_MISMATCH";
                case unchecked((NtStatusCodes)0xC0000001): return "STATUS_UNSUCCESSFUL";
                case unchecked((NtStatusCodes)0xC0000002): return "STATUS_NOT_IMPLEMENTED";
                case unchecked((NtStatusCodes)0xC0000003): return "STATUS_INVALID_INFO_CLASS";
                case unchecked((NtStatusCodes)0xC0000004): return "STATUS_INFO_LENGTH_MISMATCH";
                case unchecked((NtStatusCodes)0xC0000005): return "STATUS_ACCESS_VIOLATION";
                case unchecked((NtStatusCodes)0xC0000006): return "STATUS_IN_PAGE_ERROR";
                case unchecked((NtStatusCodes)0xC0000007): return "STATUS_PAGEFILE_QUOTA";
                case unchecked((NtStatusCodes)0xC0000008): return "STATUS_INVALID_HANDLE";
                case unchecked((NtStatusCodes)0xC0000009): return "STATUS_BAD_INITIAL_STACK";
                case unchecked((NtStatusCodes)0xC000000A): return "STATUS_BAD_INITIAL_PC";
                case unchecked((NtStatusCodes)0xC000000B): return "STATUS_INVALID_CID";
                case unchecked((NtStatusCodes)0xC000000C): return "STATUS_TIMER_NOT_CANCELED";
                case unchecked((NtStatusCodes)0xC000000D): return "STATUS_INVALID_PARAMETER";
                case unchecked((NtStatusCodes)0xC000000E): return "STATUS_NO_SUCH_DEVICE";
                case unchecked((NtStatusCodes)0xC000000F): return "STATUS_NO_SUCH_FILE";
                case unchecked((NtStatusCodes)0xC0000010): return "STATUS_INVALID_DEVICE_REQUEST";
                case unchecked((NtStatusCodes)0xC0000011): return "STATUS_END_OF_FILE";
                case unchecked((NtStatusCodes)0xC0000012): return "STATUS_WRONG_VOLUME";
                case unchecked((NtStatusCodes)0xC0000013): return "STATUS_NO_MEDIA_IN_DEVICE";
                case unchecked((NtStatusCodes)0xC0000014): return "STATUS_UNRECOGNIZED_MEDIA";
                case unchecked((NtStatusCodes)0xC0000015): return "STATUS_NONEXISTENT_SECTOR";
                case unchecked((NtStatusCodes)0xC0000016): return "STATUS_MORE_PROCESSING_REQUIRED";
                case unchecked((NtStatusCodes)0xC0000017): return "STATUS_NO_MEMORY";
                case unchecked((NtStatusCodes)0xC0000018): return "STATUS_CONFLICTING_ADDRESSES";
                case unchecked((NtStatusCodes)0xC0000019): return "STATUS_NOT_MAPPED_VIEW";
                case unchecked((NtStatusCodes)0xC000001A): return "STATUS_UNABLE_TO_FREE_VM";
                case unchecked((NtStatusCodes)0xC000001B): return "STATUS_UNABLE_TO_DELETE_SECTION";
                case unchecked((NtStatusCodes)0xC000001C): return "STATUS_INVALID_SYSTEM_SERVICE";
                case unchecked((NtStatusCodes)0xC000001D): return "STATUS_ILLEGAL_INSTRUCTION";
                case unchecked((NtStatusCodes)0xC000001E): return "STATUS_INVALID_LOCK_SEQUENCE";
                case unchecked((NtStatusCodes)0xC000001F): return "STATUS_INVALID_VIEW_SIZE";
                case unchecked((NtStatusCodes)0xC0000020): return "STATUS_INVALID_FILE_FOR_SECTION";
                case unchecked((NtStatusCodes)0xC0000021): return "STATUS_ALREADY_COMMITTED";
                case unchecked((NtStatusCodes)0xC0000022): return "STATUS_ACCESS_DENIED";
                case unchecked((NtStatusCodes)0xC0000023): return "STATUS_BUFFER_TOO_SMALL";
                case unchecked((NtStatusCodes)0xC0000024): return "STATUS_OBJECT_TYPE_MISMATCH";
                case unchecked((NtStatusCodes)0xC0000025): return "STATUS_NONCONTINUABLE_EXCEPTION";
                case unchecked((NtStatusCodes)0xC0000026): return "STATUS_INVALID_DISPOSITION";
                case unchecked((NtStatusCodes)0xC0000027): return "STATUS_UNWIND";
                case unchecked((NtStatusCodes)0xC0000028): return "STATUS_BAD_STACK";
                case unchecked((NtStatusCodes)0xC0000029): return "STATUS_INVALID_UNWIND_TARGET";
                case unchecked((NtStatusCodes)0xC000002A): return "STATUS_NOT_LOCKED";
                case unchecked((NtStatusCodes)0xC000002B): return "STATUS_PARITY_ERROR";
                case unchecked((NtStatusCodes)0xC000002C): return "STATUS_UNABLE_TO_DECOMMIT_VM";
                case unchecked((NtStatusCodes)0xC000002D): return "STATUS_NOT_COMMITTED";
                case unchecked((NtStatusCodes)0xC000002E): return "STATUS_INVALID_PORT_ATTRIBUTES";
                case unchecked((NtStatusCodes)0xC000002F): return "STATUS_PORT_MESSAGE_TOO_LONG";
                case unchecked((NtStatusCodes)0xC0000030): return "STATUS_INVALID_PARAMETER_MIX";
                case unchecked((NtStatusCodes)0xC0000031): return "STATUS_INVALID_QUOTA_LOWER";
                case unchecked((NtStatusCodes)0xC0000032): return "STATUS_DISK_CORRUPT_ERROR";
                case unchecked((NtStatusCodes)0xC0000033): return "STATUS_OBJECT_NAME_INVALID";
                case unchecked((NtStatusCodes)0xC0000034): return "STATUS_OBJECT_NAME_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000035): return "STATUS_OBJECT_NAME_COLLISION";
                case unchecked((NtStatusCodes)0xC0000036): return "STATUS_PORT_DO_NOT_DISTURB";
                case unchecked((NtStatusCodes)0xC0000037): return "STATUS_PORT_DISCONNECTED";
                case unchecked((NtStatusCodes)0xC0000038): return "STATUS_DEVICE_ALREADY_ATTACHED";
                case unchecked((NtStatusCodes)0xC0000039): return "STATUS_OBJECT_PATH_INVALID";
                case unchecked((NtStatusCodes)0xC000003A): return "STATUS_OBJECT_PATH_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC000003B): return "STATUS_OBJECT_PATH_SYNTAX_BAD";
                case unchecked((NtStatusCodes)0xC000003C): return "STATUS_DATA_OVERRUN";
                case unchecked((NtStatusCodes)0xC000003D): return "STATUS_DATA_LATE_ERROR";
                case unchecked((NtStatusCodes)0xC000003E): return "STATUS_DATA_ERROR";
                case unchecked((NtStatusCodes)0xC000003F): return "STATUS_CRC_ERROR";
                case unchecked((NtStatusCodes)0xC0000040): return "STATUS_SECTION_TOO_BIG";
                case unchecked((NtStatusCodes)0xC0000041): return "STATUS_PORT_CONNECTION_REFUSED";
                case unchecked((NtStatusCodes)0xC0000042): return "STATUS_INVALID_PORT_HANDLE";
                case unchecked((NtStatusCodes)0xC0000043): return "STATUS_SHARING_VIOLATION";
                case unchecked((NtStatusCodes)0xC0000044): return "STATUS_QUOTA_EXCEEDED";
                case unchecked((NtStatusCodes)0xC0000045): return "STATUS_INVALID_PAGE_PROTECTION";
                case unchecked((NtStatusCodes)0xC0000046): return "STATUS_MUTANT_NOT_OWNED";
                case unchecked((NtStatusCodes)0xC0000047): return "STATUS_SEMAPHORE_LIMIT_EXCEEDED";
                case unchecked((NtStatusCodes)0xC0000048): return "STATUS_PORT_ALREADY_SET";
                case unchecked((NtStatusCodes)0xC0000049): return "STATUS_SECTION_NOT_IMAGE";
                case unchecked((NtStatusCodes)0xC000004A): return "STATUS_SUSPEND_COUNT_EXCEEDED";
                case unchecked((NtStatusCodes)0xC000004B): return "STATUS_THREAD_IS_TERMINATING";
                case unchecked((NtStatusCodes)0xC000004C): return "STATUS_BAD_WORKING_SET_LIMIT";
                case unchecked((NtStatusCodes)0xC000004D): return "STATUS_INCOMPATIBLE_FILE_MAP";
                case unchecked((NtStatusCodes)0xC000004E): return "STATUS_SECTION_PROTECTION";
                case unchecked((NtStatusCodes)0xC000004F): return "STATUS_EAS_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0000050): return "STATUS_EA_TOO_LARGE";
                case unchecked((NtStatusCodes)0xC0000051): return "STATUS_NONEXISTENT_EA_ENTRY";
                case unchecked((NtStatusCodes)0xC0000052): return "STATUS_NO_EAS_ON_FILE";
                case unchecked((NtStatusCodes)0xC0000053): return "STATUS_EA_CORRUPT_ERROR";
                case unchecked((NtStatusCodes)0xC0000054): return "STATUS_FILE_LOCK_CONFLICT";
                case unchecked((NtStatusCodes)0xC0000055): return "STATUS_LOCK_NOT_GRANTED";
                case unchecked((NtStatusCodes)0xC0000056): return "STATUS_DELETE_PENDING";
                case unchecked((NtStatusCodes)0xC0000057): return "STATUS_CTL_FILE_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0000058): return "STATUS_UNKNOWN_REVISION";
                case unchecked((NtStatusCodes)0xC0000059): return "STATUS_REVISION_MISMATCH";
                case unchecked((NtStatusCodes)0xC000005A): return "STATUS_INVALID_OWNER";
                case unchecked((NtStatusCodes)0xC000005B): return "STATUS_INVALID_PRIMARY_GROUP";
                case unchecked((NtStatusCodes)0xC000005C): return "STATUS_NO_IMPERSONATION_TOKEN";
                case unchecked((NtStatusCodes)0xC000005D): return "STATUS_CANT_DISABLE_MANDATORY";
                case unchecked((NtStatusCodes)0xC000005E): return "STATUS_NO_LOGON_SERVERS";
                case unchecked((NtStatusCodes)0xC000005F): return "STATUS_NO_SUCH_LOGON_SESSION";
                case unchecked((NtStatusCodes)0xC0000060): return "STATUS_NO_SUCH_PRIVILEGE";
                case unchecked((NtStatusCodes)0xC0000061): return "STATUS_PRIVILEGE_NOT_HELD";
                case unchecked((NtStatusCodes)0xC0000062): return "STATUS_INVALID_ACCOUNT_NAME";
                case unchecked((NtStatusCodes)0xC0000063): return "STATUS_USER_EXISTS";
                case unchecked((NtStatusCodes)0xC0000064): return "STATUS_NO_SUCH_USER";
                case unchecked((NtStatusCodes)0xC0000065): return "STATUS_GROUP_EXISTS";
                case unchecked((NtStatusCodes)0xC0000066): return "STATUS_NO_SUCH_GROUP";
                case unchecked((NtStatusCodes)0xC0000067): return "STATUS_MEMBER_IN_GROUP";
                case unchecked((NtStatusCodes)0xC0000068): return "STATUS_MEMBER_NOT_IN_GROUP";
                case unchecked((NtStatusCodes)0xC0000069): return "STATUS_LAST_ADMIN";
                case unchecked((NtStatusCodes)0xC000006A): return "STATUS_WRONG_PASSWORD";
                case unchecked((NtStatusCodes)0xC000006B): return "STATUS_ILL_FORMED_PASSWORD";
                case unchecked((NtStatusCodes)0xC000006C): return "STATUS_PASSWORD_RESTRICTION";
                case unchecked((NtStatusCodes)0xC000006D): return "STATUS_LOGON_FAILURE";
                case unchecked((NtStatusCodes)0xC000006E): return "STATUS_ACCOUNT_RESTRICTION";
                case unchecked((NtStatusCodes)0xC000006F): return "STATUS_INVALID_LOGON_HOURS";
                case unchecked((NtStatusCodes)0xC0000070): return "STATUS_INVALID_WORKSTATION";
                case unchecked((NtStatusCodes)0xC0000071): return "STATUS_PASSWORD_EXPIRED";
                case unchecked((NtStatusCodes)0xC0000072): return "STATUS_ACCOUNT_DISABLED";
                case unchecked((NtStatusCodes)0xC0000073): return "STATUS_NONE_MAPPED";
                case unchecked((NtStatusCodes)0xC0000074): return "STATUS_TOO_MANY_LUIDS_REQUESTED";
                case unchecked((NtStatusCodes)0xC0000075): return "STATUS_LUIDS_EXHAUSTED";
                case unchecked((NtStatusCodes)0xC0000076): return "STATUS_INVALID_SUB_AUTHORITY";
                case unchecked((NtStatusCodes)0xC0000077): return "STATUS_INVALID_ACL";
                case unchecked((NtStatusCodes)0xC0000078): return "STATUS_INVALID_SID";
                case unchecked((NtStatusCodes)0xC0000079): return "STATUS_INVALID_SECURITY_DESCR";
                case unchecked((NtStatusCodes)0xC000007A): return "STATUS_PROCEDURE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC000007B): return "STATUS_INVALID_IMAGE_FORMAT";
                case unchecked((NtStatusCodes)0xC000007C): return "STATUS_NO_TOKEN";
                case unchecked((NtStatusCodes)0xC000007D): return "STATUS_BAD_INHERITANCE_ACL";
                case unchecked((NtStatusCodes)0xC000007E): return "STATUS_RANGE_NOT_LOCKED";
                case unchecked((NtStatusCodes)0xC000007F): return "STATUS_DISK_FULL";
                case unchecked((NtStatusCodes)0xC0000080): return "STATUS_SERVER_DISABLED";
                case unchecked((NtStatusCodes)0xC0000081): return "STATUS_SERVER_NOT_DISABLED";
                case unchecked((NtStatusCodes)0xC0000082): return "STATUS_TOO_MANY_GUIDS_REQUESTED";
                case unchecked((NtStatusCodes)0xC0000083): return "STATUS_GUIDS_EXHAUSTED";
                case unchecked((NtStatusCodes)0xC0000084): return "STATUS_INVALID_ID_AUTHORITY";
                case unchecked((NtStatusCodes)0xC0000085): return "STATUS_AGENTS_EXHAUSTED";
                case unchecked((NtStatusCodes)0xC0000086): return "STATUS_INVALID_VOLUME_LABEL";
                case unchecked((NtStatusCodes)0xC0000087): return "STATUS_SECTION_NOT_EXTENDED";
                case unchecked((NtStatusCodes)0xC0000088): return "STATUS_NOT_MAPPED_DATA";
                case unchecked((NtStatusCodes)0xC0000089): return "STATUS_RESOURCE_DATA_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC000008A): return "STATUS_RESOURCE_TYPE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC000008B): return "STATUS_RESOURCE_NAME_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC000008C): return "STATUS_ARRAY_BOUNDS_EXCEEDED";
                case unchecked((NtStatusCodes)0xC000008D): return "STATUS_FLOAT_DENORMAL_OPERAND";
                case unchecked((NtStatusCodes)0xC000008E): return "STATUS_FLOAT_DIVIDE_BY_ZERO";
                case unchecked((NtStatusCodes)0xC000008F): return "STATUS_FLOAT_INEXACT_RESULT";
                case unchecked((NtStatusCodes)0xC0000090): return "STATUS_FLOAT_INVALID_OPERATION";
                case unchecked((NtStatusCodes)0xC0000091): return "STATUS_FLOAT_OVERFLOW";
                case unchecked((NtStatusCodes)0xC0000092): return "STATUS_FLOAT_STACK_CHECK";
                case unchecked((NtStatusCodes)0xC0000093): return "STATUS_FLOAT_UNDERFLOW";
                case unchecked((NtStatusCodes)0xC0000094): return "STATUS_INTEGER_DIVIDE_BY_ZERO";
                case unchecked((NtStatusCodes)0xC0000095): return "STATUS_INTEGER_OVERFLOW";
                case unchecked((NtStatusCodes)0xC0000096): return "STATUS_PRIVILEGED_INSTRUCTION";
                case unchecked((NtStatusCodes)0xC0000097): return "STATUS_TOO_MANY_PAGING_FILES";
                case unchecked((NtStatusCodes)0xC0000098): return "STATUS_FILE_INVALID";
                case unchecked((NtStatusCodes)0xC0000099): return "STATUS_ALLOTTED_SPACE_EXCEEDED";
                case unchecked((NtStatusCodes)0xC000009A): return "STATUS_INSUFFICIENT_RESOURCES";
                case unchecked((NtStatusCodes)0xC000009B): return "STATUS_DFS_EXIT_PATH_FOUND";
                case unchecked((NtStatusCodes)0xC000009C): return "STATUS_DEVICE_DATA_ERROR";
                case unchecked((NtStatusCodes)0xC000009D): return "STATUS_DEVICE_NOT_CONNECTED";
                case unchecked((NtStatusCodes)0xC000009E): return "STATUS_DEVICE_POWER_FAILURE";
                case unchecked((NtStatusCodes)0xC000009F): return "STATUS_FREE_VM_NOT_AT_BASE";
                case unchecked((NtStatusCodes)0xC00000A0): return "STATUS_MEMORY_NOT_ALLOCATED";
                case unchecked((NtStatusCodes)0xC00000A1): return "STATUS_WORKING_SET_QUOTA";
                case unchecked((NtStatusCodes)0xC00000A2): return "STATUS_MEDIA_WRITE_PROTECTED";
                case unchecked((NtStatusCodes)0xC00000A3): return "STATUS_DEVICE_NOT_READY";
                case unchecked((NtStatusCodes)0xC00000A4): return "STATUS_INVALID_GROUP_ATTRIBUTES";
                case unchecked((NtStatusCodes)0xC00000A5): return "STATUS_BAD_IMPERSONATION_LEVEL";
                case unchecked((NtStatusCodes)0xC00000A6): return "STATUS_CANT_OPEN_ANONYMOUS";
                case unchecked((NtStatusCodes)0xC00000A7): return "STATUS_BAD_VALIDATION_CLASS";
                case unchecked((NtStatusCodes)0xC00000A8): return "STATUS_BAD_TOKEN_TYPE";
                case unchecked((NtStatusCodes)0xC00000A9): return "STATUS_BAD_MASTER_BOOT_RECORD";
                case unchecked((NtStatusCodes)0xC00000AA): return "STATUS_INSTRUCTION_MISALIGNMENT";
                case unchecked((NtStatusCodes)0xC00000AB): return "STATUS_INSTANCE_NOT_AVAILABLE";
                case unchecked((NtStatusCodes)0xC00000AC): return "STATUS_PIPE_NOT_AVAILABLE";
                case unchecked((NtStatusCodes)0xC00000AD): return "STATUS_INVALID_PIPE_STATE";
                case unchecked((NtStatusCodes)0xC00000AE): return "STATUS_PIPE_BUSY";
                case unchecked((NtStatusCodes)0xC00000AF): return "STATUS_ILLEGAL_FUNCTION";
                case unchecked((NtStatusCodes)0xC00000B0): return "STATUS_PIPE_DISCONNECTED";
                case unchecked((NtStatusCodes)0xC00000B1): return "STATUS_PIPE_CLOSING";
                case unchecked((NtStatusCodes)0xC00000B2): return "STATUS_PIPE_CONNECTED";
                case unchecked((NtStatusCodes)0xC00000B3): return "STATUS_PIPE_LISTENING";
                case unchecked((NtStatusCodes)0xC00000B4): return "STATUS_INVALID_READ_MODE";
                case unchecked((NtStatusCodes)0xC00000B5): return "STATUS_IO_TIMEOUT";
                case unchecked((NtStatusCodes)0xC00000B6): return "STATUS_FILE_FORCED_CLOSED";
                case unchecked((NtStatusCodes)0xC00000B7): return "STATUS_PROFILING_NOT_STARTED";
                case unchecked((NtStatusCodes)0xC00000B8): return "STATUS_PROFILING_NOT_STOPPED";
                case unchecked((NtStatusCodes)0xC00000B9): return "STATUS_COULD_NOT_INTERPRET";
                case unchecked((NtStatusCodes)0xC00000BA): return "STATUS_FILE_IS_A_DIRECTORY";
                case unchecked((NtStatusCodes)0xC00000BB): return "STATUS_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC00000BC): return "STATUS_REMOTE_NOT_LISTENING";
                case unchecked((NtStatusCodes)0xC00000BD): return "STATUS_DUPLICATE_NAME";
                case unchecked((NtStatusCodes)0xC00000BE): return "STATUS_BAD_NETWORK_PATH";
                case unchecked((NtStatusCodes)0xC00000BF): return "STATUS_NETWORK_BUSY";
                case unchecked((NtStatusCodes)0xC00000C0): return "STATUS_DEVICE_DOES_NOT_EXIST";
                case unchecked((NtStatusCodes)0xC00000C1): return "STATUS_TOO_MANY_COMMANDS";
                case unchecked((NtStatusCodes)0xC00000C2): return "STATUS_ADAPTER_HARDWARE_ERROR";
                case unchecked((NtStatusCodes)0xC00000C3): return "STATUS_INVALID_NETWORK_RESPONSE";
                case unchecked((NtStatusCodes)0xC00000C4): return "STATUS_UNEXPECTED_NETWORK_ERROR";
                case unchecked((NtStatusCodes)0xC00000C5): return "STATUS_BAD_REMOTE_ADAPTER";
                case unchecked((NtStatusCodes)0xC00000C6): return "STATUS_PRINT_QUEUE_FULL";
                case unchecked((NtStatusCodes)0xC00000C7): return "STATUS_NO_SPOOL_SPACE";
                case unchecked((NtStatusCodes)0xC00000C8): return "STATUS_PRINT_CANCELLED";
                case unchecked((NtStatusCodes)0xC00000C9): return "STATUS_NETWORK_NAME_DELETED";
                case unchecked((NtStatusCodes)0xC00000CA): return "STATUS_NETWORK_ACCESS_DENIED";
                case unchecked((NtStatusCodes)0xC00000CB): return "STATUS_BAD_DEVICE_TYPE";
                case unchecked((NtStatusCodes)0xC00000CC): return "STATUS_BAD_NETWORK_NAME";
                case unchecked((NtStatusCodes)0xC00000CD): return "STATUS_TOO_MANY_NAMES";
                case unchecked((NtStatusCodes)0xC00000CE): return "STATUS_TOO_MANY_SESSIONS";
                case unchecked((NtStatusCodes)0xC00000CF): return "STATUS_SHARING_PAUSED";
                case unchecked((NtStatusCodes)0xC00000D0): return "STATUS_REQUEST_NOT_ACCEPTED";
                case unchecked((NtStatusCodes)0xC00000D1): return "STATUS_REDIRECTOR_PAUSED";
                case unchecked((NtStatusCodes)0xC00000D2): return "STATUS_NET_WRITE_FAULT";
                case unchecked((NtStatusCodes)0xC00000D3): return "STATUS_PROFILING_AT_LIMIT";
                case unchecked((NtStatusCodes)0xC00000D4): return "STATUS_NOT_SAME_DEVICE";
                case unchecked((NtStatusCodes)0xC00000D5): return "STATUS_FILE_RENAMED";
                case unchecked((NtStatusCodes)0xC00000D6): return "STATUS_VIRTUAL_CIRCUIT_CLOSED";
                case unchecked((NtStatusCodes)0xC00000D7): return "STATUS_NO_SECURITY_ON_OBJECT";
                case unchecked((NtStatusCodes)0xC00000D8): return "STATUS_CANT_WAIT";
                case unchecked((NtStatusCodes)0xC00000D9): return "STATUS_PIPE_EMPTY";
                case unchecked((NtStatusCodes)0xC00000DA): return "STATUS_CANT_ACCESS_DOMAIN_INFO";
                case unchecked((NtStatusCodes)0xC00000DB): return "STATUS_CANT_TERMINATE_SELF";
                case unchecked((NtStatusCodes)0xC00000DC): return "STATUS_INVALID_SERVER_STATE";
                case unchecked((NtStatusCodes)0xC00000DD): return "STATUS_INVALID_DOMAIN_STATE";
                case unchecked((NtStatusCodes)0xC00000DE): return "STATUS_INVALID_DOMAIN_ROLE";
                case unchecked((NtStatusCodes)0xC00000DF): return "STATUS_NO_SUCH_DOMAIN";
                case unchecked((NtStatusCodes)0xC00000E0): return "STATUS_DOMAIN_EXISTS";
                case unchecked((NtStatusCodes)0xC00000E1): return "STATUS_DOMAIN_LIMIT_EXCEEDED";
                case unchecked((NtStatusCodes)0xC00000E2): return "STATUS_OPLOCK_NOT_GRANTED";
                case unchecked((NtStatusCodes)0xC00000E3): return "STATUS_INVALID_OPLOCK_PROTOCOL";
                case unchecked((NtStatusCodes)0xC00000E4): return "STATUS_INTERNAL_DB_CORRUPTION";
                case unchecked((NtStatusCodes)0xC00000E5): return "STATUS_INTERNAL_ERROR";
                case unchecked((NtStatusCodes)0xC00000E6): return "STATUS_GENERIC_NOT_MAPPED";
                case unchecked((NtStatusCodes)0xC00000E7): return "STATUS_BAD_DESCRIPTOR_FORMAT";
                case unchecked((NtStatusCodes)0xC00000E8): return "STATUS_INVALID_USER_BUFFER";
                case unchecked((NtStatusCodes)0xC00000E9): return "STATUS_UNEXPECTED_IO_ERROR";
                case unchecked((NtStatusCodes)0xC00000EA): return "STATUS_UNEXPECTED_MM_CREATE_ERR";
                case unchecked((NtStatusCodes)0xC00000EB): return "STATUS_UNEXPECTED_MM_MAP_ERROR";
                case unchecked((NtStatusCodes)0xC00000EC): return "STATUS_UNEXPECTED_MM_EXTEND_ERR";
                case unchecked((NtStatusCodes)0xC00000ED): return "STATUS_NOT_LOGON_PROCESS";
                case unchecked((NtStatusCodes)0xC00000EE): return "STATUS_LOGON_SESSION_EXISTS";
                case unchecked((NtStatusCodes)0xC00000EF): return "STATUS_INVALID_PARAMETER_1";
                case unchecked((NtStatusCodes)0xC00000F0): return "STATUS_INVALID_PARAMETER_2";
                case unchecked((NtStatusCodes)0xC00000F1): return "STATUS_INVALID_PARAMETER_3";
                case unchecked((NtStatusCodes)0xC00000F2): return "STATUS_INVALID_PARAMETER_4";
                case unchecked((NtStatusCodes)0xC00000F3): return "STATUS_INVALID_PARAMETER_5";
                case unchecked((NtStatusCodes)0xC00000F4): return "STATUS_INVALID_PARAMETER_6";
                case unchecked((NtStatusCodes)0xC00000F5): return "STATUS_INVALID_PARAMETER_7";
                case unchecked((NtStatusCodes)0xC00000F6): return "STATUS_INVALID_PARAMETER_8";
                case unchecked((NtStatusCodes)0xC00000F7): return "STATUS_INVALID_PARAMETER_9";
                case unchecked((NtStatusCodes)0xC00000F8): return "STATUS_INVALID_PARAMETER_10";
                case unchecked((NtStatusCodes)0xC00000F9): return "STATUS_INVALID_PARAMETER_11";
                case unchecked((NtStatusCodes)0xC00000FA): return "STATUS_INVALID_PARAMETER_12";
                case unchecked((NtStatusCodes)0xC00000FB): return "STATUS_REDIRECTOR_NOT_STARTED";
                case unchecked((NtStatusCodes)0xC00000FC): return "STATUS_REDIRECTOR_STARTED";
                case unchecked((NtStatusCodes)0xC00000FD): return "STATUS_STACK_OVERFLOW";
                case unchecked((NtStatusCodes)0xC00000FE): return "STATUS_NO_SUCH_PACKAGE";
                case unchecked((NtStatusCodes)0xC00000FF): return "STATUS_BAD_FUNCTION_TABLE";
                case unchecked((NtStatusCodes)0xC0000100): return "STATUS_VARIABLE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000101): return "STATUS_DIRECTORY_NOT_EMPTY";
                case unchecked((NtStatusCodes)0xC0000102): return "STATUS_FILE_CORRUPT_ERROR";
                case unchecked((NtStatusCodes)0xC0000103): return "STATUS_NOT_A_DIRECTORY";
                case unchecked((NtStatusCodes)0xC0000104): return "STATUS_BAD_LOGON_SESSION_STATE";
                case unchecked((NtStatusCodes)0xC0000105): return "STATUS_LOGON_SESSION_COLLISION";
                case unchecked((NtStatusCodes)0xC0000106): return "STATUS_NAME_TOO_LONG";
                case unchecked((NtStatusCodes)0xC0000107): return "STATUS_FILES_OPEN";
                case unchecked((NtStatusCodes)0xC0000108): return "STATUS_CONNECTION_IN_USE";
                case unchecked((NtStatusCodes)0xC0000109): return "STATUS_MESSAGE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC000010A): return "STATUS_PROCESS_IS_TERMINATING";
                case unchecked((NtStatusCodes)0xC000010B): return "STATUS_INVALID_LOGON_TYPE";
                case unchecked((NtStatusCodes)0xC000010C): return "STATUS_NO_GUID_TRANSLATION";
                case unchecked((NtStatusCodes)0xC000010D): return "STATUS_CANNOT_IMPERSONATE";
                case unchecked((NtStatusCodes)0xC000010E): return "STATUS_IMAGE_ALREADY_LOADED";
                case unchecked((NtStatusCodes)0xC000010F): return "STATUS_ABIOS_NOT_PRESENT";
                case unchecked((NtStatusCodes)0xC0000110): return "STATUS_ABIOS_LID_NOT_EXIST";
                case unchecked((NtStatusCodes)0xC0000111): return "STATUS_ABIOS_LID_ALREADY_OWNED";
                case unchecked((NtStatusCodes)0xC0000112): return "STATUS_ABIOS_NOT_LID_OWNER";
                case unchecked((NtStatusCodes)0xC0000113): return "STATUS_ABIOS_INVALID_COMMAND";
                case unchecked((NtStatusCodes)0xC0000114): return "STATUS_ABIOS_INVALID_LID";
                case unchecked((NtStatusCodes)0xC0000115): return "STATUS_ABIOS_SELECTOR_NOT_AVAILABLE";
                case unchecked((NtStatusCodes)0xC0000116): return "STATUS_ABIOS_INVALID_SELECTOR";
                case unchecked((NtStatusCodes)0xC0000117): return "STATUS_NO_LDT";
                case unchecked((NtStatusCodes)0xC0000118): return "STATUS_INVALID_LDT_SIZE";
                case unchecked((NtStatusCodes)0xC0000119): return "STATUS_INVALID_LDT_OFFSET";
                case unchecked((NtStatusCodes)0xC000011A): return "STATUS_INVALID_LDT_DESCRIPTOR";
                case unchecked((NtStatusCodes)0xC000011B): return "STATUS_INVALID_IMAGE_NE_FORMAT";
                case unchecked((NtStatusCodes)0xC000011C): return "STATUS_RXACT_INVALID_STATE";
                case unchecked((NtStatusCodes)0xC000011D): return "STATUS_RXACT_COMMIT_FAILURE";
                case unchecked((NtStatusCodes)0xC000011E): return "STATUS_MAPPED_FILE_SIZE_ZERO";
                case unchecked((NtStatusCodes)0xC000011F): return "STATUS_TOO_MANY_OPENED_FILES";
                case unchecked((NtStatusCodes)0xC0000120): return "STATUS_CANCELLED";
                case unchecked((NtStatusCodes)0xC0000121): return "STATUS_CANNOT_DELETE";
                case unchecked((NtStatusCodes)0xC0000122): return "STATUS_INVALID_COMPUTER_NAME";
                case unchecked((NtStatusCodes)0xC0000123): return "STATUS_FILE_DELETED";
                case unchecked((NtStatusCodes)0xC0000124): return "STATUS_SPECIAL_ACCOUNT";
                case unchecked((NtStatusCodes)0xC0000125): return "STATUS_SPECIAL_GROUP";
                case unchecked((NtStatusCodes)0xC0000126): return "STATUS_SPECIAL_USER";
                case unchecked((NtStatusCodes)0xC0000127): return "STATUS_MEMBERS_PRIMARY_GROUP";
                case unchecked((NtStatusCodes)0xC0000128): return "STATUS_FILE_CLOSED";
                case unchecked((NtStatusCodes)0xC0000129): return "STATUS_TOO_MANY_THREADS";
                case unchecked((NtStatusCodes)0xC000012A): return "STATUS_THREAD_NOT_IN_PROCESS";
                case unchecked((NtStatusCodes)0xC000012B): return "STATUS_TOKEN_ALREADY_IN_USE";
                case unchecked((NtStatusCodes)0xC000012C): return "STATUS_PAGEFILE_QUOTA_EXCEEDED";
                case unchecked((NtStatusCodes)0xC000012D): return "STATUS_COMMITMENT_LIMIT";
                case unchecked((NtStatusCodes)0xC000012E): return "STATUS_INVALID_IMAGE_LE_FORMAT";
                case unchecked((NtStatusCodes)0xC000012F): return "STATUS_INVALID_IMAGE_NOT_MZ";
                case unchecked((NtStatusCodes)0xC0000130): return "STATUS_INVALID_IMAGE_PROTECT";
                case unchecked((NtStatusCodes)0xC0000131): return "STATUS_INVALID_IMAGE_WIN_16";
                case unchecked((NtStatusCodes)0xC0000132): return "STATUS_LOGON_SERVER_CONFLICT";
                case unchecked((NtStatusCodes)0xC0000133): return "STATUS_TIME_DIFFERENCE_AT_DC";
                case unchecked((NtStatusCodes)0xC0000134): return "STATUS_SYNCHRONIZATION_REQUIRED";
                case unchecked((NtStatusCodes)0xC0000135): return "STATUS_DLL_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000136): return "STATUS_OPEN_FAILED";
                case unchecked((NtStatusCodes)0xC0000137): return "STATUS_IO_PRIVILEGE_FAILED";
                case unchecked((NtStatusCodes)0xC0000138): return "STATUS_ORDINAL_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000139): return "STATUS_ENTRYPOINT_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC000013A): return "STATUS_CONTROL_C_EXIT";
                case unchecked((NtStatusCodes)0xC000013B): return "STATUS_LOCAL_DISCONNECT";
                case unchecked((NtStatusCodes)0xC000013C): return "STATUS_REMOTE_DISCONNECT";
                case unchecked((NtStatusCodes)0xC000013D): return "STATUS_REMOTE_RESOURCES";
                case unchecked((NtStatusCodes)0xC000013E): return "STATUS_LINK_FAILED";
                case unchecked((NtStatusCodes)0xC000013F): return "STATUS_LINK_TIMEOUT";
                case unchecked((NtStatusCodes)0xC0000140): return "STATUS_INVALID_CONNECTION";
                case unchecked((NtStatusCodes)0xC0000141): return "STATUS_INVALID_ADDRESS";
                case unchecked((NtStatusCodes)0xC0000142): return "STATUS_DLL_INIT_FAILED";
                case unchecked((NtStatusCodes)0xC0000143): return "STATUS_MISSING_SYSTEMFILE";
                case unchecked((NtStatusCodes)0xC0000144): return "STATUS_UNHANDLED_EXCEPTION";
                case unchecked((NtStatusCodes)0xC0000145): return "STATUS_APP_INIT_FAILURE";
                case unchecked((NtStatusCodes)0xC0000146): return "STATUS_PAGEFILE_CREATE_FAILED";
                case unchecked((NtStatusCodes)0xC0000147): return "STATUS_NO_PAGEFILE";
                case unchecked((NtStatusCodes)0xC0000148): return "STATUS_INVALID_LEVEL";
                case unchecked((NtStatusCodes)0xC0000149): return "STATUS_WRONG_PASSWORD_CORE";
                case unchecked((NtStatusCodes)0xC000014A): return "STATUS_ILLEGAL_FLOAT_CONTEXT";
                case unchecked((NtStatusCodes)0xC000014B): return "STATUS_PIPE_BROKEN";
                case unchecked((NtStatusCodes)0xC000014C): return "STATUS_REGISTRY_CORRUPT";
                case unchecked((NtStatusCodes)0xC000014D): return "STATUS_REGISTRY_IO_FAILED";
                case unchecked((NtStatusCodes)0xC000014E): return "STATUS_NO_EVENT_PAIR";
                case unchecked((NtStatusCodes)0xC000014F): return "STATUS_UNRECOGNIZED_VOLUME";
                case unchecked((NtStatusCodes)0xC0000150): return "STATUS_SERIAL_NO_DEVICE_INITED";
                case unchecked((NtStatusCodes)0xC0000151): return "STATUS_NO_SUCH_ALIAS";
                case unchecked((NtStatusCodes)0xC0000152): return "STATUS_MEMBER_NOT_IN_ALIAS";
                case unchecked((NtStatusCodes)0xC0000153): return "STATUS_MEMBER_IN_ALIAS";
                case unchecked((NtStatusCodes)0xC0000154): return "STATUS_ALIAS_EXISTS";
                case unchecked((NtStatusCodes)0xC0000155): return "STATUS_LOGON_NOT_GRANTED";
                case unchecked((NtStatusCodes)0xC0000156): return "STATUS_TOO_MANY_SECRETS";
                case unchecked((NtStatusCodes)0xC0000157): return "STATUS_SECRET_TOO_LONG";
                case unchecked((NtStatusCodes)0xC0000158): return "STATUS_INTERNAL_DB_ERROR";
                case unchecked((NtStatusCodes)0xC0000159): return "STATUS_FULLSCREEN_MODE";
                case unchecked((NtStatusCodes)0xC000015A): return "STATUS_TOO_MANY_CONTEXT_IDS";
                case unchecked((NtStatusCodes)0xC000015B): return "STATUS_LOGON_TYPE_NOT_GRANTED";
                case unchecked((NtStatusCodes)0xC000015C): return "STATUS_NOT_REGISTRY_FILE";
                case unchecked((NtStatusCodes)0xC000015D): return "STATUS_NT_CROSS_ENCRYPTION_REQUIRED";
                case unchecked((NtStatusCodes)0xC000015E): return "STATUS_DOMAIN_CTRLR_CONFIG_ERROR";
                case unchecked((NtStatusCodes)0xC000015F): return "STATUS_FT_MISSING_MEMBER";
                case unchecked((NtStatusCodes)0xC0000160): return "STATUS_ILL_FORMED_SERVICE_ENTRY";
                case unchecked((NtStatusCodes)0xC0000161): return "STATUS_ILLEGAL_CHARACTER";
                case unchecked((NtStatusCodes)0xC0000162): return "STATUS_UNMAPPABLE_CHARACTER";
                case unchecked((NtStatusCodes)0xC0000163): return "STATUS_UNDEFINED_CHARACTER";
                case unchecked((NtStatusCodes)0xC0000164): return "STATUS_FLOPPY_VOLUME";
                case unchecked((NtStatusCodes)0xC0000165): return "STATUS_FLOPPY_ID_MARK_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000166): return "STATUS_FLOPPY_WRONG_CYLINDER";
                case unchecked((NtStatusCodes)0xC0000167): return "STATUS_FLOPPY_UNKNOWN_ERROR";
                case unchecked((NtStatusCodes)0xC0000168): return "STATUS_FLOPPY_BAD_REGISTERS";
                case unchecked((NtStatusCodes)0xC0000169): return "STATUS_DISK_RECALIBRATE_FAILED";
                case unchecked((NtStatusCodes)0xC000016A): return "STATUS_DISK_OPERATION_FAILED";
                case unchecked((NtStatusCodes)0xC000016B): return "STATUS_DISK_RESET_FAILED";
                case unchecked((NtStatusCodes)0xC000016C): return "STATUS_SHARED_IRQ_BUSY";
                case unchecked((NtStatusCodes)0xC000016D): return "STATUS_FT_ORPHANING";
                case unchecked((NtStatusCodes)0xC000016E): return "STATUS_BIOS_FAILED_TO_CONNECT_INTERRUPT";
                case unchecked((NtStatusCodes)0xC0000172): return "STATUS_PARTITION_FAILURE";
                case unchecked((NtStatusCodes)0xC0000173): return "STATUS_INVALID_BLOCK_LENGTH";
                case unchecked((NtStatusCodes)0xC0000174): return "STATUS_DEVICE_NOT_PARTITIONED";
                case unchecked((NtStatusCodes)0xC0000175): return "STATUS_UNABLE_TO_LOCK_MEDIA";
                case unchecked((NtStatusCodes)0xC0000176): return "STATUS_UNABLE_TO_UNLOAD_MEDIA";
                case unchecked((NtStatusCodes)0xC0000177): return "STATUS_EOM_OVERFLOW";
                case unchecked((NtStatusCodes)0xC0000178): return "STATUS_NO_MEDIA";
                case unchecked((NtStatusCodes)0xC000017A): return "STATUS_NO_SUCH_MEMBER";
                case unchecked((NtStatusCodes)0xC000017B): return "STATUS_INVALID_MEMBER";
                case unchecked((NtStatusCodes)0xC000017C): return "STATUS_KEY_DELETED";
                case unchecked((NtStatusCodes)0xC000017D): return "STATUS_NO_LOG_SPACE";
                case unchecked((NtStatusCodes)0xC000017E): return "STATUS_TOO_MANY_SIDS";
                case unchecked((NtStatusCodes)0xC000017F): return "STATUS_LM_CROSS_ENCRYPTION_REQUIRED";
                case unchecked((NtStatusCodes)0xC0000180): return "STATUS_KEY_HAS_CHILDREN";
                case unchecked((NtStatusCodes)0xC0000181): return "STATUS_CHILD_MUST_BE_VOLATILE";
                case unchecked((NtStatusCodes)0xC0000182): return "STATUS_DEVICE_CONFIGURATION_ERROR";
                case unchecked((NtStatusCodes)0xC0000183): return "STATUS_DRIVER_INTERNAL_ERROR";
                case unchecked((NtStatusCodes)0xC0000184): return "STATUS_INVALID_DEVICE_STATE";
                case unchecked((NtStatusCodes)0xC0000185): return "STATUS_IO_DEVICE_ERROR";
                case unchecked((NtStatusCodes)0xC0000186): return "STATUS_DEVICE_PROTOCOL_ERROR";
                case unchecked((NtStatusCodes)0xC0000187): return "STATUS_BACKUP_CONTROLLER";
                case unchecked((NtStatusCodes)0xC0000188): return "STATUS_LOG_FILE_FULL";
                case unchecked((NtStatusCodes)0xC0000189): return "STATUS_TOO_LATE";
                case unchecked((NtStatusCodes)0xC000018A): return "STATUS_NO_TRUST_LSA_SECRET";
                case unchecked((NtStatusCodes)0xC000018B): return "STATUS_NO_TRUST_SAM_ACCOUNT";
                case unchecked((NtStatusCodes)0xC000018C): return "STATUS_TRUSTED_DOMAIN_FAILURE";
                case unchecked((NtStatusCodes)0xC000018D): return "STATUS_TRUSTED_RELATIONSHIP_FAILURE";
                case unchecked((NtStatusCodes)0xC000018E): return "STATUS_EVENTLOG_FILE_CORRUPT";
                case unchecked((NtStatusCodes)0xC000018F): return "STATUS_EVENTLOG_CANT_START";
                case unchecked((NtStatusCodes)0xC0000190): return "STATUS_TRUST_FAILURE";
                case unchecked((NtStatusCodes)0xC0000191): return "STATUS_MUTANT_LIMIT_EXCEEDED";
                case unchecked((NtStatusCodes)0xC0000192): return "STATUS_NETLOGON_NOT_STARTED";
                case unchecked((NtStatusCodes)0xC0000193): return "STATUS_ACCOUNT_EXPIRED";
                case unchecked((NtStatusCodes)0xC0000194): return "STATUS_POSSIBLE_DEADLOCK";
                case unchecked((NtStatusCodes)0xC0000195): return "STATUS_NETWORK_CREDENTIAL_CONFLICT";
                case unchecked((NtStatusCodes)0xC0000196): return "STATUS_REMOTE_SESSION_LIMIT";
                case unchecked((NtStatusCodes)0xC0000197): return "STATUS_EVENTLOG_FILE_CHANGED";
                case unchecked((NtStatusCodes)0xC0000198): return "STATUS_NOLOGON_INTERDOMAIN_TRUST_ACCOUNT";
                case unchecked((NtStatusCodes)0xC0000199): return "STATUS_NOLOGON_WORKSTATION_TRUST_ACCOUNT";
                case unchecked((NtStatusCodes)0xC000019A): return "STATUS_NOLOGON_SERVER_TRUST_ACCOUNT";
                case unchecked((NtStatusCodes)0xC000019B): return "STATUS_DOMAIN_TRUST_INCONSISTENT";
                case unchecked((NtStatusCodes)0xC000019C): return "STATUS_FS_DRIVER_REQUIRED";
                case unchecked((NtStatusCodes)0xC000019D): return "STATUS_IMAGE_ALREADY_LOADED_AS_DLL";
                case unchecked((NtStatusCodes)0xC000019E): return "STATUS_INCOMPATIBLE_WITH_GLOBAL_SHORT_NAME_REGISTRY_SETTING";
                case unchecked((NtStatusCodes)0xC000019F): return "STATUS_SHORT_NAMES_NOT_ENABLED_ON_VOLUME";
                case unchecked((NtStatusCodes)0xC00001A0): return "STATUS_SECURITY_STREAM_IS_INCONSISTENT";
                case unchecked((NtStatusCodes)0xC00001A1): return "STATUS_INVALID_LOCK_RANGE";
                case unchecked((NtStatusCodes)0xC00001A2): return "STATUS_INVALID_ACE_CONDITION";
                case unchecked((NtStatusCodes)0xC00001A3): return "STATUS_IMAGE_SUBSYSTEM_NOT_PRESENT";
                case unchecked((NtStatusCodes)0xC00001A4): return "STATUS_NOTIFICATION_GUID_ALREADY_DEFINED";
                case unchecked((NtStatusCodes)0xC00001A5): return "STATUS_INVALID_EXCEPTION_HANDLER";
                case unchecked((NtStatusCodes)0xC00001A6): return "STATUS_DUPLICATE_PRIVILEGES";
                case unchecked((NtStatusCodes)0xC00001A7): return "STATUS_NOT_ALLOWED_ON_SYSTEM_FILE";
                case unchecked((NtStatusCodes)0xC00001A8): return "STATUS_REPAIR_NEEDED";
                case unchecked((NtStatusCodes)0xC00001A9): return "STATUS_QUOTA_NOT_ENABLED";
                case unchecked((NtStatusCodes)0xC00001AA): return "STATUS_NO_APPLICATION_PACKAGE";
                case unchecked((NtStatusCodes)0xC00001AB): return "STATUS_FILE_METADATA_OPTIMIZATION_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC00001AC): return "STATUS_NOT_SAME_OBJECT";
                case unchecked((NtStatusCodes)0xC00001AD): return "STATUS_FATAL_MEMORY_EXHAUSTION";
                case unchecked((NtStatusCodes)0xC00001AE): return "STATUS_ERROR_PROCESS_NOT_IN_JOB";
                case unchecked((NtStatusCodes)0xC00001AF): return "STATUS_CPU_SET_INVALID";
                case unchecked((NtStatusCodes)0xC00001B0): return "STATUS_IO_DEVICE_INVALID_DATA";
                case unchecked((NtStatusCodes)0xC00001B1): return "STATUS_IO_UNALIGNED_WRITE";
                case unchecked((NtStatusCodes)0xC00001B2): return "STATUS_CONTROL_STACK_VIOLATION";
                case unchecked((NtStatusCodes)0xC00001B3): return "STATUS_WEAK_WHFBKEY_BLOCKED";
                case unchecked((NtStatusCodes)0xC00001B4): return "STATUS_SERVER_TRANSPORT_CONFLICT";
                case unchecked((NtStatusCodes)0xC00001B5): return "STATUS_CERTIFICATE_VALIDATION_PREFERENCE_CONFLICT";
                case unchecked((NtStatusCodes)0x800001B6): return "STATUS_DEVICE_RESET_REQUIRED";
                case unchecked((NtStatusCodes)0xC0000201): return "STATUS_NETWORK_OPEN_RESTRICTION";
                case unchecked((NtStatusCodes)0xC0000202): return "STATUS_NO_USER_SESSION_KEY";
                case unchecked((NtStatusCodes)0xC0000203): return "STATUS_USER_SESSION_DELETED";
                case unchecked((NtStatusCodes)0xC0000204): return "STATUS_RESOURCE_LANG_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000205): return "STATUS_INSUFF_SERVER_RESOURCES";
                case unchecked((NtStatusCodes)0xC0000206): return "STATUS_INVALID_BUFFER_SIZE";
                case unchecked((NtStatusCodes)0xC0000207): return "STATUS_INVALID_ADDRESS_COMPONENT";
                case unchecked((NtStatusCodes)0xC0000208): return "STATUS_INVALID_ADDRESS_WILDCARD";
                case unchecked((NtStatusCodes)0xC0000209): return "STATUS_TOO_MANY_ADDRESSES";
                case unchecked((NtStatusCodes)0xC000020A): return "STATUS_ADDRESS_ALREADY_EXISTS";
                case unchecked((NtStatusCodes)0xC000020B): return "STATUS_ADDRESS_CLOSED";
                case unchecked((NtStatusCodes)0xC000020C): return "STATUS_CONNECTION_DISCONNECTED";
                case unchecked((NtStatusCodes)0xC000020D): return "STATUS_CONNECTION_RESET";
                case unchecked((NtStatusCodes)0xC000020E): return "STATUS_TOO_MANY_NODES";
                case unchecked((NtStatusCodes)0xC000020F): return "STATUS_TRANSACTION_ABORTED";
                case unchecked((NtStatusCodes)0xC0000210): return "STATUS_TRANSACTION_TIMED_OUT";
                case unchecked((NtStatusCodes)0xC0000211): return "STATUS_TRANSACTION_NO_RELEASE";
                case unchecked((NtStatusCodes)0xC0000212): return "STATUS_TRANSACTION_NO_MATCH";
                case unchecked((NtStatusCodes)0xC0000213): return "STATUS_TRANSACTION_RESPONDED";
                case unchecked((NtStatusCodes)0xC0000214): return "STATUS_TRANSACTION_INVALID_ID";
                case unchecked((NtStatusCodes)0xC0000215): return "STATUS_TRANSACTION_INVALID_TYPE";
                case unchecked((NtStatusCodes)0xC0000216): return "STATUS_NOT_SERVER_SESSION";
                case unchecked((NtStatusCodes)0xC0000217): return "STATUS_NOT_CLIENT_SESSION";
                case unchecked((NtStatusCodes)0xC0000218): return "STATUS_CANNOT_LOAD_REGISTRY_FILE";
                case unchecked((NtStatusCodes)0xC0000219): return "STATUS_DEBUG_ATTACH_FAILED";
                case unchecked((NtStatusCodes)0xC000021A): return "STATUS_SYSTEM_PROCESS_TERMINATED";
                case unchecked((NtStatusCodes)0xC000021B): return "STATUS_DATA_NOT_ACCEPTED";
                case unchecked((NtStatusCodes)0xC000021C): return "STATUS_NO_BROWSER_SERVERS_FOUND";
                case unchecked((NtStatusCodes)0xC000021D): return "STATUS_VDM_HARD_ERROR";
                case unchecked((NtStatusCodes)0xC000021E): return "STATUS_DRIVER_CANCEL_TIMEOUT";
                case unchecked((NtStatusCodes)0xC000021F): return "STATUS_REPLY_MESSAGE_MISMATCH";
                case unchecked((NtStatusCodes)0xC0000220): return "STATUS_MAPPED_ALIGNMENT";
                case unchecked((NtStatusCodes)0xC0000221): return "STATUS_IMAGE_CHECKSUM_MISMATCH";
                case unchecked((NtStatusCodes)0xC0000222): return "STATUS_LOST_WRITEBEHIND_DATA";
                case unchecked((NtStatusCodes)0xC0000223): return "STATUS_CLIENT_SERVER_PARAMETERS_INVALID";
                case unchecked((NtStatusCodes)0xC0000224): return "STATUS_PASSWORD_MUST_CHANGE";
                case unchecked((NtStatusCodes)0xC0000225): return "STATUS_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000226): return "STATUS_NOT_TINY_STREAM";
                case unchecked((NtStatusCodes)0xC0000227): return "STATUS_RECOVERY_FAILURE";
                case unchecked((NtStatusCodes)0xC0000228): return "STATUS_STACK_OVERFLOW_READ";
                case unchecked((NtStatusCodes)0xC0000229): return "STATUS_FAIL_CHECK";
                case unchecked((NtStatusCodes)0xC000022A): return "STATUS_DUPLICATE_OBJECTID";
                case unchecked((NtStatusCodes)0xC000022B): return "STATUS_OBJECTID_EXISTS";
                case unchecked((NtStatusCodes)0xC000022C): return "STATUS_CONVERT_TO_LARGE";
                case unchecked((NtStatusCodes)0xC000022D): return "STATUS_RETRY";
                case unchecked((NtStatusCodes)0xC000022E): return "STATUS_FOUND_OUT_OF_SCOPE";
                case unchecked((NtStatusCodes)0xC000022F): return "STATUS_ALLOCATE_BUCKET";
                case unchecked((NtStatusCodes)0xC0000230): return "STATUS_PROPSET_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000231): return "STATUS_MARSHALL_OVERFLOW";
                case unchecked((NtStatusCodes)0xC0000232): return "STATUS_INVALID_VARIANT";
                case unchecked((NtStatusCodes)0xC0000233): return "STATUS_DOMAIN_CONTROLLER_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000234): return "STATUS_ACCOUNT_LOCKED_OUT";
                case unchecked((NtStatusCodes)0xC0000235): return "STATUS_HANDLE_NOT_CLOSABLE";
                case unchecked((NtStatusCodes)0xC0000236): return "STATUS_CONNECTION_REFUSED";
                case unchecked((NtStatusCodes)0xC0000237): return "STATUS_GRACEFUL_DISCONNECT";
                case unchecked((NtStatusCodes)0xC0000238): return "STATUS_ADDRESS_ALREADY_ASSOCIATED";
                case unchecked((NtStatusCodes)0xC0000239): return "STATUS_ADDRESS_NOT_ASSOCIATED";
                case unchecked((NtStatusCodes)0xC000023A): return "STATUS_CONNECTION_INVALID";
                case unchecked((NtStatusCodes)0xC000023B): return "STATUS_CONNECTION_ACTIVE";
                case unchecked((NtStatusCodes)0xC000023C): return "STATUS_NETWORK_UNREACHABLE";
                case unchecked((NtStatusCodes)0xC000023D): return "STATUS_HOST_UNREACHABLE";
                case unchecked((NtStatusCodes)0xC000023E): return "STATUS_PROTOCOL_UNREACHABLE";
                case unchecked((NtStatusCodes)0xC000023F): return "STATUS_PORT_UNREACHABLE";
                case unchecked((NtStatusCodes)0xC0000240): return "STATUS_REQUEST_ABORTED";
                case unchecked((NtStatusCodes)0xC0000241): return "STATUS_CONNECTION_ABORTED";
                case unchecked((NtStatusCodes)0xC0000242): return "STATUS_BAD_COMPRESSION_BUFFER";
                case unchecked((NtStatusCodes)0xC0000243): return "STATUS_USER_MAPPED_FILE";
                case unchecked((NtStatusCodes)0xC0000244): return "STATUS_AUDIT_FAILED";
                case unchecked((NtStatusCodes)0xC0000245): return "STATUS_TIMER_RESOLUTION_NOT_SET";
                case unchecked((NtStatusCodes)0xC0000246): return "STATUS_CONNECTION_COUNT_LIMIT";
                case unchecked((NtStatusCodes)0xC0000247): return "STATUS_LOGIN_TIME_RESTRICTION";
                case unchecked((NtStatusCodes)0xC0000248): return "STATUS_LOGIN_WKSTA_RESTRICTION";
                case unchecked((NtStatusCodes)0xC0000249): return "STATUS_IMAGE_MP_UP_MISMATCH";
                case unchecked((NtStatusCodes)0xC0000250): return "STATUS_INSUFFICIENT_LOGON_INFO";
                case unchecked((NtStatusCodes)0xC0000251): return "STATUS_BAD_DLL_ENTRYPOINT";
                case unchecked((NtStatusCodes)0xC0000252): return "STATUS_BAD_SERVICE_ENTRYPOINT";
                case unchecked((NtStatusCodes)0xC0000253): return "STATUS_LPC_REPLY_LOST";
                case unchecked((NtStatusCodes)0xC0000254): return "STATUS_IP_ADDRESS_CONFLICT1";
                case unchecked((NtStatusCodes)0xC0000255): return "STATUS_IP_ADDRESS_CONFLICT2";
                case unchecked((NtStatusCodes)0xC0000256): return "STATUS_REGISTRY_QUOTA_LIMIT";
                case unchecked((NtStatusCodes)0xC0000257): return "STATUS_PATH_NOT_COVERED";
                case unchecked((NtStatusCodes)0xC0000258): return "STATUS_NO_CALLBACK_ACTIVE";
                case unchecked((NtStatusCodes)0xC0000259): return "STATUS_LICENSE_QUOTA_EXCEEDED";
                case unchecked((NtStatusCodes)0xC000025A): return "STATUS_PWD_TOO_SHORT";
                case unchecked((NtStatusCodes)0xC000025B): return "STATUS_PWD_TOO_RECENT";
                case unchecked((NtStatusCodes)0xC000025C): return "STATUS_PWD_HISTORY_CONFLICT";
                case unchecked((NtStatusCodes)0xC000025E): return "STATUS_PLUGPLAY_NO_DEVICE";
                case unchecked((NtStatusCodes)0xC000025F): return "STATUS_UNSUPPORTED_COMPRESSION";
                case unchecked((NtStatusCodes)0xC0000260): return "STATUS_INVALID_HW_PROFILE";
                case unchecked((NtStatusCodes)0xC0000261): return "STATUS_INVALID_PLUGPLAY_DEVICE_PATH";
                case unchecked((NtStatusCodes)0xC0000262): return "STATUS_DRIVER_ORDINAL_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000263): return "STATUS_DRIVER_ENTRYPOINT_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000264): return "STATUS_RESOURCE_NOT_OWNED";
                case unchecked((NtStatusCodes)0xC0000265): return "STATUS_TOO_MANY_LINKS";
                case unchecked((NtStatusCodes)0xC0000266): return "STATUS_QUOTA_LIST_INCONSISTENT";
                case unchecked((NtStatusCodes)0xC0000267): return "STATUS_FILE_IS_OFFLINE";
                case unchecked((NtStatusCodes)0xC0000268): return "STATUS_EVALUATION_EXPIRATION";
                case unchecked((NtStatusCodes)0xC0000269): return "STATUS_ILLEGAL_DLL_RELOCATION";
                case unchecked((NtStatusCodes)0xC000026A): return "STATUS_LICENSE_VIOLATION";
                case unchecked((NtStatusCodes)0xC000026B): return "STATUS_DLL_INIT_FAILED_LOGOFF";
                case unchecked((NtStatusCodes)0xC000026C): return "STATUS_DRIVER_UNABLE_TO_LOAD";
                case unchecked((NtStatusCodes)0xC000026D): return "STATUS_DFS_UNAVAILABLE";
                case unchecked((NtStatusCodes)0xC000026E): return "STATUS_VOLUME_DISMOUNTED";
                case unchecked((NtStatusCodes)0xC000026F): return "STATUS_WX86_INTERNAL_ERROR";
                case unchecked((NtStatusCodes)0xC0000270): return "STATUS_WX86_FLOAT_STACK_CHECK";
                case unchecked((NtStatusCodes)0xC0000271): return "STATUS_VALIDATE_CONTINUE";
                case unchecked((NtStatusCodes)0xC0000272): return "STATUS_NO_MATCH";
                case unchecked((NtStatusCodes)0xC0000273): return "STATUS_NO_MORE_MATCHES";
                case unchecked((NtStatusCodes)0xC0000275): return "STATUS_NOT_A_REPARSE_POINT";
                case unchecked((NtStatusCodes)0xC0000276): return "STATUS_IO_REPARSE_TAG_INVALID";
                case unchecked((NtStatusCodes)0xC0000277): return "STATUS_IO_REPARSE_TAG_MISMATCH";
                case unchecked((NtStatusCodes)0xC0000278): return "STATUS_IO_REPARSE_DATA_INVALID";
                case unchecked((NtStatusCodes)0xC0000279): return "STATUS_IO_REPARSE_TAG_NOT_HANDLED";
                case unchecked((NtStatusCodes)0xC000027A): return "STATUS_PWD_TOO_LONG";
                case unchecked((NtStatusCodes)0xC000027B): return "STATUS_STOWED_EXCEPTION";
                case unchecked((NtStatusCodes)0xC000027C): return "STATUS_CONTEXT_STOWED_EXCEPTION";
                case unchecked((NtStatusCodes)0xC0000280): return "STATUS_REPARSE_POINT_NOT_RESOLVED";
                case unchecked((NtStatusCodes)0xC0000281): return "STATUS_DIRECTORY_IS_A_REPARSE_POINT";
                case unchecked((NtStatusCodes)0xC0000282): return "STATUS_RANGE_LIST_CONFLICT";
                case unchecked((NtStatusCodes)0xC0000283): return "STATUS_SOURCE_ELEMENT_EMPTY";
                case unchecked((NtStatusCodes)0xC0000284): return "STATUS_DESTINATION_ELEMENT_FULL";
                case unchecked((NtStatusCodes)0xC0000285): return "STATUS_ILLEGAL_ELEMENT_ADDRESS";
                case unchecked((NtStatusCodes)0xC0000286): return "STATUS_MAGAZINE_NOT_PRESENT";
                case unchecked((NtStatusCodes)0xC0000287): return "STATUS_REINITIALIZATION_NEEDED";
                case unchecked((NtStatusCodes)0x80000288): return "STATUS_DEVICE_REQUIRES_CLEANING";
                case unchecked((NtStatusCodes)0x80000289): return "STATUS_DEVICE_DOOR_OPEN";
                case unchecked((NtStatusCodes)0xC000028A): return "STATUS_ENCRYPTION_FAILED";
                case unchecked((NtStatusCodes)0xC000028B): return "STATUS_DECRYPTION_FAILED";
                case unchecked((NtStatusCodes)0xC000028C): return "STATUS_RANGE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC000028D): return "STATUS_NO_RECOVERY_POLICY";
                case unchecked((NtStatusCodes)0xC000028E): return "STATUS_NO_EFS";
                case unchecked((NtStatusCodes)0xC000028F): return "STATUS_WRONG_EFS";
                case unchecked((NtStatusCodes)0xC0000290): return "STATUS_NO_USER_KEYS";
                case unchecked((NtStatusCodes)0xC0000291): return "STATUS_FILE_NOT_ENCRYPTED";
                case unchecked((NtStatusCodes)0xC0000292): return "STATUS_NOT_EXPORT_FORMAT";
                case unchecked((NtStatusCodes)0xC0000293): return "STATUS_FILE_ENCRYPTED";
                case unchecked((NtStatusCodes)0x40000294): return "STATUS_WAKE_SYSTEM";
                case unchecked((NtStatusCodes)0xC0000295): return "STATUS_WMI_GUID_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000296): return "STATUS_WMI_INSTANCE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000297): return "STATUS_WMI_ITEMID_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000298): return "STATUS_WMI_TRY_AGAIN";
                case unchecked((NtStatusCodes)0xC0000299): return "STATUS_SHARED_POLICY";
                case unchecked((NtStatusCodes)0xC000029A): return "STATUS_POLICY_OBJECT_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC000029B): return "STATUS_POLICY_ONLY_IN_DS";
                case unchecked((NtStatusCodes)0xC000029C): return "STATUS_VOLUME_NOT_UPGRADED";
                case unchecked((NtStatusCodes)0xC000029D): return "STATUS_REMOTE_STORAGE_NOT_ACTIVE";
                case unchecked((NtStatusCodes)0xC000029E): return "STATUS_REMOTE_STORAGE_MEDIA_ERROR";
                case unchecked((NtStatusCodes)0xC000029F): return "STATUS_NO_TRACKING_SERVICE";
                case unchecked((NtStatusCodes)0xC00002A0): return "STATUS_SERVER_SID_MISMATCH";
                case unchecked((NtStatusCodes)0xC00002A1): return "STATUS_DS_NO_ATTRIBUTE_OR_VALUE";
                case unchecked((NtStatusCodes)0xC00002A2): return "STATUS_DS_INVALID_ATTRIBUTE_SYNTAX";
                case unchecked((NtStatusCodes)0xC00002A3): return "STATUS_DS_ATTRIBUTE_TYPE_UNDEFINED";
                case unchecked((NtStatusCodes)0xC00002A4): return "STATUS_DS_ATTRIBUTE_OR_VALUE_EXISTS";
                case unchecked((NtStatusCodes)0xC00002A5): return "STATUS_DS_BUSY";
                case unchecked((NtStatusCodes)0xC00002A6): return "STATUS_DS_UNAVAILABLE";
                case unchecked((NtStatusCodes)0xC00002A7): return "STATUS_DS_NO_RIDS_ALLOCATED";
                case unchecked((NtStatusCodes)0xC00002A8): return "STATUS_DS_NO_MORE_RIDS";
                case unchecked((NtStatusCodes)0xC00002A9): return "STATUS_DS_INCORRECT_ROLE_OWNER";
                case unchecked((NtStatusCodes)0xC00002AA): return "STATUS_DS_RIDMGR_INIT_ERROR";
                case unchecked((NtStatusCodes)0xC00002AB): return "STATUS_DS_OBJ_CLASS_VIOLATION";
                case unchecked((NtStatusCodes)0xC00002AC): return "STATUS_DS_CANT_ON_NON_LEAF";
                case unchecked((NtStatusCodes)0xC00002AD): return "STATUS_DS_CANT_ON_RDN";
                case unchecked((NtStatusCodes)0xC00002AE): return "STATUS_DS_CANT_MOD_OBJ_CLASS";
                case unchecked((NtStatusCodes)0xC00002AF): return "STATUS_DS_CROSS_DOM_MOVE_FAILED";
                case unchecked((NtStatusCodes)0xC00002B0): return "STATUS_DS_GC_NOT_AVAILABLE";
                case unchecked((NtStatusCodes)0xC00002B1): return "STATUS_DIRECTORY_SERVICE_REQUIRED";
                case unchecked((NtStatusCodes)0xC00002B2): return "STATUS_REPARSE_ATTRIBUTE_CONFLICT";
                case unchecked((NtStatusCodes)0xC00002B3): return "STATUS_CANT_ENABLE_DENY_ONLY";
                case unchecked((NtStatusCodes)0xC00002B4): return "STATUS_FLOAT_MULTIPLE_FAULTS";
                case unchecked((NtStatusCodes)0xC00002B5): return "STATUS_FLOAT_MULTIPLE_TRAPS";
                case unchecked((NtStatusCodes)0xC00002B6): return "STATUS_DEVICE_REMOVED";
                case unchecked((NtStatusCodes)0xC00002B7): return "STATUS_JOURNAL_DELETE_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC00002B8): return "STATUS_JOURNAL_NOT_ACTIVE";
                case unchecked((NtStatusCodes)0xC00002B9): return "STATUS_NOINTERFACE";
                case unchecked((NtStatusCodes)0xC00002BA): return "STATUS_DS_RIDMGR_DISABLED";
                case unchecked((NtStatusCodes)0xC00002C1): return "STATUS_DS_ADMIN_LIMIT_EXCEEDED";
                case unchecked((NtStatusCodes)0xC00002C2): return "STATUS_DRIVER_FAILED_SLEEP";
                case unchecked((NtStatusCodes)0xC00002C3): return "STATUS_MUTUAL_AUTHENTICATION_FAILED";
                case unchecked((NtStatusCodes)0xC00002C4): return "STATUS_CORRUPT_SYSTEM_FILE";
                case unchecked((NtStatusCodes)0xC00002C5): return "STATUS_DATATYPE_MISALIGNMENT_ERROR";
                case unchecked((NtStatusCodes)0xC00002C6): return "STATUS_WMI_READ_ONLY";
                case unchecked((NtStatusCodes)0xC00002C7): return "STATUS_WMI_SET_FAILURE";
                case unchecked((NtStatusCodes)0xC00002C8): return "STATUS_COMMITMENT_MINIMUM";
                case unchecked((NtStatusCodes)0xC00002C9): return "STATUS_REG_NAT_CONSUMPTION";
                case unchecked((NtStatusCodes)0xC00002CA): return "STATUS_TRANSPORT_FULL";
                case unchecked((NtStatusCodes)0xC00002CB): return "STATUS_DS_SAM_INIT_FAILURE";
                case unchecked((NtStatusCodes)0xC00002CC): return "STATUS_ONLY_IF_CONNECTED";
                case unchecked((NtStatusCodes)0xC00002CD): return "STATUS_DS_SENSITIVE_GROUP_VIOLATION";
                case unchecked((NtStatusCodes)0xC00002CE): return "STATUS_PNP_RESTART_ENUMERATION";
                case unchecked((NtStatusCodes)0xC00002CF): return "STATUS_JOURNAL_ENTRY_DELETED";
                case unchecked((NtStatusCodes)0xC00002D0): return "STATUS_DS_CANT_MOD_PRIMARYGROUPID";
                case unchecked((NtStatusCodes)0xC00002D1): return "STATUS_SYSTEM_IMAGE_BAD_SIGNATURE";
                case unchecked((NtStatusCodes)0xC00002D2): return "STATUS_PNP_REBOOT_REQUIRED";
                case unchecked((NtStatusCodes)0xC00002D3): return "STATUS_POWER_STATE_INVALID";
                case unchecked((NtStatusCodes)0xC00002D4): return "STATUS_DS_INVALID_GROUP_TYPE";
                case unchecked((NtStatusCodes)0xC00002D5): return "STATUS_DS_NO_NEST_GLOBALGROUP_IN_MIXEDDOMAIN";
                case unchecked((NtStatusCodes)0xC00002D6): return "STATUS_DS_NO_NEST_LOCALGROUP_IN_MIXEDDOMAIN";
                case unchecked((NtStatusCodes)0xC00002D7): return "STATUS_DS_GLOBAL_CANT_HAVE_LOCAL_MEMBER";
                case unchecked((NtStatusCodes)0xC00002D8): return "STATUS_DS_GLOBAL_CANT_HAVE_UNIVERSAL_MEMBER";
                case unchecked((NtStatusCodes)0xC00002D9): return "STATUS_DS_UNIVERSAL_CANT_HAVE_LOCAL_MEMBER";
                case unchecked((NtStatusCodes)0xC00002DA): return "STATUS_DS_GLOBAL_CANT_HAVE_CROSSDOMAIN_MEMBER";
                case unchecked((NtStatusCodes)0xC00002DB): return "STATUS_DS_LOCAL_CANT_HAVE_CROSSDOMAIN_LOCAL_MEMBER";
                case unchecked((NtStatusCodes)0xC00002DC): return "STATUS_DS_HAVE_PRIMARY_MEMBERS";
                case unchecked((NtStatusCodes)0xC00002DD): return "STATUS_WMI_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC00002DE): return "STATUS_INSUFFICIENT_POWER";
                case unchecked((NtStatusCodes)0xC00002DF): return "STATUS_SAM_NEED_BOOTKEY_PASSWORD";
                case unchecked((NtStatusCodes)0xC00002E0): return "STATUS_SAM_NEED_BOOTKEY_FLOPPY";
                case unchecked((NtStatusCodes)0xC00002E1): return "STATUS_DS_CANT_START";
                case unchecked((NtStatusCodes)0xC00002E2): return "STATUS_DS_INIT_FAILURE";
                case unchecked((NtStatusCodes)0xC00002E3): return "STATUS_SAM_INIT_FAILURE";
                case unchecked((NtStatusCodes)0xC00002E4): return "STATUS_DS_GC_REQUIRED";
                case unchecked((NtStatusCodes)0xC00002E5): return "STATUS_DS_LOCAL_MEMBER_OF_LOCAL_ONLY";
                case unchecked((NtStatusCodes)0xC00002E6): return "STATUS_DS_NO_FPO_IN_UNIVERSAL_GROUPS";
                case unchecked((NtStatusCodes)0xC00002E7): return "STATUS_DS_MACHINE_ACCOUNT_QUOTA_EXCEEDED";
                case unchecked((NtStatusCodes)0xC00002E8): return "STATUS_MULTIPLE_FAULT_VIOLATION";
                case unchecked((NtStatusCodes)0xC00002E9): return "STATUS_CURRENT_DOMAIN_NOT_ALLOWED";
                case unchecked((NtStatusCodes)0xC00002EA): return "STATUS_CANNOT_MAKE";
                case unchecked((NtStatusCodes)0xC00002EB): return "STATUS_SYSTEM_SHUTDOWN";
                case unchecked((NtStatusCodes)0xC00002EC): return "STATUS_DS_INIT_FAILURE_CONSOLE";
                case unchecked((NtStatusCodes)0xC00002ED): return "STATUS_DS_SAM_INIT_FAILURE_CONSOLE";
                case unchecked((NtStatusCodes)0xC00002EE): return "STATUS_UNFINISHED_CONTEXT_DELETED";
                case unchecked((NtStatusCodes)0xC00002EF): return "STATUS_NO_TGT_REPLY";
                case unchecked((NtStatusCodes)0xC00002F0): return "STATUS_OBJECTID_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC00002F1): return "STATUS_NO_IP_ADDRESSES";
                case unchecked((NtStatusCodes)0xC00002F2): return "STATUS_WRONG_CREDENTIAL_HANDLE";
                case unchecked((NtStatusCodes)0xC00002F3): return "STATUS_CRYPTO_SYSTEM_INVALID";
                case unchecked((NtStatusCodes)0xC00002F4): return "STATUS_MAX_REFERRALS_EXCEEDED";
                case unchecked((NtStatusCodes)0xC00002F5): return "STATUS_MUST_BE_KDC";
                case unchecked((NtStatusCodes)0xC00002F6): return "STATUS_STRONG_CRYPTO_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC00002F7): return "STATUS_TOO_MANY_PRINCIPALS";
                case unchecked((NtStatusCodes)0xC00002F8): return "STATUS_NO_PA_DATA";
                case unchecked((NtStatusCodes)0xC00002F9): return "STATUS_PKINIT_NAME_MISMATCH";
                case unchecked((NtStatusCodes)0xC00002FA): return "STATUS_SMARTCARD_LOGON_REQUIRED";
                case unchecked((NtStatusCodes)0xC00002FB): return "STATUS_KDC_INVALID_REQUEST";
                case unchecked((NtStatusCodes)0xC00002FC): return "STATUS_KDC_UNABLE_TO_REFER";
                case unchecked((NtStatusCodes)0xC00002FD): return "STATUS_KDC_UNKNOWN_ETYPE";
                case unchecked((NtStatusCodes)0xC00002FE): return "STATUS_SHUTDOWN_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC00002FF): return "STATUS_SERVER_SHUTDOWN_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC0000300): return "STATUS_NOT_SUPPORTED_ON_SBS";
                case unchecked((NtStatusCodes)0xC0000301): return "STATUS_WMI_GUID_DISCONNECTED";
                case unchecked((NtStatusCodes)0xC0000302): return "STATUS_WMI_ALREADY_DISABLED";
                case unchecked((NtStatusCodes)0xC0000303): return "STATUS_WMI_ALREADY_ENABLED";
                case unchecked((NtStatusCodes)0xC0000304): return "STATUS_MFT_TOO_FRAGMENTED";
                case unchecked((NtStatusCodes)0xC0000305): return "STATUS_COPY_PROTECTION_FAILURE";
                case unchecked((NtStatusCodes)0xC0000306): return "STATUS_CSS_AUTHENTICATION_FAILURE";
                case unchecked((NtStatusCodes)0xC0000307): return "STATUS_CSS_KEY_NOT_PRESENT";
                case unchecked((NtStatusCodes)0xC0000308): return "STATUS_CSS_KEY_NOT_ESTABLISHED";
                case unchecked((NtStatusCodes)0xC0000309): return "STATUS_CSS_SCRAMBLED_SECTOR";
                case unchecked((NtStatusCodes)0xC000030A): return "STATUS_CSS_REGION_MISMATCH";
                case unchecked((NtStatusCodes)0xC000030B): return "STATUS_CSS_RESETS_EXHAUSTED";
                case unchecked((NtStatusCodes)0xC000030C): return "STATUS_PASSWORD_CHANGE_REQUIRED";
                case unchecked((NtStatusCodes)0xC000030D): return "STATUS_LOST_MODE_LOGON_RESTRICTION";
                case unchecked((NtStatusCodes)0xC0000320): return "STATUS_PKINIT_FAILURE";
                case unchecked((NtStatusCodes)0xC0000321): return "STATUS_SMARTCARD_SUBSYSTEM_FAILURE";
                case unchecked((NtStatusCodes)0xC0000322): return "STATUS_NO_KERB_KEY";
                case unchecked((NtStatusCodes)0xC0000350): return "STATUS_HOST_DOWN";
                case unchecked((NtStatusCodes)0xC0000351): return "STATUS_UNSUPPORTED_PREAUTH";
                case unchecked((NtStatusCodes)0xC0000352): return "STATUS_EFS_ALG_BLOB_TOO_BIG";
                case unchecked((NtStatusCodes)0xC0000353): return "STATUS_PORT_NOT_SET";
                case unchecked((NtStatusCodes)0xC0000354): return "STATUS_DEBUGGER_INACTIVE";
                case unchecked((NtStatusCodes)0xC0000355): return "STATUS_DS_VERSION_CHECK_FAILURE";
                case unchecked((NtStatusCodes)0xC0000356): return "STATUS_AUDITING_DISABLED";
                case unchecked((NtStatusCodes)0xC0000357): return "STATUS_PRENT4_MACHINE_ACCOUNT";
                case unchecked((NtStatusCodes)0xC0000358): return "STATUS_DS_AG_CANT_HAVE_UNIVERSAL_MEMBER";
                case unchecked((NtStatusCodes)0xC0000359): return "STATUS_INVALID_IMAGE_WIN_32";
                case unchecked((NtStatusCodes)0xC000035A): return "STATUS_INVALID_IMAGE_WIN_64";
                case unchecked((NtStatusCodes)0xC000035B): return "STATUS_BAD_BINDINGS";
                case unchecked((NtStatusCodes)0xC000035C): return "STATUS_NETWORK_SESSION_EXPIRED";
                case unchecked((NtStatusCodes)0xC000035D): return "STATUS_APPHELP_BLOCK";
                case unchecked((NtStatusCodes)0xC000035E): return "STATUS_ALL_SIDS_FILTERED";
                case unchecked((NtStatusCodes)0xC000035F): return "STATUS_NOT_SAFE_MODE_DRIVER";
                case unchecked((NtStatusCodes)0xC0000361): return "STATUS_ACCESS_DISABLED_BY_POLICY_DEFAULT";
                case unchecked((NtStatusCodes)0xC0000362): return "STATUS_ACCESS_DISABLED_BY_POLICY_PATH";
                case unchecked((NtStatusCodes)0xC0000363): return "STATUS_ACCESS_DISABLED_BY_POLICY_PUBLISHER";
                case unchecked((NtStatusCodes)0xC0000364): return "STATUS_ACCESS_DISABLED_BY_POLICY_OTHER";
                case unchecked((NtStatusCodes)0xC0000365): return "STATUS_FAILED_DRIVER_ENTRY";
                case unchecked((NtStatusCodes)0xC0000366): return "STATUS_DEVICE_ENUMERATION_ERROR";
                case unchecked((NtStatusCodes)0xC0000368): return "STATUS_MOUNT_POINT_NOT_RESOLVED";
                case unchecked((NtStatusCodes)0xC0000369): return "STATUS_INVALID_DEVICE_OBJECT_PARAMETER";
                case unchecked((NtStatusCodes)0xC000036A): return "STATUS_MCA_OCCURED";
                case unchecked((NtStatusCodes)0xC000036B): return "STATUS_DRIVER_BLOCKED_CRITICAL";
                case unchecked((NtStatusCodes)0xC000036C): return "STATUS_DRIVER_BLOCKED";
                case unchecked((NtStatusCodes)0xC000036D): return "STATUS_DRIVER_DATABASE_ERROR";
                case unchecked((NtStatusCodes)0xC000036E): return "STATUS_SYSTEM_HIVE_TOO_LARGE";
                case unchecked((NtStatusCodes)0xC000036F): return "STATUS_INVALID_IMPORT_OF_NON_DLL";
                case unchecked((NtStatusCodes)0x40000370): return "STATUS_DS_SHUTTING_DOWN";
                case unchecked((NtStatusCodes)0xC0000371): return "STATUS_NO_SECRETS";
                case unchecked((NtStatusCodes)0xC0000372): return "STATUS_ACCESS_DISABLED_NO_SAFER_UI_BY_POLICY";
                case unchecked((NtStatusCodes)0xC0000373): return "STATUS_FAILED_STACK_SWITCH";
                case unchecked((NtStatusCodes)0xC0000374): return "STATUS_HEAP_CORRUPTION";
                case unchecked((NtStatusCodes)0xC0000380): return "STATUS_SMARTCARD_WRONG_PIN";
                case unchecked((NtStatusCodes)0xC0000381): return "STATUS_SMARTCARD_CARD_BLOCKED";
                case unchecked((NtStatusCodes)0xC0000382): return "STATUS_SMARTCARD_CARD_NOT_AUTHENTICATED";
                case unchecked((NtStatusCodes)0xC0000383): return "STATUS_SMARTCARD_NO_CARD";
                case unchecked((NtStatusCodes)0xC0000384): return "STATUS_SMARTCARD_NO_KEY_CONTAINER";
                case unchecked((NtStatusCodes)0xC0000385): return "STATUS_SMARTCARD_NO_CERTIFICATE";
                case unchecked((NtStatusCodes)0xC0000386): return "STATUS_SMARTCARD_NO_KEYSET";
                case unchecked((NtStatusCodes)0xC0000387): return "STATUS_SMARTCARD_IO_ERROR";
                case unchecked((NtStatusCodes)0xC0000388): return "STATUS_DOWNGRADE_DETECTED";
                case unchecked((NtStatusCodes)0xC0000389): return "STATUS_SMARTCARD_CERT_REVOKED";
                case unchecked((NtStatusCodes)0xC000038A): return "STATUS_ISSUING_CA_UNTRUSTED";
                case unchecked((NtStatusCodes)0xC000038B): return "STATUS_REVOCATION_OFFLINE_C";
                case unchecked((NtStatusCodes)0xC000038C): return "STATUS_PKINIT_CLIENT_FAILURE";
                case unchecked((NtStatusCodes)0xC000038D): return "STATUS_SMARTCARD_CERT_EXPIRED";
                case unchecked((NtStatusCodes)0xC000038E): return "STATUS_DRIVER_FAILED_PRIOR_UNLOAD";
                case unchecked((NtStatusCodes)0xC000038F): return "STATUS_SMARTCARD_SILENT_CONTEXT";
                case unchecked((NtStatusCodes)0xC0000401): return "STATUS_PER_USER_TRUST_QUOTA_EXCEEDED";
                case unchecked((NtStatusCodes)0xC0000402): return "STATUS_ALL_USER_TRUST_QUOTA_EXCEEDED";
                case unchecked((NtStatusCodes)0xC0000403): return "STATUS_USER_DELETE_TRUST_QUOTA_EXCEEDED";
                case unchecked((NtStatusCodes)0xC0000404): return "STATUS_DS_NAME_NOT_UNIQUE";
                case unchecked((NtStatusCodes)0xC0000405): return "STATUS_DS_DUPLICATE_ID_FOUND";
                case unchecked((NtStatusCodes)0xC0000406): return "STATUS_DS_GROUP_CONVERSION_ERROR";
                case unchecked((NtStatusCodes)0xC0000407): return "STATUS_VOLSNAP_PREPARE_HIBERNATE";
                case unchecked((NtStatusCodes)0xC0000408): return "STATUS_USER2USER_REQUIRED";
                case unchecked((NtStatusCodes)0xC0000409): return "STATUS_STACK_BUFFER_OVERRUN";
                case unchecked((NtStatusCodes)0xC000040A): return "STATUS_NO_S4U_PROT_SUPPORT";
                case unchecked((NtStatusCodes)0xC000040B): return "STATUS_CROSSREALM_DELEGATION_FAILURE";
                case unchecked((NtStatusCodes)0xC000040C): return "STATUS_REVOCATION_OFFLINE_KDC";
                case unchecked((NtStatusCodes)0xC000040D): return "STATUS_ISSUING_CA_UNTRUSTED_KDC";
                case unchecked((NtStatusCodes)0xC000040E): return "STATUS_KDC_CERT_EXPIRED";
                case unchecked((NtStatusCodes)0xC000040F): return "STATUS_KDC_CERT_REVOKED";
                case unchecked((NtStatusCodes)0xC0000410): return "STATUS_PARAMETER_QUOTA_EXCEEDED";
                case unchecked((NtStatusCodes)0xC0000411): return "STATUS_HIBERNATION_FAILURE";
                case unchecked((NtStatusCodes)0xC0000412): return "STATUS_DELAY_LOAD_FAILED";
                case unchecked((NtStatusCodes)0xC0000413): return "STATUS_AUTHENTICATION_FIREWALL_FAILED";
                case unchecked((NtStatusCodes)0xC0000414): return "STATUS_VDM_DISALLOWED";
                case unchecked((NtStatusCodes)0xC0000415): return "STATUS_HUNG_DISPLAY_DRIVER_THREAD";
                case unchecked((NtStatusCodes)0xC0000416): return "STATUS_INSUFFICIENT_RESOURCE_FOR_SPECIFIED_SHARED_SECTION_SIZE";
                case unchecked((NtStatusCodes)0xC0000417): return "STATUS_INVALID_CRUNTIME_PARAMETER";
                case unchecked((NtStatusCodes)0xC0000418): return "STATUS_NTLM_BLOCKED";
                case unchecked((NtStatusCodes)0xC0000419): return "STATUS_DS_SRC_SID_EXISTS_IN_FOREST";
                case unchecked((NtStatusCodes)0xC000041A): return "STATUS_DS_DOMAIN_NAME_EXISTS_IN_FOREST";
                case unchecked((NtStatusCodes)0xC000041B): return "STATUS_DS_FLAT_NAME_EXISTS_IN_FOREST";
                case unchecked((NtStatusCodes)0xC000041C): return "STATUS_INVALID_USER_PRINCIPAL_NAME";
                case unchecked((NtStatusCodes)0xC000041D): return "STATUS_FATAL_USER_CALLBACK_EXCEPTION";
                case unchecked((NtStatusCodes)0xC0000420): return "STATUS_ASSERTION_FAILURE";
                case unchecked((NtStatusCodes)0xC0000421): return "STATUS_VERIFIER_STOP";
                case unchecked((NtStatusCodes)0xC0000423): return "STATUS_CALLBACK_POP_STACK";
                case unchecked((NtStatusCodes)0xC0000424): return "STATUS_INCOMPATIBLE_DRIVER_BLOCKED";
                case unchecked((NtStatusCodes)0xC0000425): return "STATUS_HIVE_UNLOADED";
                case unchecked((NtStatusCodes)0xC0000426): return "STATUS_COMPRESSION_DISABLED";
                case unchecked((NtStatusCodes)0xC0000427): return "STATUS_FILE_SYSTEM_LIMITATION";
                case unchecked((NtStatusCodes)0xC0000428): return "STATUS_INVALID_IMAGE_HASH";
                case unchecked((NtStatusCodes)0xC0000429): return "STATUS_NOT_CAPABLE";
                case unchecked((NtStatusCodes)0xC000042A): return "STATUS_REQUEST_OUT_OF_SEQUENCE";
                case unchecked((NtStatusCodes)0xC000042B): return "STATUS_IMPLEMENTATION_LIMIT";
                case unchecked((NtStatusCodes)0xC000042C): return "STATUS_ELEVATION_REQUIRED";
                case unchecked((NtStatusCodes)0xC000042D): return "STATUS_NO_SECURITY_CONTEXT";
                case unchecked((NtStatusCodes)0xC000042F): return "STATUS_PKU2U_CERT_FAILURE";
                case unchecked((NtStatusCodes)0xC0000432): return "STATUS_BEYOND_VDL";
                case unchecked((NtStatusCodes)0xC0000433): return "STATUS_ENCOUNTERED_WRITE_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC0000434): return "STATUS_PTE_CHANGED";
                case unchecked((NtStatusCodes)0xC0000435): return "STATUS_PURGE_FAILED";
                case unchecked((NtStatusCodes)0xC0000440): return "STATUS_CRED_REQUIRES_CONFIRMATION";
                case unchecked((NtStatusCodes)0xC0000441): return "STATUS_CS_ENCRYPTION_INVALID_SERVER_RESPONSE";
                case unchecked((NtStatusCodes)0xC0000442): return "STATUS_CS_ENCRYPTION_UNSUPPORTED_SERVER";
                case unchecked((NtStatusCodes)0xC0000443): return "STATUS_CS_ENCRYPTION_EXISTING_ENCRYPTED_FILE";
                case unchecked((NtStatusCodes)0xC0000444): return "STATUS_CS_ENCRYPTION_NEW_ENCRYPTED_FILE";
                case unchecked((NtStatusCodes)0xC0000445): return "STATUS_CS_ENCRYPTION_FILE_NOT_CSE";
                case unchecked((NtStatusCodes)0xC0000446): return "STATUS_INVALID_LABEL";
                case unchecked((NtStatusCodes)0xC0000450): return "STATUS_DRIVER_PROCESS_TERMINATED";
                case unchecked((NtStatusCodes)0xC0000451): return "STATUS_AMBIGUOUS_SYSTEM_DEVICE";
                case unchecked((NtStatusCodes)0xC0000452): return "STATUS_SYSTEM_DEVICE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000453): return "STATUS_RESTART_BOOT_APPLICATION";
                case unchecked((NtStatusCodes)0xC0000454): return "STATUS_INSUFFICIENT_NVRAM_RESOURCES";
                case unchecked((NtStatusCodes)0xC0000455): return "STATUS_INVALID_SESSION";
                case unchecked((NtStatusCodes)0xC0000456): return "STATUS_THREAD_ALREADY_IN_SESSION";
                case unchecked((NtStatusCodes)0xC0000457): return "STATUS_THREAD_NOT_IN_SESSION";
                case unchecked((NtStatusCodes)0xC0000458): return "STATUS_INVALID_WEIGHT";
                case unchecked((NtStatusCodes)0xC0000459): return "STATUS_REQUEST_PAUSED";
                case unchecked((NtStatusCodes)0xC0000460): return "STATUS_NO_RANGES_PROCESSED";
                case unchecked((NtStatusCodes)0xC0000461): return "STATUS_DISK_RESOURCES_EXHAUSTED";
                case unchecked((NtStatusCodes)0xC0000462): return "STATUS_NEEDS_REMEDIATION";
                case unchecked((NtStatusCodes)0xC0000463): return "STATUS_DEVICE_FEATURE_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0000464): return "STATUS_DEVICE_UNREACHABLE";
                case unchecked((NtStatusCodes)0xC0000465): return "STATUS_INVALID_TOKEN";
                case unchecked((NtStatusCodes)0xC0000466): return "STATUS_SERVER_UNAVAILABLE";
                case unchecked((NtStatusCodes)0xC0000467): return "STATUS_FILE_NOT_AVAILABLE";
                case unchecked((NtStatusCodes)0xC0000468): return "STATUS_DEVICE_INSUFFICIENT_RESOURCES";
                case unchecked((NtStatusCodes)0xC0000469): return "STATUS_PACKAGE_UPDATING";
                case unchecked((NtStatusCodes)0xC000046A): return "STATUS_NOT_READ_FROM_COPY";
                case unchecked((NtStatusCodes)0xC000046B): return "STATUS_FT_WRITE_FAILURE";
                case unchecked((NtStatusCodes)0xC000046C): return "STATUS_FT_DI_SCAN_REQUIRED";
                case unchecked((NtStatusCodes)0xC000046D): return "STATUS_OBJECT_NOT_EXTERNALLY_BACKED";
                case unchecked((NtStatusCodes)0xC000046E): return "STATUS_EXTERNAL_BACKING_PROVIDER_UNKNOWN";
                case unchecked((NtStatusCodes)0xC000046F): return "STATUS_COMPRESSION_NOT_BENEFICIAL";
                case unchecked((NtStatusCodes)0xC0000470): return "STATUS_DATA_CHECKSUM_ERROR";
                case unchecked((NtStatusCodes)0xC0000471): return "STATUS_INTERMIXED_KERNEL_EA_OPERATION";
                case unchecked((NtStatusCodes)0xC0000472): return "STATUS_TRIM_READ_ZERO_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0000473): return "STATUS_TOO_MANY_SEGMENT_DESCRIPTORS";
                case unchecked((NtStatusCodes)0xC0000474): return "STATUS_INVALID_OFFSET_ALIGNMENT";
                case unchecked((NtStatusCodes)0xC0000475): return "STATUS_INVALID_FIELD_IN_PARAMETER_LIST";
                case unchecked((NtStatusCodes)0xC0000476): return "STATUS_OPERATION_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC0000477): return "STATUS_INVALID_INITIATOR_TARGET_PATH";
                case unchecked((NtStatusCodes)0xC0000478): return "STATUS_SCRUB_DATA_DISABLED";
                case unchecked((NtStatusCodes)0xC0000479): return "STATUS_NOT_REDUNDANT_STORAGE";
                case unchecked((NtStatusCodes)0xC000047A): return "STATUS_RESIDENT_FILE_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000047B): return "STATUS_COMPRESSED_FILE_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000047C): return "STATUS_DIRECTORY_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000047D): return "STATUS_IO_OPERATION_TIMEOUT";
                case unchecked((NtStatusCodes)0xC000047E): return "STATUS_SYSTEM_NEEDS_REMEDIATION";
                case unchecked((NtStatusCodes)0xC000047F): return "STATUS_APPX_INTEGRITY_FAILURE_CLR_NGEN";
                case unchecked((NtStatusCodes)0xC0000480): return "STATUS_SHARE_UNAVAILABLE";
                case unchecked((NtStatusCodes)0xC0000481): return "STATUS_APISET_NOT_HOSTED";
                case unchecked((NtStatusCodes)0xC0000482): return "STATUS_APISET_NOT_PRESENT";
                case unchecked((NtStatusCodes)0xC0000483): return "STATUS_DEVICE_HARDWARE_ERROR";
                case unchecked((NtStatusCodes)0xC0000484): return "STATUS_FIRMWARE_SLOT_INVALID";
                case unchecked((NtStatusCodes)0xC0000485): return "STATUS_FIRMWARE_IMAGE_INVALID";
                case unchecked((NtStatusCodes)0xC0000486): return "STATUS_STORAGE_TOPOLOGY_ID_MISMATCH";
                case unchecked((NtStatusCodes)0xC0000487): return "STATUS_WIM_NOT_BOOTABLE";
                case unchecked((NtStatusCodes)0xC0000488): return "STATUS_BLOCKED_BY_PARENTAL_CONTROLS";
                case unchecked((NtStatusCodes)0xC0000489): return "STATUS_NEEDS_REGISTRATION";
                case unchecked((NtStatusCodes)0xC000048A): return "STATUS_QUOTA_ACTIVITY";
                case unchecked((NtStatusCodes)0xC000048B): return "STATUS_CALLBACK_INVOKE_INLINE";
                case unchecked((NtStatusCodes)0xC000048C): return "STATUS_BLOCK_TOO_MANY_REFERENCES";
                case unchecked((NtStatusCodes)0xC000048D): return "STATUS_MARKED_TO_DISALLOW_WRITES";
                case unchecked((NtStatusCodes)0xC000048E): return "STATUS_NETWORK_ACCESS_DENIED_EDP";
                case unchecked((NtStatusCodes)0xC000048F): return "STATUS_ENCLAVE_FAILURE";
                case unchecked((NtStatusCodes)0xC0000490): return "STATUS_PNP_NO_COMPAT_DRIVERS";
                case unchecked((NtStatusCodes)0xC0000491): return "STATUS_PNP_DRIVER_PACKAGE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000492): return "STATUS_PNP_DRIVER_CONFIGURATION_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0000493): return "STATUS_PNP_DRIVER_CONFIGURATION_INCOMPLETE";
                case unchecked((NtStatusCodes)0xC0000494): return "STATUS_PNP_FUNCTION_DRIVER_REQUIRED";
                case unchecked((NtStatusCodes)0xC0000495): return "STATUS_PNP_DEVICE_CONFIGURATION_PENDING";
                case unchecked((NtStatusCodes)0xC0000496): return "STATUS_DEVICE_HINT_NAME_BUFFER_TOO_SMALL";
                case unchecked((NtStatusCodes)0xC0000497): return "STATUS_PACKAGE_NOT_AVAILABLE";
                case unchecked((NtStatusCodes)0xC0000499): return "STATUS_DEVICE_IN_MAINTENANCE";
                case unchecked((NtStatusCodes)0xC000049A): return "STATUS_NOT_SUPPORTED_ON_DAX";
                case unchecked((NtStatusCodes)0xC000049B): return "STATUS_FREE_SPACE_TOO_FRAGMENTED";
                case unchecked((NtStatusCodes)0xC000049C): return "STATUS_DAX_MAPPING_EXISTS";
                case unchecked((NtStatusCodes)0xC000049D): return "STATUS_CHILD_PROCESS_BLOCKED";
                case unchecked((NtStatusCodes)0xC000049E): return "STATUS_STORAGE_LOST_DATA_PERSISTENCE";
                case unchecked((NtStatusCodes)0xC00004A0): return "STATUS_PARTITION_TERMINATING";
                case unchecked((NtStatusCodes)0xC00004A1): return "STATUS_EXTERNAL_SYSKEY_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC00004A2): return "STATUS_ENCLAVE_VIOLATION";
                case unchecked((NtStatusCodes)0xC00004A3): return "STATUS_FILE_PROTECTED_UNDER_DPL";
                case unchecked((NtStatusCodes)0xC00004A4): return "STATUS_VOLUME_NOT_CLUSTER_ALIGNED";
                case unchecked((NtStatusCodes)0xC00004A5): return "STATUS_NO_PHYSICALLY_ALIGNED_FREE_SPACE_FOUND";
                case unchecked((NtStatusCodes)0xC00004A6): return "STATUS_APPX_FILE_NOT_ENCRYPTED";
                case unchecked((NtStatusCodes)0xC00004A7): return "STATUS_RWRAW_ENCRYPTED_FILE_NOT_ENCRYPTED";
                case unchecked((NtStatusCodes)0xC00004A8): return "STATUS_RWRAW_ENCRYPTED_INVALID_EDATAINFO_FILEOFFSET";
                case unchecked((NtStatusCodes)0xC00004A9): return "STATUS_RWRAW_ENCRYPTED_INVALID_EDATAINFO_FILERANGE";
                case unchecked((NtStatusCodes)0xC00004AA): return "STATUS_RWRAW_ENCRYPTED_INVALID_EDATAINFO_PARAMETER";
                case unchecked((NtStatusCodes)0xC00004AB): return "STATUS_FT_READ_FAILURE";
                case unchecked((NtStatusCodes)0xC00004AC): return "STATUS_PATCH_CONFLICT";
                case unchecked((NtStatusCodes)0xC00004AD): return "STATUS_STORAGE_RESERVE_ID_INVALID";
                case unchecked((NtStatusCodes)0xC00004AE): return "STATUS_STORAGE_RESERVE_DOES_NOT_EXIST";
                case unchecked((NtStatusCodes)0xC00004AF): return "STATUS_STORAGE_RESERVE_ALREADY_EXISTS";
                case unchecked((NtStatusCodes)0xC00004B0): return "STATUS_STORAGE_RESERVE_NOT_EMPTY";
                case unchecked((NtStatusCodes)0xC00004B1): return "STATUS_NOT_A_DAX_VOLUME";
                case unchecked((NtStatusCodes)0xC00004B2): return "STATUS_NOT_DAX_MAPPABLE";
                case unchecked((NtStatusCodes)0xC00004B3): return "STATUS_CASE_DIFFERING_NAMES_IN_DIR";
                case unchecked((NtStatusCodes)0xC00004B4): return "STATUS_FILE_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC00004B5): return "STATUS_NOT_SUPPORTED_WITH_BTT";
                case unchecked((NtStatusCodes)0xC00004B6): return "STATUS_ENCRYPTION_DISABLED";
                case unchecked((NtStatusCodes)0xC00004B7): return "STATUS_ENCRYPTING_METADATA_DISALLOWED";
                case unchecked((NtStatusCodes)0xC00004B8): return "STATUS_CANT_CLEAR_ENCRYPTION_FLAG";
                case unchecked((NtStatusCodes)0xC00004B9): return "STATUS_UNSATISFIED_DEPENDENCIES";
                case unchecked((NtStatusCodes)0xC00004BA): return "STATUS_CASE_SENSITIVE_PATH";
                case unchecked((NtStatusCodes)0xC00004BB): return "STATUS_UNSUPPORTED_PAGING_MODE";
                case unchecked((NtStatusCodes)0xC00004BC): return "STATUS_UNTRUSTED_MOUNT_POINT";
                case unchecked((NtStatusCodes)0xC00004BD): return "STATUS_HAS_SYSTEM_CRITICAL_FILES";
                case unchecked((NtStatusCodes)0xC00004BE): return "STATUS_OBJECT_IS_IMMUTABLE";
                case unchecked((NtStatusCodes)0xC00004BF): return "STATUS_FT_READ_FROM_COPY_FAILURE";
                case unchecked((NtStatusCodes)0xC00004C0): return "STATUS_IMAGE_LOADED_AS_PATCH_IMAGE";
                case unchecked((NtStatusCodes)0xC00004C1): return "STATUS_STORAGE_STACK_ACCESS_DENIED";
                case unchecked((NtStatusCodes)0xC00004C2): return "STATUS_INSUFFICIENT_VIRTUAL_ADDR_RESOURCES";
                case unchecked((NtStatusCodes)0xC00004C3): return "STATUS_ENCRYPTED_FILE_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC00004C4): return "STATUS_SPARSE_FILE_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC00004C5): return "STATUS_PAGEFILE_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC00004C6): return "STATUS_VOLUME_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC00004C7): return "STATUS_NOT_SUPPORTED_WITH_BYPASSIO";
                case unchecked((NtStatusCodes)0xC00004C8): return "STATUS_NO_BYPASSIO_DRIVER_SUPPORT";
                case unchecked((NtStatusCodes)0xC00004C9): return "STATUS_NOT_SUPPORTED_WITH_ENCRYPTION";
                case unchecked((NtStatusCodes)0xC00004CA): return "STATUS_NOT_SUPPORTED_WITH_COMPRESSION";
                case unchecked((NtStatusCodes)0xC00004CB): return "STATUS_NOT_SUPPORTED_WITH_REPLICATION";
                case unchecked((NtStatusCodes)0xC00004CC): return "STATUS_NOT_SUPPORTED_WITH_DEDUPLICATION";
                case unchecked((NtStatusCodes)0xC00004CD): return "STATUS_NOT_SUPPORTED_WITH_AUDITING";
                case unchecked((NtStatusCodes)0xC00004CE): return "STATUS_NOT_SUPPORTED_WITH_MONITORING";
                case unchecked((NtStatusCodes)0xC00004CF): return "STATUS_NOT_SUPPORTED_WITH_SNAPSHOT";
                case unchecked((NtStatusCodes)0xC00004D0): return "STATUS_NOT_SUPPORTED_WITH_VIRTUALIZATION";
                case unchecked((NtStatusCodes)0xC00004D1): return "STATUS_INDEX_OUT_OF_BOUNDS";
                case unchecked((NtStatusCodes)0xC00004D2): return "STATUS_BYPASSIO_FLT_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC00004D3): return "STATUS_VOLUME_WRITE_ACCESS_DENIED";
                case unchecked((NtStatusCodes)0xC0000500): return "STATUS_INVALID_TASK_NAME";
                case unchecked((NtStatusCodes)0xC0000501): return "STATUS_INVALID_TASK_INDEX";
                case unchecked((NtStatusCodes)0xC0000502): return "STATUS_THREAD_ALREADY_IN_TASK";
                case unchecked((NtStatusCodes)0xC0000503): return "STATUS_CALLBACK_BYPASS";
                case unchecked((NtStatusCodes)0xC0000504): return "STATUS_UNDEFINED_SCOPE";
                case unchecked((NtStatusCodes)0xC0000505): return "STATUS_INVALID_CAP";
                case unchecked((NtStatusCodes)0xC0000506): return "STATUS_NOT_GUI_PROCESS";
                case unchecked((NtStatusCodes)0xC0000507): return "STATUS_DEVICE_HUNG";
                case unchecked((NtStatusCodes)0xC0000508): return "STATUS_CONTAINER_ASSIGNED";
                case unchecked((NtStatusCodes)0xC0000509): return "STATUS_JOB_NO_CONTAINER";
                case unchecked((NtStatusCodes)0xC000050A): return "STATUS_DEVICE_UNRESPONSIVE";
                case unchecked((NtStatusCodes)0xC000050B): return "STATUS_REPARSE_POINT_ENCOUNTERED";
                case unchecked((NtStatusCodes)0xC000050C): return "STATUS_ATTRIBUTE_NOT_PRESENT";
                case unchecked((NtStatusCodes)0xC000050D): return "STATUS_NOT_A_TIERED_VOLUME";
                case unchecked((NtStatusCodes)0xC000050E): return "STATUS_ALREADY_HAS_STREAM_ID";
                case unchecked((NtStatusCodes)0xC000050F): return "STATUS_JOB_NOT_EMPTY";
                case unchecked((NtStatusCodes)0xC0000510): return "STATUS_ALREADY_INITIALIZED";
                case unchecked((NtStatusCodes)0xC0000511): return "STATUS_ENCLAVE_NOT_TERMINATED";
                case unchecked((NtStatusCodes)0xC0000512): return "STATUS_ENCLAVE_IS_TERMINATING";
                case unchecked((NtStatusCodes)0xC0000513): return "STATUS_SMB1_NOT_AVAILABLE";
                case unchecked((NtStatusCodes)0xC0000514): return "STATUS_SMR_GARBAGE_COLLECTION_REQUIRED";
                case unchecked((NtStatusCodes)0xC0000515): return "STATUS_INTERRUPTED";
                case unchecked((NtStatusCodes)0xC0000516): return "STATUS_THREAD_NOT_RUNNING";
                case unchecked((NtStatusCodes)0xC0000517): return "STATUS_SESSION_KEY_TOO_SHORT";
                case unchecked((NtStatusCodes)0xC0000602): return "STATUS_FAIL_FAST_EXCEPTION";
                case unchecked((NtStatusCodes)0xC0000603): return "STATUS_IMAGE_CERT_REVOKED";
                case unchecked((NtStatusCodes)0xC0000604): return "STATUS_DYNAMIC_CODE_BLOCKED";
                case unchecked((NtStatusCodes)0xC0000605): return "STATUS_IMAGE_CERT_EXPIRED";
                case unchecked((NtStatusCodes)0xC0000606): return "STATUS_STRICT_CFG_VIOLATION";
                case unchecked((NtStatusCodes)0xC000060A): return "STATUS_SET_CONTEXT_DENIED";
                case unchecked((NtStatusCodes)0xC000060B): return "STATUS_CROSS_PARTITION_VIOLATION";
                case unchecked((NtStatusCodes)0xC0000700): return "STATUS_PORT_CLOSED";
                case unchecked((NtStatusCodes)0xC0000701): return "STATUS_MESSAGE_LOST";
                case unchecked((NtStatusCodes)0xC0000702): return "STATUS_INVALID_MESSAGE";
                case unchecked((NtStatusCodes)0xC0000703): return "STATUS_REQUEST_CANCELED";
                case unchecked((NtStatusCodes)0xC0000704): return "STATUS_RECURSIVE_DISPATCH";
                case unchecked((NtStatusCodes)0xC0000705): return "STATUS_LPC_RECEIVE_BUFFER_EXPECTED";
                case unchecked((NtStatusCodes)0xC0000706): return "STATUS_LPC_INVALID_CONNECTION_USAGE";
                case unchecked((NtStatusCodes)0xC0000707): return "STATUS_LPC_REQUESTS_NOT_ALLOWED";
                case unchecked((NtStatusCodes)0xC0000708): return "STATUS_RESOURCE_IN_USE";
                case unchecked((NtStatusCodes)0xC0000709): return "STATUS_HARDWARE_MEMORY_ERROR";
                case unchecked((NtStatusCodes)0xC000070A): return "STATUS_THREADPOOL_HANDLE_EXCEPTION";
                case unchecked((NtStatusCodes)0xC000070B): return "STATUS_THREADPOOL_SET_EVENT_ON_COMPLETION_FAILED";
                case unchecked((NtStatusCodes)0xC000070C): return "STATUS_THREADPOOL_RELEASE_SEMAPHORE_ON_COMPLETION_FAILED";
                case unchecked((NtStatusCodes)0xC000070D): return "STATUS_THREADPOOL_RELEASE_MUTEX_ON_COMPLETION_FAILED";
                case unchecked((NtStatusCodes)0xC000070E): return "STATUS_THREADPOOL_FREE_LIBRARY_ON_COMPLETION_FAILED";
                case unchecked((NtStatusCodes)0xC000070F): return "STATUS_THREADPOOL_RELEASED_DURING_OPERATION";
                case unchecked((NtStatusCodes)0xC0000710): return "STATUS_CALLBACK_RETURNED_WHILE_IMPERSONATING";
                case unchecked((NtStatusCodes)0xC0000711): return "STATUS_APC_RETURNED_WHILE_IMPERSONATING";
                case unchecked((NtStatusCodes)0xC0000712): return "STATUS_PROCESS_IS_PROTECTED";
                case unchecked((NtStatusCodes)0xC0000713): return "STATUS_MCA_EXCEPTION";
                case unchecked((NtStatusCodes)0xC0000714): return "STATUS_CERTIFICATE_MAPPING_NOT_UNIQUE";
                case unchecked((NtStatusCodes)0xC0000715): return "STATUS_SYMLINK_CLASS_DISABLED";
                case unchecked((NtStatusCodes)0xC0000716): return "STATUS_INVALID_IDN_NORMALIZATION";
                case unchecked((NtStatusCodes)0xC0000717): return "STATUS_NO_UNICODE_TRANSLATION";
                case unchecked((NtStatusCodes)0xC0000718): return "STATUS_ALREADY_REGISTERED";
                case unchecked((NtStatusCodes)0xC0000719): return "STATUS_CONTEXT_MISMATCH";
                case unchecked((NtStatusCodes)0xC000071A): return "STATUS_PORT_ALREADY_HAS_COMPLETION_LIST";
                case unchecked((NtStatusCodes)0xC000071B): return "STATUS_CALLBACK_RETURNED_THREAD_PRIORITY";
                case unchecked((NtStatusCodes)0xC000071C): return "STATUS_INVALID_THREAD";
                case unchecked((NtStatusCodes)0xC000071D): return "STATUS_CALLBACK_RETURNED_TRANSACTION";
                case unchecked((NtStatusCodes)0xC000071E): return "STATUS_CALLBACK_RETURNED_LDR_LOCK";
                case unchecked((NtStatusCodes)0xC000071F): return "STATUS_CALLBACK_RETURNED_LANG";
                case unchecked((NtStatusCodes)0xC0000720): return "STATUS_CALLBACK_RETURNED_PRI_BACK";
                case unchecked((NtStatusCodes)0xC0000721): return "STATUS_CALLBACK_RETURNED_THREAD_AFFINITY";
                case unchecked((NtStatusCodes)0xC0000722): return "STATUS_LPC_HANDLE_COUNT_EXCEEDED";
                case unchecked((NtStatusCodes)0xC0000723): return "STATUS_EXECUTABLE_MEMORY_WRITE";
                case unchecked((NtStatusCodes)0xC0000724): return "STATUS_KERNEL_EXECUTABLE_MEMORY_WRITE";
                case unchecked((NtStatusCodes)0xC0000725): return "STATUS_ATTACHED_EXECUTABLE_MEMORY_WRITE";
                case unchecked((NtStatusCodes)0xC0000726): return "STATUS_TRIGGERED_EXECUTABLE_MEMORY_WRITE";
                case unchecked((NtStatusCodes)0xC0000800): return "STATUS_DISK_REPAIR_DISABLED";
                case unchecked((NtStatusCodes)0xC0000801): return "STATUS_DS_DOMAIN_RENAME_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC0000802): return "STATUS_DISK_QUOTA_EXCEEDED";
                case unchecked((NtStatusCodes)0x80000803): return "STATUS_DATA_LOST_REPAIR";
                case unchecked((NtStatusCodes)0xC0000804): return "STATUS_CONTENT_BLOCKED";
                case unchecked((NtStatusCodes)0xC0000805): return "STATUS_BAD_CLUSTERS";
                case unchecked((NtStatusCodes)0xC0000806): return "STATUS_VOLUME_DIRTY";
                case unchecked((NtStatusCodes)0x40000807): return "STATUS_DISK_REPAIR_REDIRECTED";
                case unchecked((NtStatusCodes)0xC0000808): return "STATUS_DISK_REPAIR_UNSUCCESSFUL";
                case unchecked((NtStatusCodes)0xC0000809): return "STATUS_CORRUPT_LOG_OVERFULL";
                case unchecked((NtStatusCodes)0xC000080A): return "STATUS_CORRUPT_LOG_CORRUPTED";
                case unchecked((NtStatusCodes)0xC000080B): return "STATUS_CORRUPT_LOG_UNAVAILABLE";
                case unchecked((NtStatusCodes)0xC000080C): return "STATUS_CORRUPT_LOG_DELETED_FULL";
                case unchecked((NtStatusCodes)0xC000080D): return "STATUS_CORRUPT_LOG_CLEARED";
                case unchecked((NtStatusCodes)0xC000080E): return "STATUS_ORPHAN_NAME_EXHAUSTED";
                case unchecked((NtStatusCodes)0xC000080F): return "STATUS_PROACTIVE_SCAN_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC0000810): return "STATUS_ENCRYPTED_IO_NOT_POSSIBLE";
                case unchecked((NtStatusCodes)0xC0000811): return "STATUS_CORRUPT_LOG_UPLEVEL_RECORDS";
                case unchecked((NtStatusCodes)0xC0000901): return "STATUS_FILE_CHECKED_OUT";
                case unchecked((NtStatusCodes)0xC0000902): return "STATUS_CHECKOUT_REQUIRED";
                case unchecked((NtStatusCodes)0xC0000903): return "STATUS_BAD_FILE_TYPE";
                case unchecked((NtStatusCodes)0xC0000904): return "STATUS_FILE_TOO_LARGE";
                case unchecked((NtStatusCodes)0xC0000905): return "STATUS_FORMS_AUTH_REQUIRED";
                case unchecked((NtStatusCodes)0xC0000906): return "STATUS_VIRUS_INFECTED";
                case unchecked((NtStatusCodes)0xC0000907): return "STATUS_VIRUS_DELETED";
                case unchecked((NtStatusCodes)0xC0000908): return "STATUS_BAD_MCFG_TABLE";
                case unchecked((NtStatusCodes)0xC0000909): return "STATUS_CANNOT_BREAK_OPLOCK";
                case unchecked((NtStatusCodes)0xC000090A): return "STATUS_BAD_KEY";
                case unchecked((NtStatusCodes)0xC000090B): return "STATUS_BAD_DATA";
                case unchecked((NtStatusCodes)0xC000090C): return "STATUS_NO_KEY";
                case unchecked((NtStatusCodes)0xC0000910): return "STATUS_FILE_HANDLE_REVOKED";
                case unchecked((NtStatusCodes)0xC0000911): return "STATUS_SECTION_DIRECT_MAP_ONLY";
                case unchecked((NtStatusCodes)0xC0000C08): return "STATUS_VRF_VOLATILE_CFG_AND_IO_ENABLED";
                case unchecked((NtStatusCodes)0xC0000C09): return "STATUS_VRF_VOLATILE_NOT_STOPPABLE";
                case unchecked((NtStatusCodes)0xC0000C0A): return "STATUS_VRF_VOLATILE_SAFE_MODE";
                case unchecked((NtStatusCodes)0xC0000C0B): return "STATUS_VRF_VOLATILE_NOT_RUNNABLE_SYSTEM";
                case unchecked((NtStatusCodes)0xC0000C0C): return "STATUS_VRF_VOLATILE_NOT_SUPPORTED_RULECLASS";
                case unchecked((NtStatusCodes)0xC0000C0D): return "STATUS_VRF_VOLATILE_PROTECTED_DRIVER";
                case unchecked((NtStatusCodes)0xC0000C0E): return "STATUS_VRF_VOLATILE_NMI_REGISTERED";
                case unchecked((NtStatusCodes)0xC0000C0F): return "STATUS_VRF_VOLATILE_SETTINGS_CONFLICT";
                case unchecked((NtStatusCodes)0xC0000C76): return "STATUS_DIF_IOCALLBACK_NOT_REPLACED";
                case unchecked((NtStatusCodes)0xC0000C77): return "STATUS_DIF_LIVEDUMP_LIMIT_EXCEEDED";
                case unchecked((NtStatusCodes)0xC0000C78): return "STATUS_DIF_VOLATILE_SECTION_NOT_LOCKED";
                case unchecked((NtStatusCodes)0xC0000C79): return "STATUS_DIF_VOLATILE_DRIVER_HOTPATCHED";
                case unchecked((NtStatusCodes)0xC0000C7A): return "STATUS_DIF_VOLATILE_INVALID_INFO";
                case unchecked((NtStatusCodes)0xC0000C7B): return "STATUS_DIF_VOLATILE_DRIVER_IS_NOT_RUNNING";
                case unchecked((NtStatusCodes)0xC0000C7C): return "STATUS_DIF_VOLATILE_PLUGIN_IS_NOT_RUNNING";
                case unchecked((NtStatusCodes)0xC0000C7D): return "STATUS_DIF_VOLATILE_PLUGIN_CHANGE_NOT_ALLOWED";
                case unchecked((NtStatusCodes)0xC0000C7E): return "STATUS_DIF_VOLATILE_NOT_ALLOWED";
                case unchecked((NtStatusCodes)0xC0000C7F): return "STATUS_DIF_BINDING_API_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0009898): return "STATUS_WOW_ASSERTION";
                case unchecked((NtStatusCodes)0xC000A000): return "STATUS_INVALID_SIGNATURE";
                case unchecked((NtStatusCodes)0xC000A001): return "STATUS_HMAC_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000A002): return "STATUS_AUTH_TAG_MISMATCH";
                case unchecked((NtStatusCodes)0xC000A003): return "STATUS_INVALID_STATE_TRANSITION";
                case unchecked((NtStatusCodes)0xC000A004): return "STATUS_INVALID_KERNEL_INFO_VERSION";
                case unchecked((NtStatusCodes)0xC000A005): return "STATUS_INVALID_PEP_INFO_VERSION";
                case unchecked((NtStatusCodes)0xC000A006): return "STATUS_HANDLE_REVOKED";
                case unchecked((NtStatusCodes)0xC000A007): return "STATUS_EOF_ON_GHOSTED_RANGE";
                case unchecked((NtStatusCodes)0xC000A008): return "STATUS_CC_NEEDS_CALLBACK_SECTION_DRAIN";
                case unchecked((NtStatusCodes)0xC000A010): return "STATUS_IPSEC_QUEUE_OVERFLOW";
                case unchecked((NtStatusCodes)0xC000A011): return "STATUS_ND_QUEUE_OVERFLOW";
                case unchecked((NtStatusCodes)0xC000A012): return "STATUS_HOPLIMIT_EXCEEDED";
                case unchecked((NtStatusCodes)0xC000A013): return "STATUS_PROTOCOL_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000A014): return "STATUS_FASTPATH_REJECTED";
                case unchecked((NtStatusCodes)0xC000A080): return "STATUS_LOST_WRITEBEHIND_DATA_NETWORK_DISCONNECTED";
                case unchecked((NtStatusCodes)0xC000A081): return "STATUS_LOST_WRITEBEHIND_DATA_NETWORK_SERVER_ERROR";
                case unchecked((NtStatusCodes)0xC000A082): return "STATUS_LOST_WRITEBEHIND_DATA_LOCAL_DISK_ERROR";
                case unchecked((NtStatusCodes)0xC000A083): return "STATUS_XML_PARSE_ERROR";
                case unchecked((NtStatusCodes)0xC000A084): return "STATUS_XMLDSIG_ERROR";
                case unchecked((NtStatusCodes)0xC000A085): return "STATUS_WRONG_COMPARTMENT";
                case unchecked((NtStatusCodes)0xC000A086): return "STATUS_AUTHIP_FAILURE";
                case unchecked((NtStatusCodes)0xC000A087): return "STATUS_DS_OID_MAPPED_GROUP_CANT_HAVE_MEMBERS";
                case unchecked((NtStatusCodes)0xC000A088): return "STATUS_DS_OID_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC000A089): return "STATUS_INCORRECT_ACCOUNT_TYPE";
                case unchecked((NtStatusCodes)0xC000A100): return "STATUS_HASH_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000A101): return "STATUS_HASH_NOT_PRESENT";
                case unchecked((NtStatusCodes)0xC000A121): return "STATUS_SECONDARY_IC_PROVIDER_NOT_REGISTERED";
                case unchecked((NtStatusCodes)0xC000A122): return "STATUS_GPIO_CLIENT_INFORMATION_INVALID";
                case unchecked((NtStatusCodes)0xC000A123): return "STATUS_GPIO_VERSION_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000A124): return "STATUS_GPIO_INVALID_REGISTRATION_PACKET";
                case unchecked((NtStatusCodes)0xC000A125): return "STATUS_GPIO_OPERATION_DENIED";
                case unchecked((NtStatusCodes)0xC000A126): return "STATUS_GPIO_INCOMPATIBLE_CONNECT_MODE";
                case unchecked((NtStatusCodes)0x8000A127): return "STATUS_GPIO_INTERRUPT_ALREADY_UNMASKED";
                case unchecked((NtStatusCodes)0xC000A141): return "STATUS_CANNOT_SWITCH_RUNLEVEL";
                case unchecked((NtStatusCodes)0xC000A142): return "STATUS_INVALID_RUNLEVEL_SETTING";
                case unchecked((NtStatusCodes)0xC000A143): return "STATUS_RUNLEVEL_SWITCH_TIMEOUT";
                case unchecked((NtStatusCodes)0x4000A144): return "STATUS_SERVICES_FAILED_AUTOSTART";
                case unchecked((NtStatusCodes)0xC000A145): return "STATUS_RUNLEVEL_SWITCH_AGENT_TIMEOUT";
                case unchecked((NtStatusCodes)0xC000A146): return "STATUS_RUNLEVEL_SWITCH_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC000A200): return "STATUS_NOT_APPCONTAINER";
                case unchecked((NtStatusCodes)0xC000A201): return "STATUS_NOT_SUPPORTED_IN_APPCONTAINER";
                case unchecked((NtStatusCodes)0xC000A202): return "STATUS_INVALID_PACKAGE_SID_LENGTH";
                case unchecked((NtStatusCodes)0xC000A203): return "STATUS_LPAC_ACCESS_DENIED";
                case unchecked((NtStatusCodes)0xC000A204): return "STATUS_ADMINLESS_ACCESS_DENIED";
                case unchecked((NtStatusCodes)0xC000A281): return "STATUS_APP_DATA_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC000A282): return "STATUS_APP_DATA_EXPIRED";
                case unchecked((NtStatusCodes)0xC000A283): return "STATUS_APP_DATA_CORRUPT";
                case unchecked((NtStatusCodes)0xC000A284): return "STATUS_APP_DATA_LIMIT_EXCEEDED";
                case unchecked((NtStatusCodes)0xC000A285): return "STATUS_APP_DATA_REBOOT_REQUIRED";
                case unchecked((NtStatusCodes)0xC000A2A1): return "STATUS_OFFLOAD_READ_FLT_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000A2A2): return "STATUS_OFFLOAD_WRITE_FLT_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000A2A3): return "STATUS_OFFLOAD_READ_FILE_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000A2A4): return "STATUS_OFFLOAD_WRITE_FILE_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000A2A5): return "STATUS_WOF_WIM_HEADER_CORRUPT";
                case unchecked((NtStatusCodes)0xC000A2A6): return "STATUS_WOF_WIM_RESOURCE_TABLE_CORRUPT";
                case unchecked((NtStatusCodes)0xC000A2A7): return "STATUS_WOF_FILE_RESOURCE_TABLE_CORRUPT";
                case unchecked((NtStatusCodes)0xC000C001): return "STATUS_CIMFS_IMAGE_CORRUPT";
                case unchecked((NtStatusCodes)0xC000C002): return "STATUS_CIMFS_IMAGE_VERSION_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000CE01): return "STATUS_FILE_SYSTEM_VIRTUALIZATION_UNAVAILABLE";
                case unchecked((NtStatusCodes)0xC000CE02): return "STATUS_FILE_SYSTEM_VIRTUALIZATION_METADATA_CORRUPT";
                case unchecked((NtStatusCodes)0xC000CE03): return "STATUS_FILE_SYSTEM_VIRTUALIZATION_BUSY";
                case unchecked((NtStatusCodes)0xC000CE04): return "STATUS_FILE_SYSTEM_VIRTUALIZATION_PROVIDER_UNKNOWN";
                case unchecked((NtStatusCodes)0xC000CE05): return "STATUS_FILE_SYSTEM_VIRTUALIZATION_INVALID_OPERATION";
                case unchecked((NtStatusCodes)0xC000CF00): return "STATUS_CLOUD_FILE_SYNC_ROOT_METADATA_CORRUPT";
                case unchecked((NtStatusCodes)0xC000CF01): return "STATUS_CLOUD_FILE_PROVIDER_NOT_RUNNING";
                case unchecked((NtStatusCodes)0xC000CF02): return "STATUS_CLOUD_FILE_METADATA_CORRUPT";
                case unchecked((NtStatusCodes)0xC000CF03): return "STATUS_CLOUD_FILE_METADATA_TOO_LARGE";
                case unchecked((NtStatusCodes)0x8000CF04): return "STATUS_CLOUD_FILE_PROPERTY_BLOB_TOO_LARGE";
                case unchecked((NtStatusCodes)0x8000CF05): return "STATUS_CLOUD_FILE_TOO_MANY_PROPERTY_BLOBS";
                case unchecked((NtStatusCodes)0xC000CF06): return "STATUS_CLOUD_FILE_PROPERTY_VERSION_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000CF07): return "STATUS_NOT_A_CLOUD_FILE";
                case unchecked((NtStatusCodes)0xC000CF08): return "STATUS_CLOUD_FILE_NOT_IN_SYNC";
                case unchecked((NtStatusCodes)0xC000CF09): return "STATUS_CLOUD_FILE_ALREADY_CONNECTED";
                case unchecked((NtStatusCodes)0xC000CF0A): return "STATUS_CLOUD_FILE_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000CF0B): return "STATUS_CLOUD_FILE_INVALID_REQUEST";
                case unchecked((NtStatusCodes)0xC000CF0C): return "STATUS_CLOUD_FILE_READ_ONLY_VOLUME";
                case unchecked((NtStatusCodes)0xC000CF0D): return "STATUS_CLOUD_FILE_CONNECTED_PROVIDER_ONLY";
                case unchecked((NtStatusCodes)0xC000CF0E): return "STATUS_CLOUD_FILE_VALIDATION_FAILED";
                case unchecked((NtStatusCodes)0xC000CF0F): return "STATUS_CLOUD_FILE_AUTHENTICATION_FAILED";
                case unchecked((NtStatusCodes)0xC000CF10): return "STATUS_CLOUD_FILE_INSUFFICIENT_RESOURCES";
                case unchecked((NtStatusCodes)0xC000CF11): return "STATUS_CLOUD_FILE_NETWORK_UNAVAILABLE";
                case unchecked((NtStatusCodes)0xC000CF12): return "STATUS_CLOUD_FILE_UNSUCCESSFUL";
                case unchecked((NtStatusCodes)0xC000CF13): return "STATUS_CLOUD_FILE_NOT_UNDER_SYNC_ROOT";
                case unchecked((NtStatusCodes)0xC000CF14): return "STATUS_CLOUD_FILE_IN_USE";
                case unchecked((NtStatusCodes)0xC000CF15): return "STATUS_CLOUD_FILE_PINNED";
                case unchecked((NtStatusCodes)0xC000CF16): return "STATUS_CLOUD_FILE_REQUEST_ABORTED";
                case unchecked((NtStatusCodes)0xC000CF17): return "STATUS_CLOUD_FILE_PROPERTY_CORRUPT";
                case unchecked((NtStatusCodes)0xC000CF18): return "STATUS_CLOUD_FILE_ACCESS_DENIED";
                case unchecked((NtStatusCodes)0xC000CF19): return "STATUS_CLOUD_FILE_INCOMPATIBLE_HARDLINKS";
                case unchecked((NtStatusCodes)0xC000CF1A): return "STATUS_CLOUD_FILE_PROPERTY_LOCK_CONFLICT";
                case unchecked((NtStatusCodes)0xC000CF1B): return "STATUS_CLOUD_FILE_REQUEST_CANCELED";
                case unchecked((NtStatusCodes)0xC000CF1D): return "STATUS_CLOUD_FILE_PROVIDER_TERMINATED";
                case unchecked((NtStatusCodes)0xC000CF1E): return "STATUS_NOT_A_CLOUD_SYNC_ROOT";
                case unchecked((NtStatusCodes)0xC000CF1F): return "STATUS_CLOUD_FILE_REQUEST_TIMEOUT";
                case unchecked((NtStatusCodes)0xC000CF20): return "STATUS_CLOUD_FILE_DEHYDRATION_DISALLOWED";
                case unchecked((NtStatusCodes)0xC000F500): return "STATUS_FILE_SNAP_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC000F501): return "STATUS_FILE_SNAP_USER_SECTION_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000F502): return "STATUS_FILE_SNAP_MODIFY_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC000F503): return "STATUS_FILE_SNAP_IO_NOT_COORDINATED";
                case unchecked((NtStatusCodes)0xC000F504): return "STATUS_FILE_SNAP_UNEXPECTED_ERROR";
                case unchecked((NtStatusCodes)0xC000F505): return "STATUS_FILE_SNAP_INVALID_PARAMETER";
                case unchecked((NtStatusCodes)0xC0140001): return "STATUS_ACPI_INVALID_OPCODE";
                case unchecked((NtStatusCodes)0xC0140002): return "STATUS_ACPI_STACK_OVERFLOW";
                case unchecked((NtStatusCodes)0xC0140003): return "STATUS_ACPI_ASSERT_FAILED";
                case unchecked((NtStatusCodes)0xC0140004): return "STATUS_ACPI_INVALID_INDEX";
                case unchecked((NtStatusCodes)0xC0140005): return "STATUS_ACPI_INVALID_ARGUMENT";
                case unchecked((NtStatusCodes)0xC0140006): return "STATUS_ACPI_FATAL";
                case unchecked((NtStatusCodes)0xC0140007): return "STATUS_ACPI_INVALID_SUPERNAME";
                case unchecked((NtStatusCodes)0xC0140008): return "STATUS_ACPI_INVALID_ARGTYPE";
                case unchecked((NtStatusCodes)0xC0140009): return "STATUS_ACPI_INVALID_OBJTYPE";
                case unchecked((NtStatusCodes)0xC014000A): return "STATUS_ACPI_INVALID_TARGETTYPE";
                case unchecked((NtStatusCodes)0xC014000B): return "STATUS_ACPI_INCORRECT_ARGUMENT_COUNT";
                case unchecked((NtStatusCodes)0xC014000C): return "STATUS_ACPI_ADDRESS_NOT_MAPPED";
                case unchecked((NtStatusCodes)0xC014000D): return "STATUS_ACPI_INVALID_EVENTTYPE";
                case unchecked((NtStatusCodes)0xC014000E): return "STATUS_ACPI_HANDLER_COLLISION";
                case unchecked((NtStatusCodes)0xC014000F): return "STATUS_ACPI_INVALID_DATA";
                case unchecked((NtStatusCodes)0xC0140010): return "STATUS_ACPI_INVALID_REGION";
                case unchecked((NtStatusCodes)0xC0140011): return "STATUS_ACPI_INVALID_ACCESS_SIZE";
                case unchecked((NtStatusCodes)0xC0140012): return "STATUS_ACPI_ACQUIRE_GLOBAL_LOCK";
                case unchecked((NtStatusCodes)0xC0140013): return "STATUS_ACPI_ALREADY_INITIALIZED";
                case unchecked((NtStatusCodes)0xC0140014): return "STATUS_ACPI_NOT_INITIALIZED";
                case unchecked((NtStatusCodes)0xC0140015): return "STATUS_ACPI_INVALID_MUTEX_LEVEL";
                case unchecked((NtStatusCodes)0xC0140016): return "STATUS_ACPI_MUTEX_NOT_OWNED";
                case unchecked((NtStatusCodes)0xC0140017): return "STATUS_ACPI_MUTEX_NOT_OWNER";
                case unchecked((NtStatusCodes)0xC0140018): return "STATUS_ACPI_RS_ACCESS";
                case unchecked((NtStatusCodes)0xC0140019): return "STATUS_ACPI_INVALID_TABLE";
                case unchecked((NtStatusCodes)0xC0140020): return "STATUS_ACPI_REG_HANDLER_FAILED";
                case unchecked((NtStatusCodes)0xC0140021): return "STATUS_ACPI_POWER_REQUEST_FAILED";
                case unchecked((NtStatusCodes)0xC00A0001): return "STATUS_CTX_WINSTATION_NAME_INVALID";
                case unchecked((NtStatusCodes)0xC00A0002): return "STATUS_CTX_INVALID_PD";
                case unchecked((NtStatusCodes)0xC00A0003): return "STATUS_CTX_PD_NOT_FOUND";
                case unchecked((NtStatusCodes)0x400A0004): return "STATUS_CTX_CDM_CONNECT";
                case unchecked((NtStatusCodes)0x400A0005): return "STATUS_CTX_CDM_DISCONNECT";
                case unchecked((NtStatusCodes)0xC00A0006): return "STATUS_CTX_CLOSE_PENDING";
                case unchecked((NtStatusCodes)0xC00A0007): return "STATUS_CTX_NO_OUTBUF";
                case unchecked((NtStatusCodes)0xC00A0008): return "STATUS_CTX_MODEM_INF_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC00A0009): return "STATUS_CTX_INVALID_MODEMNAME";
                case unchecked((NtStatusCodes)0xC00A000A): return "STATUS_CTX_RESPONSE_ERROR";
                case unchecked((NtStatusCodes)0xC00A000B): return "STATUS_CTX_MODEM_RESPONSE_TIMEOUT";
                case unchecked((NtStatusCodes)0xC00A000C): return "STATUS_CTX_MODEM_RESPONSE_NO_CARRIER";
                case unchecked((NtStatusCodes)0xC00A000D): return "STATUS_CTX_MODEM_RESPONSE_NO_DIALTONE";
                case unchecked((NtStatusCodes)0xC00A000E): return "STATUS_CTX_MODEM_RESPONSE_BUSY";
                case unchecked((NtStatusCodes)0xC00A000F): return "STATUS_CTX_MODEM_RESPONSE_VOICE";
                case unchecked((NtStatusCodes)0xC00A0010): return "STATUS_CTX_TD_ERROR";
                case unchecked((NtStatusCodes)0xC00A0012): return "STATUS_CTX_LICENSE_CLIENT_INVALID";
                case unchecked((NtStatusCodes)0xC00A0013): return "STATUS_CTX_LICENSE_NOT_AVAILABLE";
                case unchecked((NtStatusCodes)0xC00A0014): return "STATUS_CTX_LICENSE_EXPIRED";
                case unchecked((NtStatusCodes)0xC00A0015): return "STATUS_CTX_WINSTATION_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC00A0016): return "STATUS_CTX_WINSTATION_NAME_COLLISION";
                case unchecked((NtStatusCodes)0xC00A0017): return "STATUS_CTX_WINSTATION_BUSY";
                case unchecked((NtStatusCodes)0xC00A0018): return "STATUS_CTX_BAD_VIDEO_MODE";
                case unchecked((NtStatusCodes)0xC00A0022): return "STATUS_CTX_GRAPHICS_INVALID";
                case unchecked((NtStatusCodes)0xC00A0024): return "STATUS_CTX_NOT_CONSOLE";
                case unchecked((NtStatusCodes)0xC00A0026): return "STATUS_CTX_CLIENT_QUERY_TIMEOUT";
                case unchecked((NtStatusCodes)0xC00A0027): return "STATUS_CTX_CONSOLE_DISCONNECT";
                case unchecked((NtStatusCodes)0xC00A0028): return "STATUS_CTX_CONSOLE_CONNECT";
                case unchecked((NtStatusCodes)0xC00A002A): return "STATUS_CTX_SHADOW_DENIED";
                case unchecked((NtStatusCodes)0xC00A002B): return "STATUS_CTX_WINSTATION_ACCESS_DENIED";
                case unchecked((NtStatusCodes)0xC00A002E): return "STATUS_CTX_INVALID_WD";
                case unchecked((NtStatusCodes)0xC00A002F): return "STATUS_CTX_WD_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC00A0030): return "STATUS_CTX_SHADOW_INVALID";
                case unchecked((NtStatusCodes)0xC00A0031): return "STATUS_CTX_SHADOW_DISABLED";
                case unchecked((NtStatusCodes)0xC00A0032): return "STATUS_RDP_PROTOCOL_ERROR";
                case unchecked((NtStatusCodes)0xC00A0033): return "STATUS_CTX_CLIENT_LICENSE_NOT_SET";
                case unchecked((NtStatusCodes)0xC00A0034): return "STATUS_CTX_CLIENT_LICENSE_IN_USE";
                case unchecked((NtStatusCodes)0xC00A0035): return "STATUS_CTX_SHADOW_ENDED_BY_MODE_CHANGE";
                case unchecked((NtStatusCodes)0xC00A0036): return "STATUS_CTX_SHADOW_NOT_RUNNING";
                case unchecked((NtStatusCodes)0xC00A0037): return "STATUS_CTX_LOGON_DISABLED";
                case unchecked((NtStatusCodes)0xC00A0038): return "STATUS_CTX_SECURITY_LAYER_ERROR";
                case unchecked((NtStatusCodes)0xC00A0039): return "STATUS_TS_INCOMPATIBLE_SESSIONS";
                case unchecked((NtStatusCodes)0xC00A003A): return "STATUS_TS_VIDEO_SUBSYSTEM_ERROR";
                case unchecked((NtStatusCodes)0xC0040035): return "STATUS_PNP_BAD_MPS_TABLE";
                case unchecked((NtStatusCodes)0xC0040036): return "STATUS_PNP_TRANSLATION_FAILED";
                case unchecked((NtStatusCodes)0xC0040037): return "STATUS_PNP_IRQ_TRANSLATION_FAILED";
                case unchecked((NtStatusCodes)0xC0040038): return "STATUS_PNP_INVALID_ID";
                case unchecked((NtStatusCodes)0xC0040039): return "STATUS_IO_REISSUE_AS_CACHED";
                case unchecked((NtStatusCodes)0xC00B0001): return "STATUS_MUI_FILE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC00B0002): return "STATUS_MUI_INVALID_FILE";
                case unchecked((NtStatusCodes)0xC00B0003): return "STATUS_MUI_INVALID_RC_CONFIG";
                case unchecked((NtStatusCodes)0xC00B0004): return "STATUS_MUI_INVALID_LOCALE_NAME";
                case unchecked((NtStatusCodes)0xC00B0005): return "STATUS_MUI_INVALID_ULTIMATEFALLBACK_NAME";
                case unchecked((NtStatusCodes)0xC00B0006): return "STATUS_MUI_FILE_NOT_LOADED";
                case unchecked((NtStatusCodes)0xC00B0007): return "STATUS_RESOURCE_ENUM_USER_STOP";
                case unchecked((NtStatusCodes)0xC01C0001): return "STATUS_FLT_NO_HANDLER_DEFINED";
                case unchecked((NtStatusCodes)0xC01C0002): return "STATUS_FLT_CONTEXT_ALREADY_DEFINED";
                case unchecked((NtStatusCodes)0xC01C0003): return "STATUS_FLT_INVALID_ASYNCHRONOUS_REQUEST";
                case unchecked((NtStatusCodes)0xC01C0004): return "STATUS_FLT_DISALLOW_FAST_IO";
                case unchecked((NtStatusCodes)0xC01C0005): return "STATUS_FLT_INVALID_NAME_REQUEST";
                case unchecked((NtStatusCodes)0xC01C0006): return "STATUS_FLT_NOT_SAFE_TO_POST_OPERATION";
                case unchecked((NtStatusCodes)0xC01C0007): return "STATUS_FLT_NOT_INITIALIZED";
                case unchecked((NtStatusCodes)0xC01C0008): return "STATUS_FLT_FILTER_NOT_READY";
                case unchecked((NtStatusCodes)0xC01C0009): return "STATUS_FLT_POST_OPERATION_CLEANUP";
                case unchecked((NtStatusCodes)0xC01C000A): return "STATUS_FLT_INTERNAL_ERROR";
                case unchecked((NtStatusCodes)0xC01C000B): return "STATUS_FLT_DELETING_OBJECT";
                case unchecked((NtStatusCodes)0xC01C000C): return "STATUS_FLT_MUST_BE_NONPAGED_POOL";
                case unchecked((NtStatusCodes)0xC01C000D): return "STATUS_FLT_DUPLICATE_ENTRY";
                case unchecked((NtStatusCodes)0xC01C000E): return "STATUS_FLT_CBDQ_DISABLED";
                case unchecked((NtStatusCodes)0xC01C000F): return "STATUS_FLT_DO_NOT_ATTACH";
                case unchecked((NtStatusCodes)0xC01C0010): return "STATUS_FLT_DO_NOT_DETACH";
                case unchecked((NtStatusCodes)0xC01C0011): return "STATUS_FLT_INSTANCE_ALTITUDE_COLLISION";
                case unchecked((NtStatusCodes)0xC01C0012): return "STATUS_FLT_INSTANCE_NAME_COLLISION";
                case unchecked((NtStatusCodes)0xC01C0013): return "STATUS_FLT_FILTER_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC01C0014): return "STATUS_FLT_VOLUME_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC01C0015): return "STATUS_FLT_INSTANCE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC01C0016): return "STATUS_FLT_CONTEXT_ALLOCATION_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC01C0017): return "STATUS_FLT_INVALID_CONTEXT_REGISTRATION";
                case unchecked((NtStatusCodes)0xC01C0018): return "STATUS_FLT_NAME_CACHE_MISS";
                case unchecked((NtStatusCodes)0xC01C0019): return "STATUS_FLT_NO_DEVICE_OBJECT";
                case unchecked((NtStatusCodes)0xC01C001A): return "STATUS_FLT_VOLUME_ALREADY_MOUNTED";
                case unchecked((NtStatusCodes)0xC01C001B): return "STATUS_FLT_ALREADY_ENLISTED";
                case unchecked((NtStatusCodes)0xC01C001C): return "STATUS_FLT_CONTEXT_ALREADY_LINKED";
                case unchecked((NtStatusCodes)0xC01C0020): return "STATUS_FLT_NO_WAITER_FOR_REPLY";
                case unchecked((NtStatusCodes)0xC01C0023): return "STATUS_FLT_REGISTRATION_BUSY";
                case unchecked((NtStatusCodes)0xC01C0024): return "STATUS_FLT_WCOS_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0150001): return "STATUS_SXS_SECTION_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0150002): return "STATUS_SXS_CANT_GEN_ACTCTX";
                case unchecked((NtStatusCodes)0xC0150003): return "STATUS_SXS_INVALID_ACTCTXDATA_FORMAT";
                case unchecked((NtStatusCodes)0xC0150004): return "STATUS_SXS_ASSEMBLY_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0150005): return "STATUS_SXS_MANIFEST_FORMAT_ERROR";
                case unchecked((NtStatusCodes)0xC0150006): return "STATUS_SXS_MANIFEST_PARSE_ERROR";
                case unchecked((NtStatusCodes)0xC0150007): return "STATUS_SXS_ACTIVATION_CONTEXT_DISABLED";
                case unchecked((NtStatusCodes)0xC0150008): return "STATUS_SXS_KEY_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0150009): return "STATUS_SXS_VERSION_CONFLICT";
                case unchecked((NtStatusCodes)0xC015000A): return "STATUS_SXS_WRONG_SECTION_TYPE";
                case unchecked((NtStatusCodes)0xC015000B): return "STATUS_SXS_THREAD_QUERIES_DISABLED";
                case unchecked((NtStatusCodes)0xC015000C): return "STATUS_SXS_ASSEMBLY_MISSING";
                case unchecked((NtStatusCodes)0x4015000D): return "STATUS_SXS_RELEASE_ACTIVATION_CONTEXT";
                case unchecked((NtStatusCodes)0xC015000E): return "STATUS_SXS_PROCESS_DEFAULT_ALREADY_SET";
                case unchecked((NtStatusCodes)0xC015000F): return "STATUS_SXS_EARLY_DEACTIVATION";
                case unchecked((NtStatusCodes)0xC0150010): return "STATUS_SXS_INVALID_DEACTIVATION";
                case unchecked((NtStatusCodes)0xC0150011): return "STATUS_SXS_MULTIPLE_DEACTIVATION";
                case unchecked((NtStatusCodes)0xC0150012): return "STATUS_SXS_SYSTEM_DEFAULT_ACTIVATION_CONTEXT_EMPTY";
                case unchecked((NtStatusCodes)0xC0150013): return "STATUS_SXS_PROCESS_TERMINATION_REQUESTED";
                case unchecked((NtStatusCodes)0xC0150014): return "STATUS_SXS_CORRUPT_ACTIVATION_STACK";
                case unchecked((NtStatusCodes)0xC0150015): return "STATUS_SXS_CORRUPTION";
                case unchecked((NtStatusCodes)0xC0150016): return "STATUS_SXS_INVALID_IDENTITY_ATTRIBUTE_VALUE";
                case unchecked((NtStatusCodes)0xC0150017): return "STATUS_SXS_INVALID_IDENTITY_ATTRIBUTE_NAME";
                case unchecked((NtStatusCodes)0xC0150018): return "STATUS_SXS_IDENTITY_DUPLICATE_ATTRIBUTE";
                case unchecked((NtStatusCodes)0xC0150019): return "STATUS_SXS_IDENTITY_PARSE_ERROR";
                case unchecked((NtStatusCodes)0xC015001A): return "STATUS_SXS_COMPONENT_STORE_CORRUPT";
                case unchecked((NtStatusCodes)0xC015001B): return "STATUS_SXS_FILE_HASH_MISMATCH";
                case unchecked((NtStatusCodes)0xC015001C): return "STATUS_SXS_MANIFEST_IDENTITY_SAME_BUT_CONTENTS_DIFFERENT";
                case unchecked((NtStatusCodes)0xC015001D): return "STATUS_SXS_IDENTITIES_DIFFERENT";
                case unchecked((NtStatusCodes)0xC015001E): return "STATUS_SXS_ASSEMBLY_IS_NOT_A_DEPLOYMENT";
                case unchecked((NtStatusCodes)0xC015001F): return "STATUS_SXS_FILE_NOT_PART_OF_ASSEMBLY";
                case unchecked((NtStatusCodes)0xC0150020): return "STATUS_ADVANCED_INSTALLER_FAILED";
                case unchecked((NtStatusCodes)0xC0150021): return "STATUS_XML_ENCODING_MISMATCH";
                case unchecked((NtStatusCodes)0xC0150022): return "STATUS_SXS_MANIFEST_TOO_BIG";
                case unchecked((NtStatusCodes)0xC0150023): return "STATUS_SXS_SETTING_NOT_REGISTERED";
                case unchecked((NtStatusCodes)0xC0150024): return "STATUS_SXS_TRANSACTION_CLOSURE_INCOMPLETE";
                case unchecked((NtStatusCodes)0xC0150025): return "STATUS_SMI_PRIMITIVE_INSTALLER_FAILED";
                case unchecked((NtStatusCodes)0xC0150026): return "STATUS_GENERIC_COMMAND_FAILED";
                case unchecked((NtStatusCodes)0xC0150027): return "STATUS_SXS_FILE_HASH_MISSING";
                case unchecked((NtStatusCodes)0xC0130001): return "STATUS_CLUSTER_INVALID_NODE";
                case unchecked((NtStatusCodes)0xC0130002): return "STATUS_CLUSTER_NODE_EXISTS";
                case unchecked((NtStatusCodes)0xC0130003): return "STATUS_CLUSTER_JOIN_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC0130004): return "STATUS_CLUSTER_NODE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0130005): return "STATUS_CLUSTER_LOCAL_NODE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0130006): return "STATUS_CLUSTER_NETWORK_EXISTS";
                case unchecked((NtStatusCodes)0xC0130007): return "STATUS_CLUSTER_NETWORK_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0130008): return "STATUS_CLUSTER_NETINTERFACE_EXISTS";
                case unchecked((NtStatusCodes)0xC0130009): return "STATUS_CLUSTER_NETINTERFACE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC013000A): return "STATUS_CLUSTER_INVALID_REQUEST";
                case unchecked((NtStatusCodes)0xC013000B): return "STATUS_CLUSTER_INVALID_NETWORK_PROVIDER";
                case unchecked((NtStatusCodes)0xC013000C): return "STATUS_CLUSTER_NODE_DOWN";
                case unchecked((NtStatusCodes)0xC013000D): return "STATUS_CLUSTER_NODE_UNREACHABLE";
                case unchecked((NtStatusCodes)0xC013000E): return "STATUS_CLUSTER_NODE_NOT_MEMBER";
                case unchecked((NtStatusCodes)0xC013000F): return "STATUS_CLUSTER_JOIN_NOT_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC0130010): return "STATUS_CLUSTER_INVALID_NETWORK";
                case unchecked((NtStatusCodes)0xC0130011): return "STATUS_CLUSTER_NO_NET_ADAPTERS";
                case unchecked((NtStatusCodes)0xC0130012): return "STATUS_CLUSTER_NODE_UP";
                case unchecked((NtStatusCodes)0xC0130013): return "STATUS_CLUSTER_NODE_PAUSED";
                case unchecked((NtStatusCodes)0xC0130014): return "STATUS_CLUSTER_NODE_NOT_PAUSED";
                case unchecked((NtStatusCodes)0xC0130015): return "STATUS_CLUSTER_NO_SECURITY_CONTEXT";
                case unchecked((NtStatusCodes)0xC0130016): return "STATUS_CLUSTER_NETWORK_NOT_INTERNAL";
                case unchecked((NtStatusCodes)0xC0130017): return "STATUS_CLUSTER_POISONED";
                case unchecked((NtStatusCodes)0xC0130018): return "STATUS_CLUSTER_NON_CSV_PATH";
                case unchecked((NtStatusCodes)0xC0130019): return "STATUS_CLUSTER_CSV_VOLUME_NOT_LOCAL";
                case unchecked((NtStatusCodes)0xC0130020): return "STATUS_CLUSTER_CSV_READ_OPLOCK_BREAK_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC0130021): return "STATUS_CLUSTER_CSV_AUTO_PAUSE_ERROR";
                case unchecked((NtStatusCodes)0xC0130022): return "STATUS_CLUSTER_CSV_REDIRECTED";
                case unchecked((NtStatusCodes)0xC0130023): return "STATUS_CLUSTER_CSV_NOT_REDIRECTED";
                case unchecked((NtStatusCodes)0xC0130024): return "STATUS_CLUSTER_CSV_VOLUME_DRAINING";
                case unchecked((NtStatusCodes)0xC0130025): return "STATUS_CLUSTER_CSV_SNAPSHOT_CREATION_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC0130026): return "STATUS_CLUSTER_CSV_VOLUME_DRAINING_SUCCEEDED_DOWNLEVEL";
                case unchecked((NtStatusCodes)0xC0130027): return "STATUS_CLUSTER_CSV_NO_SNAPSHOTS";
                case unchecked((NtStatusCodes)0xC0130028): return "STATUS_CSV_IO_PAUSE_TIMEOUT";
                case unchecked((NtStatusCodes)0xC0130029): return "STATUS_CLUSTER_CSV_INVALID_HANDLE";
                case unchecked((NtStatusCodes)0xC0130030): return "STATUS_CLUSTER_CSV_SUPPORTED_ONLY_ON_COORDINATOR";
                case unchecked((NtStatusCodes)0xC0130031): return "STATUS_CLUSTER_CAM_TICKET_REPLAY_DETECTED";
                case unchecked((NtStatusCodes)0xC0190001): return "STATUS_TRANSACTIONAL_CONFLICT";
                case unchecked((NtStatusCodes)0xC0190002): return "STATUS_INVALID_TRANSACTION";
                case unchecked((NtStatusCodes)0xC0190003): return "STATUS_TRANSACTION_NOT_ACTIVE";
                case unchecked((NtStatusCodes)0xC0190004): return "STATUS_TM_INITIALIZATION_FAILED";
                case unchecked((NtStatusCodes)0xC0190005): return "STATUS_RM_NOT_ACTIVE";
                case unchecked((NtStatusCodes)0xC0190006): return "STATUS_RM_METADATA_CORRUPT";
                case unchecked((NtStatusCodes)0xC0190007): return "STATUS_TRANSACTION_NOT_JOINED";
                case unchecked((NtStatusCodes)0xC0190008): return "STATUS_DIRECTORY_NOT_RM";
                case unchecked((NtStatusCodes)0x80190009): return "STATUS_COULD_NOT_RESIZE_LOG";
                case unchecked((NtStatusCodes)0xC019000A): return "STATUS_TRANSACTIONS_UNSUPPORTED_REMOTE";
                case unchecked((NtStatusCodes)0xC019000B): return "STATUS_LOG_RESIZE_INVALID_SIZE";
                case unchecked((NtStatusCodes)0xC019000C): return "STATUS_REMOTE_FILE_VERSION_MISMATCH";
                case unchecked((NtStatusCodes)0xC019000F): return "STATUS_CRM_PROTOCOL_ALREADY_EXISTS";
                case unchecked((NtStatusCodes)0xC0190010): return "STATUS_TRANSACTION_PROPAGATION_FAILED";
                case unchecked((NtStatusCodes)0xC0190011): return "STATUS_CRM_PROTOCOL_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0190012): return "STATUS_TRANSACTION_SUPERIOR_EXISTS";
                case unchecked((NtStatusCodes)0xC0190013): return "STATUS_TRANSACTION_REQUEST_NOT_VALID";
                case unchecked((NtStatusCodes)0xC0190014): return "STATUS_TRANSACTION_NOT_REQUESTED";
                case unchecked((NtStatusCodes)0xC0190015): return "STATUS_TRANSACTION_ALREADY_ABORTED";
                case unchecked((NtStatusCodes)0xC0190016): return "STATUS_TRANSACTION_ALREADY_COMMITTED";
                case unchecked((NtStatusCodes)0xC0190017): return "STATUS_TRANSACTION_INVALID_MARSHALL_BUFFER";
                case unchecked((NtStatusCodes)0xC0190018): return "STATUS_CURRENT_TRANSACTION_NOT_VALID";
                case unchecked((NtStatusCodes)0xC0190019): return "STATUS_LOG_GROWTH_FAILED";
                case unchecked((NtStatusCodes)0xC0190021): return "STATUS_OBJECT_NO_LONGER_EXISTS";
                case unchecked((NtStatusCodes)0xC0190022): return "STATUS_STREAM_MINIVERSION_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0190023): return "STATUS_STREAM_MINIVERSION_NOT_VALID";
                case unchecked((NtStatusCodes)0xC0190024): return "STATUS_MINIVERSION_INACCESSIBLE_FROM_SPECIFIED_TRANSACTION";
                case unchecked((NtStatusCodes)0xC0190025): return "STATUS_CANT_OPEN_MINIVERSION_WITH_MODIFY_INTENT";
                case unchecked((NtStatusCodes)0xC0190026): return "STATUS_CANT_CREATE_MORE_STREAM_MINIVERSIONS";
                case unchecked((NtStatusCodes)0xC0190028): return "STATUS_HANDLE_NO_LONGER_VALID";
                case unchecked((NtStatusCodes)0x80190029): return "STATUS_NO_TXF_METADATA";
                case unchecked((NtStatusCodes)0xC0190030): return "STATUS_LOG_CORRUPTION_DETECTED";
                case unchecked((NtStatusCodes)0x80190031): return "STATUS_CANT_RECOVER_WITH_HANDLE_OPEN";
                case unchecked((NtStatusCodes)0xC0190032): return "STATUS_RM_DISCONNECTED";
                case unchecked((NtStatusCodes)0xC0190033): return "STATUS_ENLISTMENT_NOT_SUPERIOR";
                case unchecked((NtStatusCodes)0x40190034): return "STATUS_RECOVERY_NOT_NEEDED";
                case unchecked((NtStatusCodes)0x40190035): return "STATUS_RM_ALREADY_STARTED";
                case unchecked((NtStatusCodes)0xC0190036): return "STATUS_FILE_IDENTITY_NOT_PERSISTENT";
                case unchecked((NtStatusCodes)0xC0190037): return "STATUS_CANT_BREAK_TRANSACTIONAL_DEPENDENCY";
                case unchecked((NtStatusCodes)0xC0190038): return "STATUS_CANT_CROSS_RM_BOUNDARY";
                case unchecked((NtStatusCodes)0xC0190039): return "STATUS_TXF_DIR_NOT_EMPTY";
                case unchecked((NtStatusCodes)0xC019003A): return "STATUS_INDOUBT_TRANSACTIONS_EXIST";
                case unchecked((NtStatusCodes)0xC019003B): return "STATUS_TM_VOLATILE";
                case unchecked((NtStatusCodes)0xC019003C): return "STATUS_ROLLBACK_TIMER_EXPIRED";
                case unchecked((NtStatusCodes)0xC019003D): return "STATUS_TXF_ATTRIBUTE_CORRUPT";
                case unchecked((NtStatusCodes)0xC019003E): return "STATUS_EFS_NOT_ALLOWED_IN_TRANSACTION";
                case unchecked((NtStatusCodes)0xC019003F): return "STATUS_TRANSACTIONAL_OPEN_NOT_ALLOWED";
                case unchecked((NtStatusCodes)0xC0190040): return "STATUS_TRANSACTED_MAPPING_UNSUPPORTED_REMOTE";
                case unchecked((NtStatusCodes)0x80190041): return "STATUS_TXF_METADATA_ALREADY_PRESENT";
                case unchecked((NtStatusCodes)0x80190042): return "STATUS_TRANSACTION_SCOPE_CALLBACKS_NOT_SET";
                case unchecked((NtStatusCodes)0xC0190043): return "STATUS_TRANSACTION_REQUIRED_PROMOTION";
                case unchecked((NtStatusCodes)0xC0190044): return "STATUS_CANNOT_EXECUTE_FILE_IN_TRANSACTION";
                case unchecked((NtStatusCodes)0xC0190045): return "STATUS_TRANSACTIONS_NOT_FROZEN";
                case unchecked((NtStatusCodes)0xC0190046): return "STATUS_TRANSACTION_FREEZE_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC0190047): return "STATUS_NOT_SNAPSHOT_VOLUME";
                case unchecked((NtStatusCodes)0xC0190048): return "STATUS_NO_SAVEPOINT_WITH_OPEN_FILES";
                case unchecked((NtStatusCodes)0xC0190049): return "STATUS_SPARSE_NOT_ALLOWED_IN_TRANSACTION";
                case unchecked((NtStatusCodes)0xC019004A): return "STATUS_TM_IDENTITY_MISMATCH";
                case unchecked((NtStatusCodes)0xC019004B): return "STATUS_FLOATED_SECTION";
                case unchecked((NtStatusCodes)0xC019004C): return "STATUS_CANNOT_ACCEPT_TRANSACTED_WORK";
                case unchecked((NtStatusCodes)0xC019004D): return "STATUS_CANNOT_ABORT_TRANSACTIONS";
                case unchecked((NtStatusCodes)0xC019004E): return "STATUS_TRANSACTION_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC019004F): return "STATUS_RESOURCEMANAGER_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0190050): return "STATUS_ENLISTMENT_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0190051): return "STATUS_TRANSACTIONMANAGER_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0190052): return "STATUS_TRANSACTIONMANAGER_NOT_ONLINE";
                case unchecked((NtStatusCodes)0xC0190053): return "STATUS_TRANSACTIONMANAGER_RECOVERY_NAME_COLLISION";
                case unchecked((NtStatusCodes)0xC0190054): return "STATUS_TRANSACTION_NOT_ROOT";
                case unchecked((NtStatusCodes)0xC0190055): return "STATUS_TRANSACTION_OBJECT_EXPIRED";
                case unchecked((NtStatusCodes)0xC0190056): return "STATUS_COMPRESSION_NOT_ALLOWED_IN_TRANSACTION";
                case unchecked((NtStatusCodes)0xC0190057): return "STATUS_TRANSACTION_RESPONSE_NOT_ENLISTED";
                case unchecked((NtStatusCodes)0xC0190058): return "STATUS_TRANSACTION_RECORD_TOO_LONG";
                case unchecked((NtStatusCodes)0xC0190059): return "STATUS_NO_LINK_TRACKING_IN_TRANSACTION";
                case unchecked((NtStatusCodes)0xC019005A): return "STATUS_OPERATION_NOT_SUPPORTED_IN_TRANSACTION";
                case unchecked((NtStatusCodes)0xC019005B): return "STATUS_TRANSACTION_INTEGRITY_VIOLATED";
                case unchecked((NtStatusCodes)0xC019005C): return "STATUS_TRANSACTIONMANAGER_IDENTITY_MISMATCH";
                case unchecked((NtStatusCodes)0xC019005D): return "STATUS_RM_CANNOT_BE_FROZEN_FOR_SNAPSHOT";
                case unchecked((NtStatusCodes)0xC019005E): return "STATUS_TRANSACTION_MUST_WRITETHROUGH";
                case unchecked((NtStatusCodes)0xC019005F): return "STATUS_TRANSACTION_NO_SUPERIOR";
                case unchecked((NtStatusCodes)0xC0190060): return "STATUS_EXPIRED_HANDLE";
                case unchecked((NtStatusCodes)0xC0190061): return "STATUS_TRANSACTION_NOT_ENLISTED";
                case unchecked((NtStatusCodes)0xC01A0001): return "STATUS_LOG_SECTOR_INVALID";
                case unchecked((NtStatusCodes)0xC01A0002): return "STATUS_LOG_SECTOR_PARITY_INVALID";
                case unchecked((NtStatusCodes)0xC01A0003): return "STATUS_LOG_SECTOR_REMAPPED";
                case unchecked((NtStatusCodes)0xC01A0004): return "STATUS_LOG_BLOCK_INCOMPLETE";
                case unchecked((NtStatusCodes)0xC01A0005): return "STATUS_LOG_INVALID_RANGE";
                case unchecked((NtStatusCodes)0xC01A0006): return "STATUS_LOG_BLOCKS_EXHAUSTED";
                case unchecked((NtStatusCodes)0xC01A0007): return "STATUS_LOG_READ_CONTEXT_INVALID";
                case unchecked((NtStatusCodes)0xC01A0008): return "STATUS_LOG_RESTART_INVALID";
                case unchecked((NtStatusCodes)0xC01A0009): return "STATUS_LOG_BLOCK_VERSION";
                case unchecked((NtStatusCodes)0xC01A000A): return "STATUS_LOG_BLOCK_INVALID";
                case unchecked((NtStatusCodes)0xC01A000B): return "STATUS_LOG_READ_MODE_INVALID";
                case unchecked((NtStatusCodes)0x401A000C): return "STATUS_LOG_NO_RESTART";
                case unchecked((NtStatusCodes)0xC01A000D): return "STATUS_LOG_METADATA_CORRUPT";
                case unchecked((NtStatusCodes)0xC01A000E): return "STATUS_LOG_METADATA_INVALID";
                case unchecked((NtStatusCodes)0xC01A000F): return "STATUS_LOG_METADATA_INCONSISTENT";
                case unchecked((NtStatusCodes)0xC01A0010): return "STATUS_LOG_RESERVATION_INVALID";
                case unchecked((NtStatusCodes)0xC01A0011): return "STATUS_LOG_CANT_DELETE";
                case unchecked((NtStatusCodes)0xC01A0012): return "STATUS_LOG_CONTAINER_LIMIT_EXCEEDED";
                case unchecked((NtStatusCodes)0xC01A0013): return "STATUS_LOG_START_OF_LOG";
                case unchecked((NtStatusCodes)0xC01A0014): return "STATUS_LOG_POLICY_ALREADY_INSTALLED";
                case unchecked((NtStatusCodes)0xC01A0015): return "STATUS_LOG_POLICY_NOT_INSTALLED";
                case unchecked((NtStatusCodes)0xC01A0016): return "STATUS_LOG_POLICY_INVALID";
                case unchecked((NtStatusCodes)0xC01A0017): return "STATUS_LOG_POLICY_CONFLICT";
                case unchecked((NtStatusCodes)0xC01A0018): return "STATUS_LOG_PINNED_ARCHIVE_TAIL";
                case unchecked((NtStatusCodes)0xC01A0019): return "STATUS_LOG_RECORD_NONEXISTENT";
                case unchecked((NtStatusCodes)0xC01A001A): return "STATUS_LOG_RECORDS_RESERVED_INVALID";
                case unchecked((NtStatusCodes)0xC01A001B): return "STATUS_LOG_SPACE_RESERVED_INVALID";
                case unchecked((NtStatusCodes)0xC01A001C): return "STATUS_LOG_TAIL_INVALID";
                case unchecked((NtStatusCodes)0xC01A001D): return "STATUS_LOG_FULL";
                case unchecked((NtStatusCodes)0xC01A001E): return "STATUS_LOG_MULTIPLEXED";
                case unchecked((NtStatusCodes)0xC01A001F): return "STATUS_LOG_DEDICATED";
                case unchecked((NtStatusCodes)0xC01A0020): return "STATUS_LOG_ARCHIVE_NOT_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC01A0021): return "STATUS_LOG_ARCHIVE_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC01A0022): return "STATUS_LOG_EPHEMERAL";
                case unchecked((NtStatusCodes)0xC01A0023): return "STATUS_LOG_NOT_ENOUGH_CONTAINERS";
                case unchecked((NtStatusCodes)0xC01A0024): return "STATUS_LOG_CLIENT_ALREADY_REGISTERED";
                case unchecked((NtStatusCodes)0xC01A0025): return "STATUS_LOG_CLIENT_NOT_REGISTERED";
                case unchecked((NtStatusCodes)0xC01A0026): return "STATUS_LOG_FULL_HANDLER_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC01A0027): return "STATUS_LOG_CONTAINER_READ_FAILED";
                case unchecked((NtStatusCodes)0xC01A0028): return "STATUS_LOG_CONTAINER_WRITE_FAILED";
                case unchecked((NtStatusCodes)0xC01A0029): return "STATUS_LOG_CONTAINER_OPEN_FAILED";
                case unchecked((NtStatusCodes)0xC01A002A): return "STATUS_LOG_CONTAINER_STATE_INVALID";
                case unchecked((NtStatusCodes)0xC01A002B): return "STATUS_LOG_STATE_INVALID";
                case unchecked((NtStatusCodes)0xC01A002C): return "STATUS_LOG_PINNED";
                case unchecked((NtStatusCodes)0xC01A002D): return "STATUS_LOG_METADATA_FLUSH_FAILED";
                case unchecked((NtStatusCodes)0xC01A002E): return "STATUS_LOG_INCONSISTENT_SECURITY";
                case unchecked((NtStatusCodes)0xC01A002F): return "STATUS_LOG_APPENDED_FLUSH_FAILED";
                case unchecked((NtStatusCodes)0xC01A0030): return "STATUS_LOG_PINNED_RESERVATION";
                case unchecked((NtStatusCodes)0xC01B00EA): return "STATUS_VIDEO_HUNG_DISPLAY_DRIVER_THREAD";
                case unchecked((NtStatusCodes)0x801B00EB): return "STATUS_VIDEO_HUNG_DISPLAY_DRIVER_THREAD_RECOVERED";
                case unchecked((NtStatusCodes)0x401B00EC): return "STATUS_VIDEO_DRIVER_DEBUG_REPORT_REQUEST";
                case unchecked((NtStatusCodes)0xC01D0001): return "STATUS_MONITOR_NO_DESCRIPTOR";
                case unchecked((NtStatusCodes)0xC01D0002): return "STATUS_MONITOR_UNKNOWN_DESCRIPTOR_FORMAT";
                case unchecked((NtStatusCodes)0xC01D0003): return "STATUS_MONITOR_INVALID_DESCRIPTOR_CHECKSUM";
                case unchecked((NtStatusCodes)0xC01D0004): return "STATUS_MONITOR_INVALID_STANDARD_TIMING_BLOCK";
                case unchecked((NtStatusCodes)0xC01D0005): return "STATUS_MONITOR_WMI_DATABLOCK_REGISTRATION_FAILED";
                case unchecked((NtStatusCodes)0xC01D0006): return "STATUS_MONITOR_INVALID_SERIAL_NUMBER_MONDSC_BLOCK";
                case unchecked((NtStatusCodes)0xC01D0007): return "STATUS_MONITOR_INVALID_USER_FRIENDLY_MONDSC_BLOCK";
                case unchecked((NtStatusCodes)0xC01D0008): return "STATUS_MONITOR_NO_MORE_DESCRIPTOR_DATA";
                case unchecked((NtStatusCodes)0xC01D0009): return "STATUS_MONITOR_INVALID_DETAILED_TIMING_BLOCK";
                case unchecked((NtStatusCodes)0xC01D000A): return "STATUS_MONITOR_INVALID_MANUFACTURE_DATE";
                case unchecked((NtStatusCodes)0xC01E0000): return "STATUS_GRAPHICS_NOT_EXCLUSIVE_MODE_OWNER";
                case unchecked((NtStatusCodes)0xC01E0001): return "STATUS_GRAPHICS_INSUFFICIENT_DMA_BUFFER";
                case unchecked((NtStatusCodes)0xC01E0002): return "STATUS_GRAPHICS_INVALID_DISPLAY_ADAPTER";
                case unchecked((NtStatusCodes)0xC01E0003): return "STATUS_GRAPHICS_ADAPTER_WAS_RESET";
                case unchecked((NtStatusCodes)0xC01E0004): return "STATUS_GRAPHICS_INVALID_DRIVER_MODEL";
                case unchecked((NtStatusCodes)0xC01E0005): return "STATUS_GRAPHICS_PRESENT_MODE_CHANGED";
                case unchecked((NtStatusCodes)0xC01E0006): return "STATUS_GRAPHICS_PRESENT_OCCLUDED";
                case unchecked((NtStatusCodes)0xC01E0007): return "STATUS_GRAPHICS_PRESENT_DENIED";
                case unchecked((NtStatusCodes)0xC01E0008): return "STATUS_GRAPHICS_CANNOTCOLORCONVERT";
                case unchecked((NtStatusCodes)0xC01E0009): return "STATUS_GRAPHICS_DRIVER_MISMATCH";
                case unchecked((NtStatusCodes)0x401E000A): return "STATUS_GRAPHICS_PARTIAL_DATA_POPULATED";
                case unchecked((NtStatusCodes)0xC01E000B): return "STATUS_GRAPHICS_PRESENT_REDIRECTION_DISABLED";
                case unchecked((NtStatusCodes)0xC01E000C): return "STATUS_GRAPHICS_PRESENT_UNOCCLUDED";
                case unchecked((NtStatusCodes)0xC01E000D): return "STATUS_GRAPHICS_WINDOWDC_NOT_AVAILABLE";
                case unchecked((NtStatusCodes)0xC01E000E): return "STATUS_GRAPHICS_WINDOWLESS_PRESENT_DISABLED";
                case unchecked((NtStatusCodes)0xC01E000F): return "STATUS_GRAPHICS_PRESENT_INVALID_WINDOW";
                case unchecked((NtStatusCodes)0xC01E0010): return "STATUS_GRAPHICS_PRESENT_BUFFER_NOT_BOUND";
                case unchecked((NtStatusCodes)0xC01E0011): return "STATUS_GRAPHICS_VAIL_STATE_CHANGED";
                case unchecked((NtStatusCodes)0xC01E0012): return "STATUS_GRAPHICS_INDIRECT_DISPLAY_ABANDON_SWAPCHAIN";
                case unchecked((NtStatusCodes)0xC01E0013): return "STATUS_GRAPHICS_INDIRECT_DISPLAY_DEVICE_STOPPED";
                case unchecked((NtStatusCodes)0xC01E0100): return "STATUS_GRAPHICS_NO_VIDEO_MEMORY";
                case unchecked((NtStatusCodes)0xC01E0101): return "STATUS_GRAPHICS_CANT_LOCK_MEMORY";
                case unchecked((NtStatusCodes)0xC01E0102): return "STATUS_GRAPHICS_ALLOCATION_BUSY";
                case unchecked((NtStatusCodes)0xC01E0103): return "STATUS_GRAPHICS_TOO_MANY_REFERENCES";
                case unchecked((NtStatusCodes)0xC01E0104): return "STATUS_GRAPHICS_TRY_AGAIN_LATER";
                case unchecked((NtStatusCodes)0xC01E0105): return "STATUS_GRAPHICS_TRY_AGAIN_NOW";
                case unchecked((NtStatusCodes)0xC01E0106): return "STATUS_GRAPHICS_ALLOCATION_INVALID";
                case unchecked((NtStatusCodes)0xC01E0107): return "STATUS_GRAPHICS_UNSWIZZLING_APERTURE_UNAVAILABLE";
                case unchecked((NtStatusCodes)0xC01E0108): return "STATUS_GRAPHICS_UNSWIZZLING_APERTURE_UNSUPPORTED";
                case unchecked((NtStatusCodes)0xC01E0109): return "STATUS_GRAPHICS_CANT_EVICT_PINNED_ALLOCATION";
                case unchecked((NtStatusCodes)0xC01E0110): return "STATUS_GRAPHICS_INVALID_ALLOCATION_USAGE";
                case unchecked((NtStatusCodes)0xC01E0111): return "STATUS_GRAPHICS_CANT_RENDER_LOCKED_ALLOCATION";
                case unchecked((NtStatusCodes)0xC01E0112): return "STATUS_GRAPHICS_ALLOCATION_CLOSED";
                case unchecked((NtStatusCodes)0xC01E0113): return "STATUS_GRAPHICS_INVALID_ALLOCATION_INSTANCE";
                case unchecked((NtStatusCodes)0xC01E0114): return "STATUS_GRAPHICS_INVALID_ALLOCATION_HANDLE";
                case unchecked((NtStatusCodes)0xC01E0115): return "STATUS_GRAPHICS_WRONG_ALLOCATION_DEVICE";
                case unchecked((NtStatusCodes)0xC01E0116): return "STATUS_GRAPHICS_ALLOCATION_CONTENT_LOST";
                case unchecked((NtStatusCodes)0xC01E0200): return "STATUS_GRAPHICS_GPU_EXCEPTION_ON_DEVICE";
                case unchecked((NtStatusCodes)0x401E0201): return "STATUS_GRAPHICS_SKIP_ALLOCATION_PREPARATION";
                case unchecked((NtStatusCodes)0xC01E0300): return "STATUS_GRAPHICS_INVALID_VIDPN_TOPOLOGY";
                case unchecked((NtStatusCodes)0xC01E0301): return "STATUS_GRAPHICS_VIDPN_TOPOLOGY_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC01E0302): return "STATUS_GRAPHICS_VIDPN_TOPOLOGY_CURRENTLY_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC01E0303): return "STATUS_GRAPHICS_INVALID_VIDPN";
                case unchecked((NtStatusCodes)0xC01E0304): return "STATUS_GRAPHICS_INVALID_VIDEO_PRESENT_SOURCE";
                case unchecked((NtStatusCodes)0xC01E0305): return "STATUS_GRAPHICS_INVALID_VIDEO_PRESENT_TARGET";
                case unchecked((NtStatusCodes)0xC01E0306): return "STATUS_GRAPHICS_VIDPN_MODALITY_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0x401E0307): return "STATUS_GRAPHICS_MODE_NOT_PINNED";
                case unchecked((NtStatusCodes)0xC01E0308): return "STATUS_GRAPHICS_INVALID_VIDPN_SOURCEMODESET";
                case unchecked((NtStatusCodes)0xC01E0309): return "STATUS_GRAPHICS_INVALID_VIDPN_TARGETMODESET";
                case unchecked((NtStatusCodes)0xC01E030A): return "STATUS_GRAPHICS_INVALID_FREQUENCY";
                case unchecked((NtStatusCodes)0xC01E030B): return "STATUS_GRAPHICS_INVALID_ACTIVE_REGION";
                case unchecked((NtStatusCodes)0xC01E030C): return "STATUS_GRAPHICS_INVALID_TOTAL_REGION";
                case unchecked((NtStatusCodes)0xC01E0310): return "STATUS_GRAPHICS_INVALID_VIDEO_PRESENT_SOURCE_MODE";
                case unchecked((NtStatusCodes)0xC01E0311): return "STATUS_GRAPHICS_INVALID_VIDEO_PRESENT_TARGET_MODE";
                case unchecked((NtStatusCodes)0xC01E0312): return "STATUS_GRAPHICS_PINNED_MODE_MUST_REMAIN_IN_SET";
                case unchecked((NtStatusCodes)0xC01E0313): return "STATUS_GRAPHICS_PATH_ALREADY_IN_TOPOLOGY";
                case unchecked((NtStatusCodes)0xC01E0314): return "STATUS_GRAPHICS_MODE_ALREADY_IN_MODESET";
                case unchecked((NtStatusCodes)0xC01E0315): return "STATUS_GRAPHICS_INVALID_VIDEOPRESENTSOURCESET";
                case unchecked((NtStatusCodes)0xC01E0316): return "STATUS_GRAPHICS_INVALID_VIDEOPRESENTTARGETSET";
                case unchecked((NtStatusCodes)0xC01E0317): return "STATUS_GRAPHICS_SOURCE_ALREADY_IN_SET";
                case unchecked((NtStatusCodes)0xC01E0318): return "STATUS_GRAPHICS_TARGET_ALREADY_IN_SET";
                case unchecked((NtStatusCodes)0xC01E0319): return "STATUS_GRAPHICS_INVALID_VIDPN_PRESENT_PATH";
                case unchecked((NtStatusCodes)0xC01E031A): return "STATUS_GRAPHICS_NO_RECOMMENDED_VIDPN_TOPOLOGY";
                case unchecked((NtStatusCodes)0xC01E031B): return "STATUS_GRAPHICS_INVALID_MONITOR_FREQUENCYRANGESET";
                case unchecked((NtStatusCodes)0xC01E031C): return "STATUS_GRAPHICS_INVALID_MONITOR_FREQUENCYRANGE";
                case unchecked((NtStatusCodes)0xC01E031D): return "STATUS_GRAPHICS_FREQUENCYRANGE_NOT_IN_SET";
                case unchecked((NtStatusCodes)0x401E031E): return "STATUS_GRAPHICS_NO_PREFERRED_MODE";
                case unchecked((NtStatusCodes)0xC01E031F): return "STATUS_GRAPHICS_FREQUENCYRANGE_ALREADY_IN_SET";
                case unchecked((NtStatusCodes)0xC01E0320): return "STATUS_GRAPHICS_STALE_MODESET";
                case unchecked((NtStatusCodes)0xC01E0321): return "STATUS_GRAPHICS_INVALID_MONITOR_SOURCEMODESET";
                case unchecked((NtStatusCodes)0xC01E0322): return "STATUS_GRAPHICS_INVALID_MONITOR_SOURCE_MODE";
                case unchecked((NtStatusCodes)0xC01E0323): return "STATUS_GRAPHICS_NO_RECOMMENDED_FUNCTIONAL_VIDPN";
                case unchecked((NtStatusCodes)0xC01E0324): return "STATUS_GRAPHICS_MODE_ID_MUST_BE_UNIQUE";
                case unchecked((NtStatusCodes)0xC01E0325): return "STATUS_GRAPHICS_EMPTY_ADAPTER_MONITOR_MODE_SUPPORT_INTERSECTION";
                case unchecked((NtStatusCodes)0xC01E0326): return "STATUS_GRAPHICS_VIDEO_PRESENT_TARGETS_LESS_THAN_SOURCES";
                case unchecked((NtStatusCodes)0xC01E0327): return "STATUS_GRAPHICS_PATH_NOT_IN_TOPOLOGY";
                case unchecked((NtStatusCodes)0xC01E0328): return "STATUS_GRAPHICS_ADAPTER_MUST_HAVE_AT_LEAST_ONE_SOURCE";
                case unchecked((NtStatusCodes)0xC01E0329): return "STATUS_GRAPHICS_ADAPTER_MUST_HAVE_AT_LEAST_ONE_TARGET";
                case unchecked((NtStatusCodes)0xC01E032A): return "STATUS_GRAPHICS_INVALID_MONITORDESCRIPTORSET";
                case unchecked((NtStatusCodes)0xC01E032B): return "STATUS_GRAPHICS_INVALID_MONITORDESCRIPTOR";
                case unchecked((NtStatusCodes)0xC01E032C): return "STATUS_GRAPHICS_MONITORDESCRIPTOR_NOT_IN_SET";
                case unchecked((NtStatusCodes)0xC01E032D): return "STATUS_GRAPHICS_MONITORDESCRIPTOR_ALREADY_IN_SET";
                case unchecked((NtStatusCodes)0xC01E032E): return "STATUS_GRAPHICS_MONITORDESCRIPTOR_ID_MUST_BE_UNIQUE";
                case unchecked((NtStatusCodes)0xC01E032F): return "STATUS_GRAPHICS_INVALID_VIDPN_TARGET_SUBSET_TYPE";
                case unchecked((NtStatusCodes)0xC01E0330): return "STATUS_GRAPHICS_RESOURCES_NOT_RELATED";
                case unchecked((NtStatusCodes)0xC01E0331): return "STATUS_GRAPHICS_SOURCE_ID_MUST_BE_UNIQUE";
                case unchecked((NtStatusCodes)0xC01E0332): return "STATUS_GRAPHICS_TARGET_ID_MUST_BE_UNIQUE";
                case unchecked((NtStatusCodes)0xC01E0333): return "STATUS_GRAPHICS_NO_AVAILABLE_VIDPN_TARGET";
                case unchecked((NtStatusCodes)0xC01E0334): return "STATUS_GRAPHICS_MONITOR_COULD_NOT_BE_ASSOCIATED_WITH_ADAPTER";
                case unchecked((NtStatusCodes)0xC01E0335): return "STATUS_GRAPHICS_NO_VIDPNMGR";
                case unchecked((NtStatusCodes)0xC01E0336): return "STATUS_GRAPHICS_NO_ACTIVE_VIDPN";
                case unchecked((NtStatusCodes)0xC01E0337): return "STATUS_GRAPHICS_STALE_VIDPN_TOPOLOGY";
                case unchecked((NtStatusCodes)0xC01E0338): return "STATUS_GRAPHICS_MONITOR_NOT_CONNECTED";
                case unchecked((NtStatusCodes)0xC01E0339): return "STATUS_GRAPHICS_SOURCE_NOT_IN_TOPOLOGY";
                case unchecked((NtStatusCodes)0xC01E033A): return "STATUS_GRAPHICS_INVALID_PRIMARYSURFACE_SIZE";
                case unchecked((NtStatusCodes)0xC01E033B): return "STATUS_GRAPHICS_INVALID_VISIBLEREGION_SIZE";
                case unchecked((NtStatusCodes)0xC01E033C): return "STATUS_GRAPHICS_INVALID_STRIDE";
                case unchecked((NtStatusCodes)0xC01E033D): return "STATUS_GRAPHICS_INVALID_PIXELFORMAT";
                case unchecked((NtStatusCodes)0xC01E033E): return "STATUS_GRAPHICS_INVALID_COLORBASIS";
                case unchecked((NtStatusCodes)0xC01E033F): return "STATUS_GRAPHICS_INVALID_PIXELVALUEACCESSMODE";
                case unchecked((NtStatusCodes)0xC01E0340): return "STATUS_GRAPHICS_TARGET_NOT_IN_TOPOLOGY";
                case unchecked((NtStatusCodes)0xC01E0341): return "STATUS_GRAPHICS_NO_DISPLAY_MODE_MANAGEMENT_SUPPORT";
                case unchecked((NtStatusCodes)0xC01E0342): return "STATUS_GRAPHICS_VIDPN_SOURCE_IN_USE";
                case unchecked((NtStatusCodes)0xC01E0343): return "STATUS_GRAPHICS_CANT_ACCESS_ACTIVE_VIDPN";
                case unchecked((NtStatusCodes)0xC01E0344): return "STATUS_GRAPHICS_INVALID_PATH_IMPORTANCE_ORDINAL";
                case unchecked((NtStatusCodes)0xC01E0345): return "STATUS_GRAPHICS_INVALID_PATH_CONTENT_GEOMETRY_TRANSFORMATION";
                case unchecked((NtStatusCodes)0xC01E0346): return "STATUS_GRAPHICS_PATH_CONTENT_GEOMETRY_TRANSFORMATION_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC01E0347): return "STATUS_GRAPHICS_INVALID_GAMMA_RAMP";
                case unchecked((NtStatusCodes)0xC01E0348): return "STATUS_GRAPHICS_GAMMA_RAMP_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC01E0349): return "STATUS_GRAPHICS_MULTISAMPLING_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC01E034A): return "STATUS_GRAPHICS_MODE_NOT_IN_MODESET";
                case unchecked((NtStatusCodes)0x401E034B): return "STATUS_GRAPHICS_DATASET_IS_EMPTY";
                case unchecked((NtStatusCodes)0x401E034C): return "STATUS_GRAPHICS_NO_MORE_ELEMENTS_IN_DATASET";
                case unchecked((NtStatusCodes)0xC01E034D): return "STATUS_GRAPHICS_INVALID_VIDPN_TOPOLOGY_RECOMMENDATION_REASON";
                case unchecked((NtStatusCodes)0xC01E034E): return "STATUS_GRAPHICS_INVALID_PATH_CONTENT_TYPE";
                case unchecked((NtStatusCodes)0xC01E034F): return "STATUS_GRAPHICS_INVALID_COPYPROTECTION_TYPE";
                case unchecked((NtStatusCodes)0xC01E0350): return "STATUS_GRAPHICS_UNASSIGNED_MODESET_ALREADY_EXISTS";
                case unchecked((NtStatusCodes)0x401E0351): return "STATUS_GRAPHICS_PATH_CONTENT_GEOMETRY_TRANSFORMATION_NOT_PINNED";
                case unchecked((NtStatusCodes)0xC01E0352): return "STATUS_GRAPHICS_INVALID_SCANLINE_ORDERING";
                case unchecked((NtStatusCodes)0xC01E0353): return "STATUS_GRAPHICS_TOPOLOGY_CHANGES_NOT_ALLOWED";
                case unchecked((NtStatusCodes)0xC01E0354): return "STATUS_GRAPHICS_NO_AVAILABLE_IMPORTANCE_ORDINALS";
                case unchecked((NtStatusCodes)0xC01E0355): return "STATUS_GRAPHICS_INCOMPATIBLE_PRIVATE_FORMAT";
                case unchecked((NtStatusCodes)0xC01E0356): return "STATUS_GRAPHICS_INVALID_MODE_PRUNING_ALGORITHM";
                case unchecked((NtStatusCodes)0xC01E0357): return "STATUS_GRAPHICS_INVALID_MONITOR_CAPABILITY_ORIGIN";
                case unchecked((NtStatusCodes)0xC01E0358): return "STATUS_GRAPHICS_INVALID_MONITOR_FREQUENCYRANGE_CONSTRAINT";
                case unchecked((NtStatusCodes)0xC01E0359): return "STATUS_GRAPHICS_MAX_NUM_PATHS_REACHED";
                case unchecked((NtStatusCodes)0xC01E035A): return "STATUS_GRAPHICS_CANCEL_VIDPN_TOPOLOGY_AUGMENTATION";
                case unchecked((NtStatusCodes)0xC01E035B): return "STATUS_GRAPHICS_INVALID_CLIENT_TYPE";
                case unchecked((NtStatusCodes)0xC01E035C): return "STATUS_GRAPHICS_CLIENTVIDPN_NOT_SET";
                case unchecked((NtStatusCodes)0xC01E0400): return "STATUS_GRAPHICS_SPECIFIED_CHILD_ALREADY_CONNECTED";
                case unchecked((NtStatusCodes)0xC01E0401): return "STATUS_GRAPHICS_CHILD_DESCRIPTOR_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0x401E042F): return "STATUS_GRAPHICS_UNKNOWN_CHILD_STATUS";
                case unchecked((NtStatusCodes)0xC01E0430): return "STATUS_GRAPHICS_NOT_A_LINKED_ADAPTER";
                case unchecked((NtStatusCodes)0xC01E0431): return "STATUS_GRAPHICS_LEADLINK_NOT_ENUMERATED";
                case unchecked((NtStatusCodes)0xC01E0432): return "STATUS_GRAPHICS_CHAINLINKS_NOT_ENUMERATED";
                case unchecked((NtStatusCodes)0xC01E0433): return "STATUS_GRAPHICS_ADAPTER_CHAIN_NOT_READY";
                case unchecked((NtStatusCodes)0xC01E0434): return "STATUS_GRAPHICS_CHAINLINKS_NOT_STARTED";
                case unchecked((NtStatusCodes)0xC01E0435): return "STATUS_GRAPHICS_CHAINLINKS_NOT_POWERED_ON";
                case unchecked((NtStatusCodes)0xC01E0436): return "STATUS_GRAPHICS_INCONSISTENT_DEVICE_LINK_STATE";
                case unchecked((NtStatusCodes)0x401E0437): return "STATUS_GRAPHICS_LEADLINK_START_DEFERRED";
                case unchecked((NtStatusCodes)0xC01E0438): return "STATUS_GRAPHICS_NOT_POST_DEVICE_DRIVER";
                case unchecked((NtStatusCodes)0x401E0439): return "STATUS_GRAPHICS_POLLING_TOO_FREQUENTLY";
                case unchecked((NtStatusCodes)0x401E043A): return "STATUS_GRAPHICS_START_DEFERRED";
                case unchecked((NtStatusCodes)0xC01E043B): return "STATUS_GRAPHICS_ADAPTER_ACCESS_NOT_EXCLUDED";
                case unchecked((NtStatusCodes)0x401E043C): return "STATUS_GRAPHICS_DEPENDABLE_CHILD_STATUS";
                case unchecked((NtStatusCodes)0xC01E0500): return "STATUS_GRAPHICS_OPM_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC01E0501): return "STATUS_GRAPHICS_COPP_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC01E0502): return "STATUS_GRAPHICS_UAB_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC01E0503): return "STATUS_GRAPHICS_OPM_INVALID_ENCRYPTED_PARAMETERS";
                case unchecked((NtStatusCodes)0xC01E0505): return "STATUS_GRAPHICS_OPM_NO_PROTECTED_OUTPUTS_EXIST";
                case unchecked((NtStatusCodes)0xC01E050B): return "STATUS_GRAPHICS_OPM_INTERNAL_ERROR";
                case unchecked((NtStatusCodes)0xC01E050C): return "STATUS_GRAPHICS_OPM_INVALID_HANDLE";
                case unchecked((NtStatusCodes)0xC01E050E): return "STATUS_GRAPHICS_PVP_INVALID_CERTIFICATE_LENGTH";
                case unchecked((NtStatusCodes)0xC01E050F): return "STATUS_GRAPHICS_OPM_SPANNING_MODE_ENABLED";
                case unchecked((NtStatusCodes)0xC01E0510): return "STATUS_GRAPHICS_OPM_THEATER_MODE_ENABLED";
                case unchecked((NtStatusCodes)0xC01E0511): return "STATUS_GRAPHICS_PVP_HFS_FAILED";
                case unchecked((NtStatusCodes)0xC01E0512): return "STATUS_GRAPHICS_OPM_INVALID_SRM";
                case unchecked((NtStatusCodes)0xC01E0513): return "STATUS_GRAPHICS_OPM_OUTPUT_DOES_NOT_SUPPORT_HDCP";
                case unchecked((NtStatusCodes)0xC01E0514): return "STATUS_GRAPHICS_OPM_OUTPUT_DOES_NOT_SUPPORT_ACP";
                case unchecked((NtStatusCodes)0xC01E0515): return "STATUS_GRAPHICS_OPM_OUTPUT_DOES_NOT_SUPPORT_CGMSA";
                case unchecked((NtStatusCodes)0xC01E0516): return "STATUS_GRAPHICS_OPM_HDCP_SRM_NEVER_SET";
                case unchecked((NtStatusCodes)0xC01E0517): return "STATUS_GRAPHICS_OPM_RESOLUTION_TOO_HIGH";
                case unchecked((NtStatusCodes)0xC01E0518): return "STATUS_GRAPHICS_OPM_ALL_HDCP_HARDWARE_ALREADY_IN_USE";
                case unchecked((NtStatusCodes)0xC01E051A): return "STATUS_GRAPHICS_OPM_PROTECTED_OUTPUT_NO_LONGER_EXISTS";
                case unchecked((NtStatusCodes)0xC01E051C): return "STATUS_GRAPHICS_OPM_PROTECTED_OUTPUT_DOES_NOT_HAVE_COPP_SEMANTICS";
                case unchecked((NtStatusCodes)0xC01E051D): return "STATUS_GRAPHICS_OPM_INVALID_INFORMATION_REQUEST";
                case unchecked((NtStatusCodes)0xC01E051E): return "STATUS_GRAPHICS_OPM_DRIVER_INTERNAL_ERROR";
                case unchecked((NtStatusCodes)0xC01E051F): return "STATUS_GRAPHICS_OPM_PROTECTED_OUTPUT_DOES_NOT_HAVE_OPM_SEMANTICS";
                case unchecked((NtStatusCodes)0xC01E0520): return "STATUS_GRAPHICS_OPM_SIGNALING_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC01E0521): return "STATUS_GRAPHICS_OPM_INVALID_CONFIGURATION_REQUEST";
                case unchecked((NtStatusCodes)0xC01E0580): return "STATUS_GRAPHICS_I2C_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC01E0581): return "STATUS_GRAPHICS_I2C_DEVICE_DOES_NOT_EXIST";
                case unchecked((NtStatusCodes)0xC01E0582): return "STATUS_GRAPHICS_I2C_ERROR_TRANSMITTING_DATA";
                case unchecked((NtStatusCodes)0xC01E0583): return "STATUS_GRAPHICS_I2C_ERROR_RECEIVING_DATA";
                case unchecked((NtStatusCodes)0xC01E0584): return "STATUS_GRAPHICS_DDCCI_VCP_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC01E0585): return "STATUS_GRAPHICS_DDCCI_INVALID_DATA";
                case unchecked((NtStatusCodes)0xC01E0586): return "STATUS_GRAPHICS_DDCCI_MONITOR_RETURNED_INVALID_TIMING_STATUS_BYTE";
                case unchecked((NtStatusCodes)0xC01E0587): return "STATUS_GRAPHICS_DDCCI_INVALID_CAPABILITIES_STRING";
                case unchecked((NtStatusCodes)0xC01E0588): return "STATUS_GRAPHICS_MCA_INTERNAL_ERROR";
                case unchecked((NtStatusCodes)0xC01E0589): return "STATUS_GRAPHICS_DDCCI_INVALID_MESSAGE_COMMAND";
                case unchecked((NtStatusCodes)0xC01E058A): return "STATUS_GRAPHICS_DDCCI_INVALID_MESSAGE_LENGTH";
                case unchecked((NtStatusCodes)0xC01E058B): return "STATUS_GRAPHICS_DDCCI_INVALID_MESSAGE_CHECKSUM";
                case unchecked((NtStatusCodes)0xC01E058C): return "STATUS_GRAPHICS_INVALID_PHYSICAL_MONITOR_HANDLE";
                case unchecked((NtStatusCodes)0xC01E058D): return "STATUS_GRAPHICS_MONITOR_NO_LONGER_EXISTS";
                case unchecked((NtStatusCodes)0xC01E05E0): return "STATUS_GRAPHICS_ONLY_CONSOLE_SESSION_SUPPORTED";
                case unchecked((NtStatusCodes)0xC01E05E1): return "STATUS_GRAPHICS_NO_DISPLAY_DEVICE_CORRESPONDS_TO_NAME";
                case unchecked((NtStatusCodes)0xC01E05E2): return "STATUS_GRAPHICS_DISPLAY_DEVICE_NOT_ATTACHED_TO_DESKTOP";
                case unchecked((NtStatusCodes)0xC01E05E3): return "STATUS_GRAPHICS_MIRRORING_DEVICES_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC01E05E4): return "STATUS_GRAPHICS_INVALID_POINTER";
                case unchecked((NtStatusCodes)0xC01E05E5): return "STATUS_GRAPHICS_NO_MONITORS_CORRESPOND_TO_DISPLAY_DEVICE";
                case unchecked((NtStatusCodes)0xC01E05E6): return "STATUS_GRAPHICS_PARAMETER_ARRAY_TOO_SMALL";
                case unchecked((NtStatusCodes)0xC01E05E7): return "STATUS_GRAPHICS_INTERNAL_ERROR";
                case unchecked((NtStatusCodes)0xC01E05E8): return "STATUS_GRAPHICS_SESSION_TYPE_CHANGE_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC0210000): return "STATUS_FVE_LOCKED_VOLUME";
                case unchecked((NtStatusCodes)0xC0210001): return "STATUS_FVE_NOT_ENCRYPTED";
                case unchecked((NtStatusCodes)0xC0210002): return "STATUS_FVE_BAD_INFORMATION";
                case unchecked((NtStatusCodes)0xC0210003): return "STATUS_FVE_TOO_SMALL";
                case unchecked((NtStatusCodes)0xC0210004): return "STATUS_FVE_FAILED_WRONG_FS";
                case unchecked((NtStatusCodes)0xC0210005): return "STATUS_FVE_BAD_PARTITION_SIZE";
                case unchecked((NtStatusCodes)0xC0210006): return "STATUS_FVE_FS_NOT_EXTENDED";
                case unchecked((NtStatusCodes)0xC0210007): return "STATUS_FVE_FS_MOUNTED";
                case unchecked((NtStatusCodes)0xC0210008): return "STATUS_FVE_NO_LICENSE";
                case unchecked((NtStatusCodes)0xC0210009): return "STATUS_FVE_ACTION_NOT_ALLOWED";
                case unchecked((NtStatusCodes)0xC021000A): return "STATUS_FVE_BAD_DATA";
                case unchecked((NtStatusCodes)0xC021000B): return "STATUS_FVE_VOLUME_NOT_BOUND";
                case unchecked((NtStatusCodes)0xC021000C): return "STATUS_FVE_NOT_DATA_VOLUME";
                case unchecked((NtStatusCodes)0xC021000D): return "STATUS_FVE_CONV_READ_ERROR";
                case unchecked((NtStatusCodes)0xC021000E): return "STATUS_FVE_CONV_WRITE_ERROR";
                case unchecked((NtStatusCodes)0xC021000F): return "STATUS_FVE_OVERLAPPED_UPDATE";
                case unchecked((NtStatusCodes)0xC0210010): return "STATUS_FVE_FAILED_SECTOR_SIZE";
                case unchecked((NtStatusCodes)0xC0210011): return "STATUS_FVE_FAILED_AUTHENTICATION";
                case unchecked((NtStatusCodes)0xC0210012): return "STATUS_FVE_NOT_OS_VOLUME";
                case unchecked((NtStatusCodes)0xC0210013): return "STATUS_FVE_KEYFILE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0210014): return "STATUS_FVE_KEYFILE_INVALID";
                case unchecked((NtStatusCodes)0xC0210015): return "STATUS_FVE_KEYFILE_NO_VMK";
                case unchecked((NtStatusCodes)0xC0210016): return "STATUS_FVE_TPM_DISABLED";
                case unchecked((NtStatusCodes)0xC0210017): return "STATUS_FVE_TPM_SRK_AUTH_NOT_ZERO";
                case unchecked((NtStatusCodes)0xC0210018): return "STATUS_FVE_TPM_INVALID_PCR";
                case unchecked((NtStatusCodes)0xC0210019): return "STATUS_FVE_TPM_NO_VMK";
                case unchecked((NtStatusCodes)0xC021001A): return "STATUS_FVE_PIN_INVALID";
                case unchecked((NtStatusCodes)0xC021001B): return "STATUS_FVE_AUTH_INVALID_APPLICATION";
                case unchecked((NtStatusCodes)0xC021001C): return "STATUS_FVE_AUTH_INVALID_CONFIG";
                case unchecked((NtStatusCodes)0xC021001D): return "STATUS_FVE_DEBUGGER_ENABLED";
                case unchecked((NtStatusCodes)0xC021001E): return "STATUS_FVE_DRY_RUN_FAILED";
                case unchecked((NtStatusCodes)0xC021001F): return "STATUS_FVE_BAD_METADATA_POINTER";
                case unchecked((NtStatusCodes)0xC0210020): return "STATUS_FVE_OLD_METADATA_COPY";
                case unchecked((NtStatusCodes)0xC0210021): return "STATUS_FVE_REBOOT_REQUIRED";
                case unchecked((NtStatusCodes)0xC0210022): return "STATUS_FVE_RAW_ACCESS";
                case unchecked((NtStatusCodes)0xC0210023): return "STATUS_FVE_RAW_BLOCKED";
                case unchecked((NtStatusCodes)0xC0210024): return "STATUS_FVE_NO_AUTOUNLOCK_MASTER_KEY";
                case unchecked((NtStatusCodes)0xC0210025): return "STATUS_FVE_MOR_FAILED";
                case unchecked((NtStatusCodes)0xC0210026): return "STATUS_FVE_NO_FEATURE_LICENSE";
                case unchecked((NtStatusCodes)0xC0210027): return "STATUS_FVE_POLICY_USER_DISABLE_RDV_NOT_ALLOWED";
                case unchecked((NtStatusCodes)0xC0210028): return "STATUS_FVE_CONV_RECOVERY_FAILED";
                case unchecked((NtStatusCodes)0xC0210029): return "STATUS_FVE_VIRTUALIZED_SPACE_TOO_BIG";
                case unchecked((NtStatusCodes)0xC021002A): return "STATUS_FVE_INVALID_DATUM_TYPE";
                case unchecked((NtStatusCodes)0xC0210030): return "STATUS_FVE_VOLUME_TOO_SMALL";
                case unchecked((NtStatusCodes)0xC0210031): return "STATUS_FVE_ENH_PIN_INVALID";
                case unchecked((NtStatusCodes)0xC0210032): return "STATUS_FVE_FULL_ENCRYPTION_NOT_ALLOWED_ON_TP_STORAGE";
                case unchecked((NtStatusCodes)0xC0210033): return "STATUS_FVE_WIPE_NOT_ALLOWED_ON_TP_STORAGE";
                case unchecked((NtStatusCodes)0xC0210034): return "STATUS_FVE_NOT_ALLOWED_ON_CSV_STACK";
                case unchecked((NtStatusCodes)0xC0210035): return "STATUS_FVE_NOT_ALLOWED_ON_CLUSTER";
                case unchecked((NtStatusCodes)0xC0210036): return "STATUS_FVE_NOT_ALLOWED_TO_UPGRADE_WHILE_CONVERTING";
                case unchecked((NtStatusCodes)0xC0210037): return "STATUS_FVE_WIPE_CANCEL_NOT_APPLICABLE";
                case unchecked((NtStatusCodes)0xC0210038): return "STATUS_FVE_EDRIVE_DRY_RUN_FAILED";
                case unchecked((NtStatusCodes)0xC0210039): return "STATUS_FVE_SECUREBOOT_DISABLED";
                case unchecked((NtStatusCodes)0xC021003A): return "STATUS_FVE_SECUREBOOT_CONFIG_CHANGE";
                case unchecked((NtStatusCodes)0xC021003B): return "STATUS_FVE_DEVICE_LOCKEDOUT";
                case unchecked((NtStatusCodes)0xC021003C): return "STATUS_FVE_VOLUME_EXTEND_PREVENTS_EOW_DECRYPT";
                case unchecked((NtStatusCodes)0xC021003D): return "STATUS_FVE_NOT_DE_VOLUME";
                case unchecked((NtStatusCodes)0xC021003E): return "STATUS_FVE_PROTECTION_DISABLED";
                case unchecked((NtStatusCodes)0xC021003F): return "STATUS_FVE_PROTECTION_CANNOT_BE_DISABLED";
                case unchecked((NtStatusCodes)0xC0210040): return "STATUS_FVE_OSV_KSR_NOT_ALLOWED";
                case unchecked((NtStatusCodes)0xC0210041): return "STATUS_FVE_EDRIVE_BAND_ENUMERATION_FAILED";
                case unchecked((NtStatusCodes)0xC0220001): return "STATUS_FWP_CALLOUT_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0220002): return "STATUS_FWP_CONDITION_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0220003): return "STATUS_FWP_FILTER_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0220004): return "STATUS_FWP_LAYER_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0220005): return "STATUS_FWP_PROVIDER_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0220006): return "STATUS_FWP_PROVIDER_CONTEXT_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0220007): return "STATUS_FWP_SUBLAYER_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0220008): return "STATUS_FWP_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0220009): return "STATUS_FWP_ALREADY_EXISTS";
                case unchecked((NtStatusCodes)0xC022000A): return "STATUS_FWP_IN_USE";
                case unchecked((NtStatusCodes)0xC022000B): return "STATUS_FWP_DYNAMIC_SESSION_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC022000C): return "STATUS_FWP_WRONG_SESSION";
                case unchecked((NtStatusCodes)0xC022000D): return "STATUS_FWP_NO_TXN_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC022000E): return "STATUS_FWP_TXN_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC022000F): return "STATUS_FWP_TXN_ABORTED";
                case unchecked((NtStatusCodes)0xC0220010): return "STATUS_FWP_SESSION_ABORTED";
                case unchecked((NtStatusCodes)0xC0220011): return "STATUS_FWP_INCOMPATIBLE_TXN";
                case unchecked((NtStatusCodes)0xC0220012): return "STATUS_FWP_TIMEOUT";
                case unchecked((NtStatusCodes)0xC0220013): return "STATUS_FWP_NET_EVENTS_DISABLED";
                case unchecked((NtStatusCodes)0xC0220014): return "STATUS_FWP_INCOMPATIBLE_LAYER";
                case unchecked((NtStatusCodes)0xC0220015): return "STATUS_FWP_KM_CLIENTS_ONLY";
                case unchecked((NtStatusCodes)0xC0220016): return "STATUS_FWP_LIFETIME_MISMATCH";
                case unchecked((NtStatusCodes)0xC0220017): return "STATUS_FWP_BUILTIN_OBJECT";
                case unchecked((NtStatusCodes)0xC0220018): return "STATUS_FWP_TOO_MANY_CALLOUTS";
                case unchecked((NtStatusCodes)0xC0220019): return "STATUS_FWP_NOTIFICATION_DROPPED";
                case unchecked((NtStatusCodes)0xC022001A): return "STATUS_FWP_TRAFFIC_MISMATCH";
                case unchecked((NtStatusCodes)0xC022001B): return "STATUS_FWP_INCOMPATIBLE_SA_STATE";
                case unchecked((NtStatusCodes)0xC022001C): return "STATUS_FWP_NULL_POINTER";
                case unchecked((NtStatusCodes)0xC022001D): return "STATUS_FWP_INVALID_ENUMERATOR";
                case unchecked((NtStatusCodes)0xC022001E): return "STATUS_FWP_INVALID_FLAGS";
                case unchecked((NtStatusCodes)0xC022001F): return "STATUS_FWP_INVALID_NET_MASK";
                case unchecked((NtStatusCodes)0xC0220020): return "STATUS_FWP_INVALID_RANGE";
                case unchecked((NtStatusCodes)0xC0220021): return "STATUS_FWP_INVALID_INTERVAL";
                case unchecked((NtStatusCodes)0xC0220022): return "STATUS_FWP_ZERO_LENGTH_ARRAY";
                case unchecked((NtStatusCodes)0xC0220023): return "STATUS_FWP_NULL_DISPLAY_NAME";
                case unchecked((NtStatusCodes)0xC0220024): return "STATUS_FWP_INVALID_ACTION_TYPE";
                case unchecked((NtStatusCodes)0xC0220025): return "STATUS_FWP_INVALID_WEIGHT";
                case unchecked((NtStatusCodes)0xC0220026): return "STATUS_FWP_MATCH_TYPE_MISMATCH";
                case unchecked((NtStatusCodes)0xC0220027): return "STATUS_FWP_TYPE_MISMATCH";
                case unchecked((NtStatusCodes)0xC0220028): return "STATUS_FWP_OUT_OF_BOUNDS";
                case unchecked((NtStatusCodes)0xC0220029): return "STATUS_FWP_RESERVED";
                case unchecked((NtStatusCodes)0xC022002A): return "STATUS_FWP_DUPLICATE_CONDITION";
                case unchecked((NtStatusCodes)0xC022002B): return "STATUS_FWP_DUPLICATE_KEYMOD";
                case unchecked((NtStatusCodes)0xC022002C): return "STATUS_FWP_ACTION_INCOMPATIBLE_WITH_LAYER";
                case unchecked((NtStatusCodes)0xC022002D): return "STATUS_FWP_ACTION_INCOMPATIBLE_WITH_SUBLAYER";
                case unchecked((NtStatusCodes)0xC022002E): return "STATUS_FWP_CONTEXT_INCOMPATIBLE_WITH_LAYER";
                case unchecked((NtStatusCodes)0xC022002F): return "STATUS_FWP_CONTEXT_INCOMPATIBLE_WITH_CALLOUT";
                case unchecked((NtStatusCodes)0xC0220030): return "STATUS_FWP_INCOMPATIBLE_AUTH_METHOD";
                case unchecked((NtStatusCodes)0xC0220031): return "STATUS_FWP_INCOMPATIBLE_DH_GROUP";
                case unchecked((NtStatusCodes)0xC0220032): return "STATUS_FWP_EM_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0220033): return "STATUS_FWP_NEVER_MATCH";
                case unchecked((NtStatusCodes)0xC0220034): return "STATUS_FWP_PROVIDER_CONTEXT_MISMATCH";
                case unchecked((NtStatusCodes)0xC0220035): return "STATUS_FWP_INVALID_PARAMETER";
                case unchecked((NtStatusCodes)0xC0220036): return "STATUS_FWP_TOO_MANY_SUBLAYERS";
                case unchecked((NtStatusCodes)0xC0220037): return "STATUS_FWP_CALLOUT_NOTIFICATION_FAILED";
                case unchecked((NtStatusCodes)0xC0220038): return "STATUS_FWP_INVALID_AUTH_TRANSFORM";
                case unchecked((NtStatusCodes)0xC0220039): return "STATUS_FWP_INVALID_CIPHER_TRANSFORM";
                case unchecked((NtStatusCodes)0xC022003A): return "STATUS_FWP_INCOMPATIBLE_CIPHER_TRANSFORM";
                case unchecked((NtStatusCodes)0xC022003B): return "STATUS_FWP_INVALID_TRANSFORM_COMBINATION";
                case unchecked((NtStatusCodes)0xC022003C): return "STATUS_FWP_DUPLICATE_AUTH_METHOD";
                case unchecked((NtStatusCodes)0xC022003D): return "STATUS_FWP_INVALID_TUNNEL_ENDPOINT";
                case unchecked((NtStatusCodes)0xC022003E): return "STATUS_FWP_L2_DRIVER_NOT_READY";
                case unchecked((NtStatusCodes)0xC022003F): return "STATUS_FWP_KEY_DICTATOR_ALREADY_REGISTERED";
                case unchecked((NtStatusCodes)0xC0220040): return "STATUS_FWP_KEY_DICTATION_INVALID_KEYING_MATERIAL";
                case unchecked((NtStatusCodes)0xC0220041): return "STATUS_FWP_CONNECTIONS_DISABLED";
                case unchecked((NtStatusCodes)0xC0220042): return "STATUS_FWP_INVALID_DNS_NAME";
                case unchecked((NtStatusCodes)0xC0220043): return "STATUS_FWP_STILL_ON";
                case unchecked((NtStatusCodes)0xC0220044): return "STATUS_FWP_IKEEXT_NOT_RUNNING";
                case unchecked((NtStatusCodes)0xC0220100): return "STATUS_FWP_TCPIP_NOT_READY";
                case unchecked((NtStatusCodes)0xC0220101): return "STATUS_FWP_INJECT_HANDLE_CLOSING";
                case unchecked((NtStatusCodes)0xC0220102): return "STATUS_FWP_INJECT_HANDLE_STALE";
                case unchecked((NtStatusCodes)0xC0220103): return "STATUS_FWP_CANNOT_PEND";
                case unchecked((NtStatusCodes)0xC0220104): return "STATUS_FWP_DROP_NOICMP";
                case unchecked((NtStatusCodes)0xC0230002): return "STATUS_NDIS_CLOSING";
                case unchecked((NtStatusCodes)0xC0230004): return "STATUS_NDIS_BAD_VERSION";
                case unchecked((NtStatusCodes)0xC0230005): return "STATUS_NDIS_BAD_CHARACTERISTICS";
                case unchecked((NtStatusCodes)0xC0230006): return "STATUS_NDIS_ADAPTER_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0230007): return "STATUS_NDIS_OPEN_FAILED";
                case unchecked((NtStatusCodes)0xC0230008): return "STATUS_NDIS_DEVICE_FAILED";
                case unchecked((NtStatusCodes)0xC0230009): return "STATUS_NDIS_MULTICAST_FULL";
                case unchecked((NtStatusCodes)0xC023000A): return "STATUS_NDIS_MULTICAST_EXISTS";
                case unchecked((NtStatusCodes)0xC023000B): return "STATUS_NDIS_MULTICAST_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC023000C): return "STATUS_NDIS_REQUEST_ABORTED";
                case unchecked((NtStatusCodes)0xC023000D): return "STATUS_NDIS_RESET_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC02300BB): return "STATUS_NDIS_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC023000F): return "STATUS_NDIS_INVALID_PACKET";
                case unchecked((NtStatusCodes)0xC0230011): return "STATUS_NDIS_ADAPTER_NOT_READY";
                case unchecked((NtStatusCodes)0xC0230014): return "STATUS_NDIS_INVALID_LENGTH";
                case unchecked((NtStatusCodes)0xC0230015): return "STATUS_NDIS_INVALID_DATA";
                case unchecked((NtStatusCodes)0xC0230016): return "STATUS_NDIS_BUFFER_TOO_SHORT";
                case unchecked((NtStatusCodes)0xC0230017): return "STATUS_NDIS_INVALID_OID";
                case unchecked((NtStatusCodes)0xC0230018): return "STATUS_NDIS_ADAPTER_REMOVED";
                case unchecked((NtStatusCodes)0xC0230019): return "STATUS_NDIS_UNSUPPORTED_MEDIA";
                case unchecked((NtStatusCodes)0xC023001A): return "STATUS_NDIS_GROUP_ADDRESS_IN_USE";
                case unchecked((NtStatusCodes)0xC023001B): return "STATUS_NDIS_FILE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC023001C): return "STATUS_NDIS_ERROR_READING_FILE";
                case unchecked((NtStatusCodes)0xC023001D): return "STATUS_NDIS_ALREADY_MAPPED";
                case unchecked((NtStatusCodes)0xC023001E): return "STATUS_NDIS_RESOURCE_CONFLICT";
                case unchecked((NtStatusCodes)0xC023001F): return "STATUS_NDIS_MEDIA_DISCONNECTED";
                case unchecked((NtStatusCodes)0xC0230022): return "STATUS_NDIS_INVALID_ADDRESS";
                case unchecked((NtStatusCodes)0xC0230010): return "STATUS_NDIS_INVALID_DEVICE_REQUEST";
                case unchecked((NtStatusCodes)0xC023002A): return "STATUS_NDIS_PAUSED";
                case unchecked((NtStatusCodes)0xC023002B): return "STATUS_NDIS_INTERFACE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC023002C): return "STATUS_NDIS_UNSUPPORTED_REVISION";
                case unchecked((NtStatusCodes)0xC023002D): return "STATUS_NDIS_INVALID_PORT";
                case unchecked((NtStatusCodes)0xC023002E): return "STATUS_NDIS_INVALID_PORT_STATE";
                case unchecked((NtStatusCodes)0xC023002F): return "STATUS_NDIS_LOW_POWER_STATE";
                case unchecked((NtStatusCodes)0xC0230030): return "STATUS_NDIS_REINIT_REQUIRED";
                case unchecked((NtStatusCodes)0xC0230031): return "STATUS_NDIS_NO_QUEUES";
                case unchecked((NtStatusCodes)0xC0232000): return "STATUS_NDIS_DOT11_AUTO_CONFIG_ENABLED";
                case unchecked((NtStatusCodes)0xC0232001): return "STATUS_NDIS_DOT11_MEDIA_IN_USE";
                case unchecked((NtStatusCodes)0xC0232002): return "STATUS_NDIS_DOT11_POWER_STATE_INVALID";
                case unchecked((NtStatusCodes)0xC0232003): return "STATUS_NDIS_PM_WOL_PATTERN_LIST_FULL";
                case unchecked((NtStatusCodes)0xC0232004): return "STATUS_NDIS_PM_PROTOCOL_OFFLOAD_LIST_FULL";
                case unchecked((NtStatusCodes)0xC0232005): return "STATUS_NDIS_DOT11_AP_CHANNEL_CURRENTLY_NOT_AVAILABLE";
                case unchecked((NtStatusCodes)0xC0232006): return "STATUS_NDIS_DOT11_AP_BAND_CURRENTLY_NOT_AVAILABLE";
                case unchecked((NtStatusCodes)0xC0232007): return "STATUS_NDIS_DOT11_AP_CHANNEL_NOT_ALLOWED";
                case unchecked((NtStatusCodes)0xC0232008): return "STATUS_NDIS_DOT11_AP_BAND_NOT_ALLOWED";
                case unchecked((NtStatusCodes)0x40230001): return "STATUS_NDIS_INDICATION_REQUIRED";
                case unchecked((NtStatusCodes)0xC023100F): return "STATUS_NDIS_OFFLOAD_POLICY";
                case unchecked((NtStatusCodes)0xC0231012): return "STATUS_NDIS_OFFLOAD_CONNECTION_REJECTED";
                case unchecked((NtStatusCodes)0xC0231013): return "STATUS_NDIS_OFFLOAD_PATH_REJECTED";
                case unchecked((NtStatusCodes)0xC0290000): return "STATUS_TPM_ERROR_MASK";
                case unchecked((NtStatusCodes)0xC0290001): return "STATUS_TPM_AUTHFAIL";
                case unchecked((NtStatusCodes)0xC0290002): return "STATUS_TPM_BADINDEX";
                case unchecked((NtStatusCodes)0xC0290003): return "STATUS_TPM_BAD_PARAMETER";
                case unchecked((NtStatusCodes)0xC0290004): return "STATUS_TPM_AUDITFAILURE";
                case unchecked((NtStatusCodes)0xC0290005): return "STATUS_TPM_CLEAR_DISABLED";
                case unchecked((NtStatusCodes)0xC0290006): return "STATUS_TPM_DEACTIVATED";
                case unchecked((NtStatusCodes)0xC0290007): return "STATUS_TPM_DISABLED";
                case unchecked((NtStatusCodes)0xC0290008): return "STATUS_TPM_DISABLED_CMD";
                case unchecked((NtStatusCodes)0xC0290009): return "STATUS_TPM_FAIL";
                case unchecked((NtStatusCodes)0xC029000A): return "STATUS_TPM_BAD_ORDINAL";
                case unchecked((NtStatusCodes)0xC029000B): return "STATUS_TPM_INSTALL_DISABLED";
                case unchecked((NtStatusCodes)0xC029000C): return "STATUS_TPM_INVALID_KEYHANDLE";
                case unchecked((NtStatusCodes)0xC029000D): return "STATUS_TPM_KEYNOTFOUND";
                case unchecked((NtStatusCodes)0xC029000E): return "STATUS_TPM_INAPPROPRIATE_ENC";
                case unchecked((NtStatusCodes)0xC029000F): return "STATUS_TPM_MIGRATEFAIL";
                case unchecked((NtStatusCodes)0xC0290010): return "STATUS_TPM_INVALID_PCR_INFO";
                case unchecked((NtStatusCodes)0xC0290011): return "STATUS_TPM_NOSPACE";
                case unchecked((NtStatusCodes)0xC0290012): return "STATUS_TPM_NOSRK";
                case unchecked((NtStatusCodes)0xC0290013): return "STATUS_TPM_NOTSEALED_BLOB";
                case unchecked((NtStatusCodes)0xC0290014): return "STATUS_TPM_OWNER_SET";
                case unchecked((NtStatusCodes)0xC0290015): return "STATUS_TPM_RESOURCES";
                case unchecked((NtStatusCodes)0xC0290016): return "STATUS_TPM_SHORTRANDOM";
                case unchecked((NtStatusCodes)0xC0290017): return "STATUS_TPM_SIZE";
                case unchecked((NtStatusCodes)0xC0290018): return "STATUS_TPM_WRONGPCRVAL";
                case unchecked((NtStatusCodes)0xC0290019): return "STATUS_TPM_BAD_PARAM_SIZE";
                case unchecked((NtStatusCodes)0xC029001A): return "STATUS_TPM_SHA_THREAD";
                case unchecked((NtStatusCodes)0xC029001B): return "STATUS_TPM_SHA_ERROR";
                case unchecked((NtStatusCodes)0xC029001C): return "STATUS_TPM_FAILEDSELFTEST";
                case unchecked((NtStatusCodes)0xC029001D): return "STATUS_TPM_AUTH2FAIL";
                case unchecked((NtStatusCodes)0xC029001E): return "STATUS_TPM_BADTAG";
                case unchecked((NtStatusCodes)0xC029001F): return "STATUS_TPM_IOERROR";
                case unchecked((NtStatusCodes)0xC0290020): return "STATUS_TPM_ENCRYPT_ERROR";
                case unchecked((NtStatusCodes)0xC0290021): return "STATUS_TPM_DECRYPT_ERROR";
                case unchecked((NtStatusCodes)0xC0290022): return "STATUS_TPM_INVALID_AUTHHANDLE";
                case unchecked((NtStatusCodes)0xC0290023): return "STATUS_TPM_NO_ENDORSEMENT";
                case unchecked((NtStatusCodes)0xC0290024): return "STATUS_TPM_INVALID_KEYUSAGE";
                case unchecked((NtStatusCodes)0xC0290025): return "STATUS_TPM_WRONG_ENTITYTYPE";
                case unchecked((NtStatusCodes)0xC0290026): return "STATUS_TPM_INVALID_POSTINIT";
                case unchecked((NtStatusCodes)0xC0290027): return "STATUS_TPM_INAPPROPRIATE_SIG";
                case unchecked((NtStatusCodes)0xC0290028): return "STATUS_TPM_BAD_KEY_PROPERTY";
                case unchecked((NtStatusCodes)0xC0290029): return "STATUS_TPM_BAD_MIGRATION";
                case unchecked((NtStatusCodes)0xC029002A): return "STATUS_TPM_BAD_SCHEME";
                case unchecked((NtStatusCodes)0xC029002B): return "STATUS_TPM_BAD_DATASIZE";
                case unchecked((NtStatusCodes)0xC029002C): return "STATUS_TPM_BAD_MODE";
                case unchecked((NtStatusCodes)0xC029002D): return "STATUS_TPM_BAD_PRESENCE";
                case unchecked((NtStatusCodes)0xC029002E): return "STATUS_TPM_BAD_VERSION";
                case unchecked((NtStatusCodes)0xC029002F): return "STATUS_TPM_NO_WRAP_TRANSPORT";
                case unchecked((NtStatusCodes)0xC0290030): return "STATUS_TPM_AUDITFAIL_UNSUCCESSFUL";
                case unchecked((NtStatusCodes)0xC0290031): return "STATUS_TPM_AUDITFAIL_SUCCESSFUL";
                case unchecked((NtStatusCodes)0xC0290032): return "STATUS_TPM_NOTRESETABLE";
                case unchecked((NtStatusCodes)0xC0290033): return "STATUS_TPM_NOTLOCAL";
                case unchecked((NtStatusCodes)0xC0290034): return "STATUS_TPM_BAD_TYPE";
                case unchecked((NtStatusCodes)0xC0290035): return "STATUS_TPM_INVALID_RESOURCE";
                case unchecked((NtStatusCodes)0xC0290036): return "STATUS_TPM_NOTFIPS";
                case unchecked((NtStatusCodes)0xC0290037): return "STATUS_TPM_INVALID_FAMILY";
                case unchecked((NtStatusCodes)0xC0290038): return "STATUS_TPM_NO_NV_PERMISSION";
                case unchecked((NtStatusCodes)0xC0290039): return "STATUS_TPM_REQUIRES_SIGN";
                case unchecked((NtStatusCodes)0xC029003A): return "STATUS_TPM_KEY_NOTSUPPORTED";
                case unchecked((NtStatusCodes)0xC029003B): return "STATUS_TPM_AUTH_CONFLICT";
                case unchecked((NtStatusCodes)0xC029003C): return "STATUS_TPM_AREA_LOCKED";
                case unchecked((NtStatusCodes)0xC029003D): return "STATUS_TPM_BAD_LOCALITY";
                case unchecked((NtStatusCodes)0xC029003E): return "STATUS_TPM_READ_ONLY";
                case unchecked((NtStatusCodes)0xC029003F): return "STATUS_TPM_PER_NOWRITE";
                case unchecked((NtStatusCodes)0xC0290040): return "STATUS_TPM_FAMILYCOUNT";
                case unchecked((NtStatusCodes)0xC0290041): return "STATUS_TPM_WRITE_LOCKED";
                case unchecked((NtStatusCodes)0xC0290042): return "STATUS_TPM_BAD_ATTRIBUTES";
                case unchecked((NtStatusCodes)0xC0290043): return "STATUS_TPM_INVALID_STRUCTURE";
                case unchecked((NtStatusCodes)0xC0290044): return "STATUS_TPM_KEY_OWNER_CONTROL";
                case unchecked((NtStatusCodes)0xC0290045): return "STATUS_TPM_BAD_COUNTER";
                case unchecked((NtStatusCodes)0xC0290046): return "STATUS_TPM_NOT_FULLWRITE";
                case unchecked((NtStatusCodes)0xC0290047): return "STATUS_TPM_CONTEXT_GAP";
                case unchecked((NtStatusCodes)0xC0290048): return "STATUS_TPM_MAXNVWRITES";
                case unchecked((NtStatusCodes)0xC0290049): return "STATUS_TPM_NOOPERATOR";
                case unchecked((NtStatusCodes)0xC029004A): return "STATUS_TPM_RESOURCEMISSING";
                case unchecked((NtStatusCodes)0xC029004B): return "STATUS_TPM_DELEGATE_LOCK";
                case unchecked((NtStatusCodes)0xC029004C): return "STATUS_TPM_DELEGATE_FAMILY";
                case unchecked((NtStatusCodes)0xC029004D): return "STATUS_TPM_DELEGATE_ADMIN";
                case unchecked((NtStatusCodes)0xC029004E): return "STATUS_TPM_TRANSPORT_NOTEXCLUSIVE";
                case unchecked((NtStatusCodes)0xC029004F): return "STATUS_TPM_OWNER_CONTROL";
                case unchecked((NtStatusCodes)0xC0290050): return "STATUS_TPM_DAA_RESOURCES";
                case unchecked((NtStatusCodes)0xC0290051): return "STATUS_TPM_DAA_INPUT_DATA0";
                case unchecked((NtStatusCodes)0xC0290052): return "STATUS_TPM_DAA_INPUT_DATA1";
                case unchecked((NtStatusCodes)0xC0290053): return "STATUS_TPM_DAA_ISSUER_SETTINGS";
                case unchecked((NtStatusCodes)0xC0290054): return "STATUS_TPM_DAA_TPM_SETTINGS";
                case unchecked((NtStatusCodes)0xC0290055): return "STATUS_TPM_DAA_STAGE";
                case unchecked((NtStatusCodes)0xC0290056): return "STATUS_TPM_DAA_ISSUER_VALIDITY";
                case unchecked((NtStatusCodes)0xC0290057): return "STATUS_TPM_DAA_WRONG_W";
                case unchecked((NtStatusCodes)0xC0290058): return "STATUS_TPM_BAD_HANDLE";
                case unchecked((NtStatusCodes)0xC0290059): return "STATUS_TPM_BAD_DELEGATE";
                case unchecked((NtStatusCodes)0xC029005A): return "STATUS_TPM_BADCONTEXT";
                case unchecked((NtStatusCodes)0xC029005B): return "STATUS_TPM_TOOMANYCONTEXTS";
                case unchecked((NtStatusCodes)0xC029005C): return "STATUS_TPM_MA_TICKET_SIGNATURE";
                case unchecked((NtStatusCodes)0xC029005D): return "STATUS_TPM_MA_DESTINATION";
                case unchecked((NtStatusCodes)0xC029005E): return "STATUS_TPM_MA_SOURCE";
                case unchecked((NtStatusCodes)0xC029005F): return "STATUS_TPM_MA_AUTHORITY";
                case unchecked((NtStatusCodes)0xC0290061): return "STATUS_TPM_PERMANENTEK";
                case unchecked((NtStatusCodes)0xC0290062): return "STATUS_TPM_BAD_SIGNATURE";
                case unchecked((NtStatusCodes)0xC0290063): return "STATUS_TPM_NOCONTEXTSPACE";
                case unchecked((NtStatusCodes)0xC0290081): return "STATUS_TPM_20_E_ASYMMETRIC";
                case unchecked((NtStatusCodes)0xC0290082): return "STATUS_TPM_20_E_ATTRIBUTES";
                case unchecked((NtStatusCodes)0xC0290083): return "STATUS_TPM_20_E_HASH";
                case unchecked((NtStatusCodes)0xC0290084): return "STATUS_TPM_20_E_VALUE";
                case unchecked((NtStatusCodes)0xC0290085): return "STATUS_TPM_20_E_HIERARCHY";
                case unchecked((NtStatusCodes)0xC0290087): return "STATUS_TPM_20_E_KEY_SIZE";
                case unchecked((NtStatusCodes)0xC0290088): return "STATUS_TPM_20_E_MGF";
                case unchecked((NtStatusCodes)0xC0290089): return "STATUS_TPM_20_E_MODE";
                case unchecked((NtStatusCodes)0xC029008A): return "STATUS_TPM_20_E_TYPE";
                case unchecked((NtStatusCodes)0xC029008B): return "STATUS_TPM_20_E_HANDLE";
                case unchecked((NtStatusCodes)0xC029008C): return "STATUS_TPM_20_E_KDF";
                case unchecked((NtStatusCodes)0xC029008D): return "STATUS_TPM_20_E_RANGE";
                case unchecked((NtStatusCodes)0xC029008E): return "STATUS_TPM_20_E_AUTH_FAIL";
                case unchecked((NtStatusCodes)0xC029008F): return "STATUS_TPM_20_E_NONCE";
                case unchecked((NtStatusCodes)0xC0290090): return "STATUS_TPM_20_E_PP";
                case unchecked((NtStatusCodes)0xC0290092): return "STATUS_TPM_20_E_SCHEME";
                case unchecked((NtStatusCodes)0xC0290095): return "STATUS_TPM_20_E_SIZE";
                case unchecked((NtStatusCodes)0xC0290096): return "STATUS_TPM_20_E_SYMMETRIC";
                case unchecked((NtStatusCodes)0xC0290097): return "STATUS_TPM_20_E_TAG";
                case unchecked((NtStatusCodes)0xC0290098): return "STATUS_TPM_20_E_SELECTOR";
                case unchecked((NtStatusCodes)0xC029009A): return "STATUS_TPM_20_E_INSUFFICIENT";
                case unchecked((NtStatusCodes)0xC029009B): return "STATUS_TPM_20_E_SIGNATURE";
                case unchecked((NtStatusCodes)0xC029009C): return "STATUS_TPM_20_E_KEY";
                case unchecked((NtStatusCodes)0xC029009D): return "STATUS_TPM_20_E_POLICY_FAIL";
                case unchecked((NtStatusCodes)0xC029009F): return "STATUS_TPM_20_E_INTEGRITY";
                case unchecked((NtStatusCodes)0xC02900A0): return "STATUS_TPM_20_E_TICKET";
                case unchecked((NtStatusCodes)0xC02900A1): return "STATUS_TPM_20_E_RESERVED_BITS";
                case unchecked((NtStatusCodes)0xC02900A2): return "STATUS_TPM_20_E_BAD_AUTH";
                case unchecked((NtStatusCodes)0xC02900A3): return "STATUS_TPM_20_E_EXPIRED";
                case unchecked((NtStatusCodes)0xC02900A4): return "STATUS_TPM_20_E_POLICY_CC";
                case unchecked((NtStatusCodes)0xC02900A5): return "STATUS_TPM_20_E_BINDING";
                case unchecked((NtStatusCodes)0xC02900A6): return "STATUS_TPM_20_E_CURVE";
                case unchecked((NtStatusCodes)0xC02900A7): return "STATUS_TPM_20_E_ECC_POINT";
                case unchecked((NtStatusCodes)0xC0290100): return "STATUS_TPM_20_E_INITIALIZE";
                case unchecked((NtStatusCodes)0xC0290101): return "STATUS_TPM_20_E_FAILURE";
                case unchecked((NtStatusCodes)0xC0290103): return "STATUS_TPM_20_E_SEQUENCE";
                case unchecked((NtStatusCodes)0xC029010B): return "STATUS_TPM_20_E_PRIVATE";
                case unchecked((NtStatusCodes)0xC0290119): return "STATUS_TPM_20_E_HMAC";
                case unchecked((NtStatusCodes)0xC0290120): return "STATUS_TPM_20_E_DISABLED";
                case unchecked((NtStatusCodes)0xC0290121): return "STATUS_TPM_20_E_EXCLUSIVE";
                case unchecked((NtStatusCodes)0xC0290123): return "STATUS_TPM_20_E_ECC_CURVE";
                case unchecked((NtStatusCodes)0xC0290124): return "STATUS_TPM_20_E_AUTH_TYPE";
                case unchecked((NtStatusCodes)0xC0290125): return "STATUS_TPM_20_E_AUTH_MISSING";
                case unchecked((NtStatusCodes)0xC0290126): return "STATUS_TPM_20_E_POLICY";
                case unchecked((NtStatusCodes)0xC0290127): return "STATUS_TPM_20_E_PCR";
                case unchecked((NtStatusCodes)0xC0290128): return "STATUS_TPM_20_E_PCR_CHANGED";
                case unchecked((NtStatusCodes)0xC029012D): return "STATUS_TPM_20_E_UPGRADE";
                case unchecked((NtStatusCodes)0xC029012E): return "STATUS_TPM_20_E_TOO_MANY_CONTEXTS";
                case unchecked((NtStatusCodes)0xC029012F): return "STATUS_TPM_20_E_AUTH_UNAVAILABLE";
                case unchecked((NtStatusCodes)0xC0290130): return "STATUS_TPM_20_E_REBOOT";
                case unchecked((NtStatusCodes)0xC0290131): return "STATUS_TPM_20_E_UNBALANCED";
                case unchecked((NtStatusCodes)0xC0290142): return "STATUS_TPM_20_E_COMMAND_SIZE";
                case unchecked((NtStatusCodes)0xC0290143): return "STATUS_TPM_20_E_COMMAND_CODE";
                case unchecked((NtStatusCodes)0xC0290144): return "STATUS_TPM_20_E_AUTHSIZE";
                case unchecked((NtStatusCodes)0xC0290145): return "STATUS_TPM_20_E_AUTH_CONTEXT";
                case unchecked((NtStatusCodes)0xC0290146): return "STATUS_TPM_20_E_NV_RANGE";
                case unchecked((NtStatusCodes)0xC0290147): return "STATUS_TPM_20_E_NV_SIZE";
                case unchecked((NtStatusCodes)0xC0290148): return "STATUS_TPM_20_E_NV_LOCKED";
                case unchecked((NtStatusCodes)0xC0290149): return "STATUS_TPM_20_E_NV_AUTHORIZATION";
                case unchecked((NtStatusCodes)0xC029014A): return "STATUS_TPM_20_E_NV_UNINITIALIZED";
                case unchecked((NtStatusCodes)0xC029014B): return "STATUS_TPM_20_E_NV_SPACE";
                case unchecked((NtStatusCodes)0xC029014C): return "STATUS_TPM_20_E_NV_DEFINED";
                case unchecked((NtStatusCodes)0xC0290150): return "STATUS_TPM_20_E_BAD_CONTEXT";
                case unchecked((NtStatusCodes)0xC0290151): return "STATUS_TPM_20_E_CPHASH";
                case unchecked((NtStatusCodes)0xC0290152): return "STATUS_TPM_20_E_PARENT";
                case unchecked((NtStatusCodes)0xC0290153): return "STATUS_TPM_20_E_NEEDS_TEST";
                case unchecked((NtStatusCodes)0xC0290154): return "STATUS_TPM_20_E_NO_RESULT";
                case unchecked((NtStatusCodes)0xC0290155): return "STATUS_TPM_20_E_SENSITIVE";
                case unchecked((NtStatusCodes)0xC0290400): return "STATUS_TPM_COMMAND_BLOCKED";
                case unchecked((NtStatusCodes)0xC0290401): return "STATUS_TPM_INVALID_HANDLE";
                case unchecked((NtStatusCodes)0xC0290402): return "STATUS_TPM_DUPLICATE_VHANDLE";
                case unchecked((NtStatusCodes)0xC0290403): return "STATUS_TPM_EMBEDDED_COMMAND_BLOCKED";
                case unchecked((NtStatusCodes)0xC0290404): return "STATUS_TPM_EMBEDDED_COMMAND_UNSUPPORTED";
                case unchecked((NtStatusCodes)0xC0290800): return "STATUS_TPM_RETRY";
                case unchecked((NtStatusCodes)0xC0290801): return "STATUS_TPM_NEEDS_SELFTEST";
                case unchecked((NtStatusCodes)0xC0290802): return "STATUS_TPM_DOING_SELFTEST";
                case unchecked((NtStatusCodes)0xC0290803): return "STATUS_TPM_DEFEND_LOCK_RUNNING";
                case unchecked((NtStatusCodes)0xC0291001): return "STATUS_TPM_COMMAND_CANCELED";
                case unchecked((NtStatusCodes)0xC0291002): return "STATUS_TPM_TOO_MANY_CONTEXTS";
                case unchecked((NtStatusCodes)0xC0291003): return "STATUS_TPM_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0291004): return "STATUS_TPM_ACCESS_DENIED";
                case unchecked((NtStatusCodes)0xC0291005): return "STATUS_TPM_INSUFFICIENT_BUFFER";
                case unchecked((NtStatusCodes)0xC0291006): return "STATUS_TPM_PPI_FUNCTION_UNSUPPORTED";
                case unchecked((NtStatusCodes)0xC0292000): return "STATUS_PCP_ERROR_MASK";
                case unchecked((NtStatusCodes)0xC0292001): return "STATUS_PCP_DEVICE_NOT_READY";
                case unchecked((NtStatusCodes)0xC0292002): return "STATUS_PCP_INVALID_HANDLE";
                case unchecked((NtStatusCodes)0xC0292003): return "STATUS_PCP_INVALID_PARAMETER";
                case unchecked((NtStatusCodes)0xC0292004): return "STATUS_PCP_FLAG_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0292005): return "STATUS_PCP_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0292006): return "STATUS_PCP_BUFFER_TOO_SMALL";
                case unchecked((NtStatusCodes)0xC0292007): return "STATUS_PCP_INTERNAL_ERROR";
                case unchecked((NtStatusCodes)0xC0292008): return "STATUS_PCP_AUTHENTICATION_FAILED";
                case unchecked((NtStatusCodes)0xC0292009): return "STATUS_PCP_AUTHENTICATION_IGNORED";
                case unchecked((NtStatusCodes)0xC029200A): return "STATUS_PCP_POLICY_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC029200B): return "STATUS_PCP_PROFILE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC029200C): return "STATUS_PCP_VALIDATION_FAILED";
                case unchecked((NtStatusCodes)0xC029200D): return "STATUS_PCP_DEVICE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC029200E): return "STATUS_PCP_WRONG_PARENT";
                case unchecked((NtStatusCodes)0xC029200F): return "STATUS_PCP_KEY_NOT_LOADED";
                case unchecked((NtStatusCodes)0xC0292010): return "STATUS_PCP_NO_KEY_CERTIFICATION";
                case unchecked((NtStatusCodes)0xC0292011): return "STATUS_PCP_KEY_NOT_FINALIZED";
                case unchecked((NtStatusCodes)0xC0292012): return "STATUS_PCP_ATTESTATION_CHALLENGE_NOT_SET";
                case unchecked((NtStatusCodes)0xC0292013): return "STATUS_PCP_NOT_PCR_BOUND";
                case unchecked((NtStatusCodes)0xC0292014): return "STATUS_PCP_KEY_ALREADY_FINALIZED";
                case unchecked((NtStatusCodes)0xC0292015): return "STATUS_PCP_KEY_USAGE_POLICY_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0292016): return "STATUS_PCP_KEY_USAGE_POLICY_INVALID";
                case unchecked((NtStatusCodes)0xC0292017): return "STATUS_PCP_SOFT_KEY_ERROR";
                case unchecked((NtStatusCodes)0xC0292018): return "STATUS_PCP_KEY_NOT_AUTHENTICATED";
                case unchecked((NtStatusCodes)0xC0292019): return "STATUS_PCP_KEY_NOT_AIK";
                case unchecked((NtStatusCodes)0xC029201A): return "STATUS_PCP_KEY_NOT_SIGNING_KEY";
                case unchecked((NtStatusCodes)0xC029201B): return "STATUS_PCP_LOCKED_OUT";
                case unchecked((NtStatusCodes)0xC029201C): return "STATUS_PCP_CLAIM_TYPE_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC029201D): return "STATUS_PCP_TPM_VERSION_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC029201E): return "STATUS_PCP_BUFFER_LENGTH_MISMATCH";
                case unchecked((NtStatusCodes)0xC029201F): return "STATUS_PCP_IFX_RSA_KEY_CREATION_BLOCKED";
                case unchecked((NtStatusCodes)0xC0292020): return "STATUS_PCP_TICKET_MISSING";
                case unchecked((NtStatusCodes)0xC0292021): return "STATUS_PCP_RAW_POLICY_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0292022): return "STATUS_PCP_KEY_HANDLE_INVALIDATED";
                case unchecked((NtStatusCodes)0x40292023): return "STATUS_PCP_UNSUPPORTED_PSS_SALT";
                case unchecked((NtStatusCodes)0x00293000): return "STATUS_RTPM_CONTEXT_CONTINUE";
                case unchecked((NtStatusCodes)0x00293001): return "STATUS_RTPM_CONTEXT_COMPLETE";
                case unchecked((NtStatusCodes)0xC0293002): return "STATUS_RTPM_NO_RESULT";
                case unchecked((NtStatusCodes)0xC0293003): return "STATUS_RTPM_PCR_READ_INCOMPLETE";
                case unchecked((NtStatusCodes)0xC0293004): return "STATUS_RTPM_INVALID_CONTEXT";
                case unchecked((NtStatusCodes)0xC0293005): return "STATUS_RTPM_UNSUPPORTED_CMD";
                case unchecked((NtStatusCodes)0xC0294000): return "STATUS_TPM_ZERO_EXHAUST_ENABLED";
                case unchecked((NtStatusCodes)0xC0350002): return "STATUS_HV_INVALID_HYPERCALL_CODE";
                case unchecked((NtStatusCodes)0xC0350003): return "STATUS_HV_INVALID_HYPERCALL_INPUT";
                case unchecked((NtStatusCodes)0xC0350004): return "STATUS_HV_INVALID_ALIGNMENT";
                case unchecked((NtStatusCodes)0xC0350005): return "STATUS_HV_INVALID_PARAMETER";
                case unchecked((NtStatusCodes)0xC0350006): return "STATUS_HV_ACCESS_DENIED";
                case unchecked((NtStatusCodes)0xC0350007): return "STATUS_HV_INVALID_PARTITION_STATE";
                case unchecked((NtStatusCodes)0xC0350008): return "STATUS_HV_OPERATION_DENIED";
                case unchecked((NtStatusCodes)0xC0350009): return "STATUS_HV_UNKNOWN_PROPERTY";
                case unchecked((NtStatusCodes)0xC035000A): return "STATUS_HV_PROPERTY_VALUE_OUT_OF_RANGE";
                case unchecked((NtStatusCodes)0xC035000B): return "STATUS_HV_INSUFFICIENT_MEMORY";
                case unchecked((NtStatusCodes)0xC035000C): return "STATUS_HV_PARTITION_TOO_DEEP";
                case unchecked((NtStatusCodes)0xC035000D): return "STATUS_HV_INVALID_PARTITION_ID";
                case unchecked((NtStatusCodes)0xC035000E): return "STATUS_HV_INVALID_VP_INDEX";
                case unchecked((NtStatusCodes)0xC0350011): return "STATUS_HV_INVALID_PORT_ID";
                case unchecked((NtStatusCodes)0xC0350012): return "STATUS_HV_INVALID_CONNECTION_ID";
                case unchecked((NtStatusCodes)0xC0350013): return "STATUS_HV_INSUFFICIENT_BUFFERS";
                case unchecked((NtStatusCodes)0xC0350014): return "STATUS_HV_NOT_ACKNOWLEDGED";
                case unchecked((NtStatusCodes)0xC0350015): return "STATUS_HV_INVALID_VP_STATE";
                case unchecked((NtStatusCodes)0xC0350016): return "STATUS_HV_ACKNOWLEDGED";
                case unchecked((NtStatusCodes)0xC0350017): return "STATUS_HV_INVALID_SAVE_RESTORE_STATE";
                case unchecked((NtStatusCodes)0xC0350018): return "STATUS_HV_INVALID_SYNIC_STATE";
                case unchecked((NtStatusCodes)0xC0350019): return "STATUS_HV_OBJECT_IN_USE";
                case unchecked((NtStatusCodes)0xC035001A): return "STATUS_HV_INVALID_PROXIMITY_DOMAIN_INFO";
                case unchecked((NtStatusCodes)0xC035001B): return "STATUS_HV_NO_DATA";
                case unchecked((NtStatusCodes)0xC035001C): return "STATUS_HV_INACTIVE";
                case unchecked((NtStatusCodes)0xC035001D): return "STATUS_HV_NO_RESOURCES";
                case unchecked((NtStatusCodes)0xC035001E): return "STATUS_HV_FEATURE_UNAVAILABLE";
                case unchecked((NtStatusCodes)0xC0350033): return "STATUS_HV_INSUFFICIENT_BUFFER";
                case unchecked((NtStatusCodes)0xC0350038): return "STATUS_HV_INSUFFICIENT_DEVICE_DOMAINS";
                case unchecked((NtStatusCodes)0xC035003C): return "STATUS_HV_CPUID_FEATURE_VALIDATION_ERROR";
                case unchecked((NtStatusCodes)0xC035003D): return "STATUS_HV_CPUID_XSAVE_FEATURE_VALIDATION_ERROR";
                case unchecked((NtStatusCodes)0xC035003E): return "STATUS_HV_PROCESSOR_STARTUP_TIMEOUT";
                case unchecked((NtStatusCodes)0xC035003F): return "STATUS_HV_SMX_ENABLED";
                case unchecked((NtStatusCodes)0xC0350041): return "STATUS_HV_INVALID_LP_INDEX";
                case unchecked((NtStatusCodes)0xC0350050): return "STATUS_HV_INVALID_REGISTER_VALUE";
                case unchecked((NtStatusCodes)0xC0350051): return "STATUS_HV_INVALID_VTL_STATE";
                case unchecked((NtStatusCodes)0xC0350055): return "STATUS_HV_NX_NOT_DETECTED";
                case unchecked((NtStatusCodes)0xC0350057): return "STATUS_HV_INVALID_DEVICE_ID";
                case unchecked((NtStatusCodes)0xC0350058): return "STATUS_HV_INVALID_DEVICE_STATE";
                case unchecked((NtStatusCodes)0x00350059): return "STATUS_HV_PENDING_PAGE_REQUESTS";
                case unchecked((NtStatusCodes)0xC0350060): return "STATUS_HV_PAGE_REQUEST_INVALID";
                case unchecked((NtStatusCodes)0xC035006F): return "STATUS_HV_INVALID_CPU_GROUP_ID";
                case unchecked((NtStatusCodes)0xC0350070): return "STATUS_HV_INVALID_CPU_GROUP_STATE";
                case unchecked((NtStatusCodes)0xC0350071): return "STATUS_HV_OPERATION_FAILED";
                case unchecked((NtStatusCodes)0xC0350072): return "STATUS_HV_NOT_ALLOWED_WITH_NESTED_VIRT_ACTIVE";
                case unchecked((NtStatusCodes)0xC0350073): return "STATUS_HV_INSUFFICIENT_ROOT_MEMORY";
                case unchecked((NtStatusCodes)0xC0350074): return "STATUS_HV_EVENT_BUFFER_ALREADY_FREED";
                case unchecked((NtStatusCodes)0xC0350075): return "STATUS_HV_INSUFFICIENT_CONTIGUOUS_MEMORY";
                case unchecked((NtStatusCodes)0xC0350076): return "STATUS_HV_DEVICE_NOT_IN_DOMAIN";
                case unchecked((NtStatusCodes)0xC0350077): return "STATUS_HV_NESTED_VM_EXIT";
                case unchecked((NtStatusCodes)0xC0350079): return "STATUS_HV_CALL_PENDING";
                case unchecked((NtStatusCodes)0xC0350080): return "STATUS_HV_MSR_ACCESS_FAILED";
                case unchecked((NtStatusCodes)0xC0351000): return "STATUS_HV_NOT_PRESENT";
                case unchecked((NtStatusCodes)0xC0370001): return "STATUS_VID_DUPLICATE_HANDLER";
                case unchecked((NtStatusCodes)0xC0370002): return "STATUS_VID_TOO_MANY_HANDLERS";
                case unchecked((NtStatusCodes)0xC0370003): return "STATUS_VID_QUEUE_FULL";
                case unchecked((NtStatusCodes)0xC0370004): return "STATUS_VID_HANDLER_NOT_PRESENT";
                case unchecked((NtStatusCodes)0xC0370005): return "STATUS_VID_INVALID_OBJECT_NAME";
                case unchecked((NtStatusCodes)0xC0370006): return "STATUS_VID_PARTITION_NAME_TOO_LONG";
                case unchecked((NtStatusCodes)0xC0370007): return "STATUS_VID_MESSAGE_QUEUE_NAME_TOO_LONG";
                case unchecked((NtStatusCodes)0xC0370008): return "STATUS_VID_PARTITION_ALREADY_EXISTS";
                case unchecked((NtStatusCodes)0xC0370009): return "STATUS_VID_PARTITION_DOES_NOT_EXIST";
                case unchecked((NtStatusCodes)0xC037000A): return "STATUS_VID_PARTITION_NAME_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC037000B): return "STATUS_VID_MESSAGE_QUEUE_ALREADY_EXISTS";
                case unchecked((NtStatusCodes)0xC037000C): return "STATUS_VID_EXCEEDED_MBP_ENTRY_MAP_LIMIT";
                case unchecked((NtStatusCodes)0xC037000D): return "STATUS_VID_MB_STILL_REFERENCED";
                case unchecked((NtStatusCodes)0xC037000E): return "STATUS_VID_CHILD_GPA_PAGE_SET_CORRUPTED";
                case unchecked((NtStatusCodes)0xC037000F): return "STATUS_VID_INVALID_NUMA_SETTINGS";
                case unchecked((NtStatusCodes)0xC0370010): return "STATUS_VID_INVALID_NUMA_NODE_INDEX";
                case unchecked((NtStatusCodes)0xC0370011): return "STATUS_VID_NOTIFICATION_QUEUE_ALREADY_ASSOCIATED";
                case unchecked((NtStatusCodes)0xC0370012): return "STATUS_VID_INVALID_MEMORY_BLOCK_HANDLE";
                case unchecked((NtStatusCodes)0xC0370013): return "STATUS_VID_PAGE_RANGE_OVERFLOW";
                case unchecked((NtStatusCodes)0xC0370014): return "STATUS_VID_INVALID_MESSAGE_QUEUE_HANDLE";
                case unchecked((NtStatusCodes)0xC0370015): return "STATUS_VID_INVALID_GPA_RANGE_HANDLE";
                case unchecked((NtStatusCodes)0xC0370016): return "STATUS_VID_NO_MEMORY_BLOCK_NOTIFICATION_QUEUE";
                case unchecked((NtStatusCodes)0xC0370017): return "STATUS_VID_MEMORY_BLOCK_LOCK_COUNT_EXCEEDED";
                case unchecked((NtStatusCodes)0xC0370018): return "STATUS_VID_INVALID_PPM_HANDLE";
                case unchecked((NtStatusCodes)0xC0370019): return "STATUS_VID_MBPS_ARE_LOCKED";
                case unchecked((NtStatusCodes)0xC037001A): return "STATUS_VID_MESSAGE_QUEUE_CLOSED";
                case unchecked((NtStatusCodes)0xC037001B): return "STATUS_VID_VIRTUAL_PROCESSOR_LIMIT_EXCEEDED";
                case unchecked((NtStatusCodes)0xC037001C): return "STATUS_VID_STOP_PENDING";
                case unchecked((NtStatusCodes)0xC037001D): return "STATUS_VID_INVALID_PROCESSOR_STATE";
                case unchecked((NtStatusCodes)0xC037001E): return "STATUS_VID_EXCEEDED_KM_CONTEXT_COUNT_LIMIT";
                case unchecked((NtStatusCodes)0xC037001F): return "STATUS_VID_KM_INTERFACE_ALREADY_INITIALIZED";
                case unchecked((NtStatusCodes)0xC0370020): return "STATUS_VID_MB_PROPERTY_ALREADY_SET_RESET";
                case unchecked((NtStatusCodes)0xC0370021): return "STATUS_VID_MMIO_RANGE_DESTROYED";
                case unchecked((NtStatusCodes)0xC0370022): return "STATUS_VID_INVALID_CHILD_GPA_PAGE_SET";
                case unchecked((NtStatusCodes)0xC0370023): return "STATUS_VID_RESERVE_PAGE_SET_IS_BEING_USED";
                case unchecked((NtStatusCodes)0xC0370024): return "STATUS_VID_RESERVE_PAGE_SET_TOO_SMALL";
                case unchecked((NtStatusCodes)0xC0370025): return "STATUS_VID_MBP_ALREADY_LOCKED_USING_RESERVED_PAGE";
                case unchecked((NtStatusCodes)0xC0370026): return "STATUS_VID_MBP_COUNT_EXCEEDED_LIMIT";
                case unchecked((NtStatusCodes)0xC0370027): return "STATUS_VID_SAVED_STATE_CORRUPT";
                case unchecked((NtStatusCodes)0xC0370028): return "STATUS_VID_SAVED_STATE_UNRECOGNIZED_ITEM";
                case unchecked((NtStatusCodes)0xC0370029): return "STATUS_VID_SAVED_STATE_INCOMPATIBLE";
                case unchecked((NtStatusCodes)0xC037002A): return "STATUS_VID_VTL_ACCESS_DENIED";
                case unchecked((NtStatusCodes)0x80370001): return "STATUS_VID_REMOTE_NODE_PARENT_GPA_PAGES_USED";
                case unchecked((NtStatusCodes)0xC0360001): return "STATUS_IPSEC_BAD_SPI";
                case unchecked((NtStatusCodes)0xC0360002): return "STATUS_IPSEC_SA_LIFETIME_EXPIRED";
                case unchecked((NtStatusCodes)0xC0360003): return "STATUS_IPSEC_WRONG_SA";
                case unchecked((NtStatusCodes)0xC0360004): return "STATUS_IPSEC_REPLAY_CHECK_FAILED";
                case unchecked((NtStatusCodes)0xC0360005): return "STATUS_IPSEC_INVALID_PACKET";
                case unchecked((NtStatusCodes)0xC0360006): return "STATUS_IPSEC_INTEGRITY_CHECK_FAILED";
                case unchecked((NtStatusCodes)0xC0360007): return "STATUS_IPSEC_CLEAR_TEXT_DROP";
                case unchecked((NtStatusCodes)0xC0360008): return "STATUS_IPSEC_AUTH_FIREWALL_DROP";
                case unchecked((NtStatusCodes)0xC0360009): return "STATUS_IPSEC_THROTTLE_DROP";
                case unchecked((NtStatusCodes)0xC0368000): return "STATUS_IPSEC_DOSP_BLOCK";
                case unchecked((NtStatusCodes)0xC0368001): return "STATUS_IPSEC_DOSP_RECEIVED_MULTICAST";
                case unchecked((NtStatusCodes)0xC0368002): return "STATUS_IPSEC_DOSP_INVALID_PACKET";
                case unchecked((NtStatusCodes)0xC0368003): return "STATUS_IPSEC_DOSP_STATE_LOOKUP_FAILED";
                case unchecked((NtStatusCodes)0xC0368004): return "STATUS_IPSEC_DOSP_MAX_ENTRIES";
                case unchecked((NtStatusCodes)0xC0368005): return "STATUS_IPSEC_DOSP_KEYMOD_NOT_ALLOWED";
                case unchecked((NtStatusCodes)0xC0368006): return "STATUS_IPSEC_DOSP_MAX_PER_IP_RATELIMIT_QUEUES";
                case unchecked((NtStatusCodes)0x80380001): return "STATUS_VOLMGR_INCOMPLETE_REGENERATION";
                case unchecked((NtStatusCodes)0x80380002): return "STATUS_VOLMGR_INCOMPLETE_DISK_MIGRATION";
                case unchecked((NtStatusCodes)0xC0380001): return "STATUS_VOLMGR_DATABASE_FULL";
                case unchecked((NtStatusCodes)0xC0380002): return "STATUS_VOLMGR_DISK_CONFIGURATION_CORRUPTED";
                case unchecked((NtStatusCodes)0xC0380003): return "STATUS_VOLMGR_DISK_CONFIGURATION_NOT_IN_SYNC";
                case unchecked((NtStatusCodes)0xC0380004): return "STATUS_VOLMGR_PACK_CONFIG_UPDATE_FAILED";
                case unchecked((NtStatusCodes)0xC0380005): return "STATUS_VOLMGR_DISK_CONTAINS_NON_SIMPLE_VOLUME";
                case unchecked((NtStatusCodes)0xC0380006): return "STATUS_VOLMGR_DISK_DUPLICATE";
                case unchecked((NtStatusCodes)0xC0380007): return "STATUS_VOLMGR_DISK_DYNAMIC";
                case unchecked((NtStatusCodes)0xC0380008): return "STATUS_VOLMGR_DISK_ID_INVALID";
                case unchecked((NtStatusCodes)0xC0380009): return "STATUS_VOLMGR_DISK_INVALID";
                case unchecked((NtStatusCodes)0xC038000A): return "STATUS_VOLMGR_DISK_LAST_VOTER";
                case unchecked((NtStatusCodes)0xC038000B): return "STATUS_VOLMGR_DISK_LAYOUT_INVALID";
                case unchecked((NtStatusCodes)0xC038000C): return "STATUS_VOLMGR_DISK_LAYOUT_NON_BASIC_BETWEEN_BASIC_PARTITIONS";
                case unchecked((NtStatusCodes)0xC038000D): return "STATUS_VOLMGR_DISK_LAYOUT_NOT_CYLINDER_ALIGNED";
                case unchecked((NtStatusCodes)0xC038000E): return "STATUS_VOLMGR_DISK_LAYOUT_PARTITIONS_TOO_SMALL";
                case unchecked((NtStatusCodes)0xC038000F): return "STATUS_VOLMGR_DISK_LAYOUT_PRIMARY_BETWEEN_LOGICAL_PARTITIONS";
                case unchecked((NtStatusCodes)0xC0380010): return "STATUS_VOLMGR_DISK_LAYOUT_TOO_MANY_PARTITIONS";
                case unchecked((NtStatusCodes)0xC0380011): return "STATUS_VOLMGR_DISK_MISSING";
                case unchecked((NtStatusCodes)0xC0380012): return "STATUS_VOLMGR_DISK_NOT_EMPTY";
                case unchecked((NtStatusCodes)0xC0380013): return "STATUS_VOLMGR_DISK_NOT_ENOUGH_SPACE";
                case unchecked((NtStatusCodes)0xC0380014): return "STATUS_VOLMGR_DISK_REVECTORING_FAILED";
                case unchecked((NtStatusCodes)0xC0380015): return "STATUS_VOLMGR_DISK_SECTOR_SIZE_INVALID";
                case unchecked((NtStatusCodes)0xC0380016): return "STATUS_VOLMGR_DISK_SET_NOT_CONTAINED";
                case unchecked((NtStatusCodes)0xC0380017): return "STATUS_VOLMGR_DISK_USED_BY_MULTIPLE_MEMBERS";
                case unchecked((NtStatusCodes)0xC0380018): return "STATUS_VOLMGR_DISK_USED_BY_MULTIPLE_PLEXES";
                case unchecked((NtStatusCodes)0xC0380019): return "STATUS_VOLMGR_DYNAMIC_DISK_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC038001A): return "STATUS_VOLMGR_EXTENT_ALREADY_USED";
                case unchecked((NtStatusCodes)0xC038001B): return "STATUS_VOLMGR_EXTENT_NOT_CONTIGUOUS";
                case unchecked((NtStatusCodes)0xC038001C): return "STATUS_VOLMGR_EXTENT_NOT_IN_PUBLIC_REGION";
                case unchecked((NtStatusCodes)0xC038001D): return "STATUS_VOLMGR_EXTENT_NOT_SECTOR_ALIGNED";
                case unchecked((NtStatusCodes)0xC038001E): return "STATUS_VOLMGR_EXTENT_OVERLAPS_EBR_PARTITION";
                case unchecked((NtStatusCodes)0xC038001F): return "STATUS_VOLMGR_EXTENT_VOLUME_LENGTHS_DO_NOT_MATCH";
                case unchecked((NtStatusCodes)0xC0380020): return "STATUS_VOLMGR_FAULT_TOLERANT_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0380021): return "STATUS_VOLMGR_INTERLEAVE_LENGTH_INVALID";
                case unchecked((NtStatusCodes)0xC0380022): return "STATUS_VOLMGR_MAXIMUM_REGISTERED_USERS";
                case unchecked((NtStatusCodes)0xC0380023): return "STATUS_VOLMGR_MEMBER_IN_SYNC";
                case unchecked((NtStatusCodes)0xC0380024): return "STATUS_VOLMGR_MEMBER_INDEX_DUPLICATE";
                case unchecked((NtStatusCodes)0xC0380025): return "STATUS_VOLMGR_MEMBER_INDEX_INVALID";
                case unchecked((NtStatusCodes)0xC0380026): return "STATUS_VOLMGR_MEMBER_MISSING";
                case unchecked((NtStatusCodes)0xC0380027): return "STATUS_VOLMGR_MEMBER_NOT_DETACHED";
                case unchecked((NtStatusCodes)0xC0380028): return "STATUS_VOLMGR_MEMBER_REGENERATING";
                case unchecked((NtStatusCodes)0xC0380029): return "STATUS_VOLMGR_ALL_DISKS_FAILED";
                case unchecked((NtStatusCodes)0xC038002A): return "STATUS_VOLMGR_NO_REGISTERED_USERS";
                case unchecked((NtStatusCodes)0xC038002B): return "STATUS_VOLMGR_NO_SUCH_USER";
                case unchecked((NtStatusCodes)0xC038002C): return "STATUS_VOLMGR_NOTIFICATION_RESET";
                case unchecked((NtStatusCodes)0xC038002D): return "STATUS_VOLMGR_NUMBER_OF_MEMBERS_INVALID";
                case unchecked((NtStatusCodes)0xC038002E): return "STATUS_VOLMGR_NUMBER_OF_PLEXES_INVALID";
                case unchecked((NtStatusCodes)0xC038002F): return "STATUS_VOLMGR_PACK_DUPLICATE";
                case unchecked((NtStatusCodes)0xC0380030): return "STATUS_VOLMGR_PACK_ID_INVALID";
                case unchecked((NtStatusCodes)0xC0380031): return "STATUS_VOLMGR_PACK_INVALID";
                case unchecked((NtStatusCodes)0xC0380032): return "STATUS_VOLMGR_PACK_NAME_INVALID";
                case unchecked((NtStatusCodes)0xC0380033): return "STATUS_VOLMGR_PACK_OFFLINE";
                case unchecked((NtStatusCodes)0xC0380034): return "STATUS_VOLMGR_PACK_HAS_QUORUM";
                case unchecked((NtStatusCodes)0xC0380035): return "STATUS_VOLMGR_PACK_WITHOUT_QUORUM";
                case unchecked((NtStatusCodes)0xC0380036): return "STATUS_VOLMGR_PARTITION_STYLE_INVALID";
                case unchecked((NtStatusCodes)0xC0380037): return "STATUS_VOLMGR_PARTITION_UPDATE_FAILED";
                case unchecked((NtStatusCodes)0xC0380038): return "STATUS_VOLMGR_PLEX_IN_SYNC";
                case unchecked((NtStatusCodes)0xC0380039): return "STATUS_VOLMGR_PLEX_INDEX_DUPLICATE";
                case unchecked((NtStatusCodes)0xC038003A): return "STATUS_VOLMGR_PLEX_INDEX_INVALID";
                case unchecked((NtStatusCodes)0xC038003B): return "STATUS_VOLMGR_PLEX_LAST_ACTIVE";
                case unchecked((NtStatusCodes)0xC038003C): return "STATUS_VOLMGR_PLEX_MISSING";
                case unchecked((NtStatusCodes)0xC038003D): return "STATUS_VOLMGR_PLEX_REGENERATING";
                case unchecked((NtStatusCodes)0xC038003E): return "STATUS_VOLMGR_PLEX_TYPE_INVALID";
                case unchecked((NtStatusCodes)0xC038003F): return "STATUS_VOLMGR_PLEX_NOT_RAID5";
                case unchecked((NtStatusCodes)0xC0380040): return "STATUS_VOLMGR_PLEX_NOT_SIMPLE";
                case unchecked((NtStatusCodes)0xC0380041): return "STATUS_VOLMGR_STRUCTURE_SIZE_INVALID";
                case unchecked((NtStatusCodes)0xC0380042): return "STATUS_VOLMGR_TOO_MANY_NOTIFICATION_REQUESTS";
                case unchecked((NtStatusCodes)0xC0380043): return "STATUS_VOLMGR_TRANSACTION_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC0380044): return "STATUS_VOLMGR_UNEXPECTED_DISK_LAYOUT_CHANGE";
                case unchecked((NtStatusCodes)0xC0380045): return "STATUS_VOLMGR_VOLUME_CONTAINS_MISSING_DISK";
                case unchecked((NtStatusCodes)0xC0380046): return "STATUS_VOLMGR_VOLUME_ID_INVALID";
                case unchecked((NtStatusCodes)0xC0380047): return "STATUS_VOLMGR_VOLUME_LENGTH_INVALID";
                case unchecked((NtStatusCodes)0xC0380048): return "STATUS_VOLMGR_VOLUME_LENGTH_NOT_SECTOR_SIZE_MULTIPLE";
                case unchecked((NtStatusCodes)0xC0380049): return "STATUS_VOLMGR_VOLUME_NOT_MIRRORED";
                case unchecked((NtStatusCodes)0xC038004A): return "STATUS_VOLMGR_VOLUME_NOT_RETAINED";
                case unchecked((NtStatusCodes)0xC038004B): return "STATUS_VOLMGR_VOLUME_OFFLINE";
                case unchecked((NtStatusCodes)0xC038004C): return "STATUS_VOLMGR_VOLUME_RETAINED";
                case unchecked((NtStatusCodes)0xC038004D): return "STATUS_VOLMGR_NUMBER_OF_EXTENTS_INVALID";
                case unchecked((NtStatusCodes)0xC038004E): return "STATUS_VOLMGR_DIFFERENT_SECTOR_SIZE";
                case unchecked((NtStatusCodes)0xC038004F): return "STATUS_VOLMGR_BAD_BOOT_DISK";
                case unchecked((NtStatusCodes)0xC0380050): return "STATUS_VOLMGR_PACK_CONFIG_OFFLINE";
                case unchecked((NtStatusCodes)0xC0380051): return "STATUS_VOLMGR_PACK_CONFIG_ONLINE";
                case unchecked((NtStatusCodes)0xC0380052): return "STATUS_VOLMGR_NOT_PRIMARY_PACK";
                case unchecked((NtStatusCodes)0xC0380053): return "STATUS_VOLMGR_PACK_LOG_UPDATE_FAILED";
                case unchecked((NtStatusCodes)0xC0380054): return "STATUS_VOLMGR_NUMBER_OF_DISKS_IN_PLEX_INVALID";
                case unchecked((NtStatusCodes)0xC0380055): return "STATUS_VOLMGR_NUMBER_OF_DISKS_IN_MEMBER_INVALID";
                case unchecked((NtStatusCodes)0xC0380056): return "STATUS_VOLMGR_VOLUME_MIRRORED";
                case unchecked((NtStatusCodes)0xC0380057): return "STATUS_VOLMGR_PLEX_NOT_SIMPLE_SPANNED";
                case unchecked((NtStatusCodes)0xC0380058): return "STATUS_VOLMGR_NO_VALID_LOG_COPIES";
                case unchecked((NtStatusCodes)0xC0380059): return "STATUS_VOLMGR_PRIMARY_PACK_PRESENT";
                case unchecked((NtStatusCodes)0xC038005A): return "STATUS_VOLMGR_NUMBER_OF_DISKS_INVALID";
                case unchecked((NtStatusCodes)0xC038005B): return "STATUS_VOLMGR_MIRROR_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC038005C): return "STATUS_VOLMGR_RAID5_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0x80390001): return "STATUS_BCD_NOT_ALL_ENTRIES_IMPORTED";
                case unchecked((NtStatusCodes)0xC0390002): return "STATUS_BCD_TOO_MANY_ELEMENTS";
                case unchecked((NtStatusCodes)0x80390003): return "STATUS_BCD_NOT_ALL_ENTRIES_SYNCHRONIZED";
                case unchecked((NtStatusCodes)0xC03A0001): return "STATUS_VHD_DRIVE_FOOTER_MISSING";
                case unchecked((NtStatusCodes)0xC03A0002): return "STATUS_VHD_DRIVE_FOOTER_CHECKSUM_MISMATCH";
                case unchecked((NtStatusCodes)0xC03A0003): return "STATUS_VHD_DRIVE_FOOTER_CORRUPT";
                case unchecked((NtStatusCodes)0xC03A0004): return "STATUS_VHD_FORMAT_UNKNOWN";
                case unchecked((NtStatusCodes)0xC03A0005): return "STATUS_VHD_FORMAT_UNSUPPORTED_VERSION";
                case unchecked((NtStatusCodes)0xC03A0006): return "STATUS_VHD_SPARSE_HEADER_CHECKSUM_MISMATCH";
                case unchecked((NtStatusCodes)0xC03A0007): return "STATUS_VHD_SPARSE_HEADER_UNSUPPORTED_VERSION";
                case unchecked((NtStatusCodes)0xC03A0008): return "STATUS_VHD_SPARSE_HEADER_CORRUPT";
                case unchecked((NtStatusCodes)0xC03A0009): return "STATUS_VHD_BLOCK_ALLOCATION_FAILURE";
                case unchecked((NtStatusCodes)0xC03A000A): return "STATUS_VHD_BLOCK_ALLOCATION_TABLE_CORRUPT";
                case unchecked((NtStatusCodes)0xC03A000B): return "STATUS_VHD_INVALID_BLOCK_SIZE";
                case unchecked((NtStatusCodes)0xC03A000C): return "STATUS_VHD_BITMAP_MISMATCH";
                case unchecked((NtStatusCodes)0xC03A000D): return "STATUS_VHD_PARENT_VHD_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC03A000E): return "STATUS_VHD_CHILD_PARENT_ID_MISMATCH";
                case unchecked((NtStatusCodes)0xC03A000F): return "STATUS_VHD_CHILD_PARENT_TIMESTAMP_MISMATCH";
                case unchecked((NtStatusCodes)0xC03A0010): return "STATUS_VHD_METADATA_READ_FAILURE";
                case unchecked((NtStatusCodes)0xC03A0011): return "STATUS_VHD_METADATA_WRITE_FAILURE";
                case unchecked((NtStatusCodes)0xC03A0012): return "STATUS_VHD_INVALID_SIZE";
                case unchecked((NtStatusCodes)0xC03A0013): return "STATUS_VHD_INVALID_FILE_SIZE";
                case unchecked((NtStatusCodes)0xC03A0014): return "STATUS_VIRTDISK_PROVIDER_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC03A0015): return "STATUS_VIRTDISK_NOT_VIRTUAL_DISK";
                case unchecked((NtStatusCodes)0xC03A0016): return "STATUS_VHD_PARENT_VHD_ACCESS_DENIED";
                case unchecked((NtStatusCodes)0xC03A0017): return "STATUS_VHD_CHILD_PARENT_SIZE_MISMATCH";
                case unchecked((NtStatusCodes)0xC03A0018): return "STATUS_VHD_DIFFERENCING_CHAIN_CYCLE_DETECTED";
                case unchecked((NtStatusCodes)0xC03A0019): return "STATUS_VHD_DIFFERENCING_CHAIN_ERROR_IN_PARENT";
                case unchecked((NtStatusCodes)0xC03A001A): return "STATUS_VIRTUAL_DISK_LIMITATION";
                case unchecked((NtStatusCodes)0xC03A001B): return "STATUS_VHD_INVALID_TYPE";
                case unchecked((NtStatusCodes)0xC03A001C): return "STATUS_VHD_INVALID_STATE";
                case unchecked((NtStatusCodes)0xC03A001D): return "STATUS_VIRTDISK_UNSUPPORTED_DISK_SECTOR_SIZE";
                case unchecked((NtStatusCodes)0xC03A001E): return "STATUS_VIRTDISK_DISK_ALREADY_OWNED";
                case unchecked((NtStatusCodes)0xC03A001F): return "STATUS_VIRTDISK_DISK_ONLINE_AND_WRITABLE";
                case unchecked((NtStatusCodes)0xC03A0020): return "STATUS_CTLOG_TRACKING_NOT_INITIALIZED";
                case unchecked((NtStatusCodes)0xC03A0021): return "STATUS_CTLOG_LOGFILE_SIZE_EXCEEDED_MAXSIZE";
                case unchecked((NtStatusCodes)0xC03A0022): return "STATUS_CTLOG_VHD_CHANGED_OFFLINE";
                case unchecked((NtStatusCodes)0xC03A0023): return "STATUS_CTLOG_INVALID_TRACKING_STATE";
                case unchecked((NtStatusCodes)0xC03A0024): return "STATUS_CTLOG_INCONSISTENT_TRACKING_FILE";
                case unchecked((NtStatusCodes)0xC03A0028): return "STATUS_VHD_METADATA_FULL";
                case unchecked((NtStatusCodes)0xC03A0029): return "STATUS_VHD_INVALID_CHANGE_TRACKING_ID";
                case unchecked((NtStatusCodes)0xC03A002A): return "STATUS_VHD_CHANGE_TRACKING_DISABLED";
                case unchecked((NtStatusCodes)0xC03A0030): return "STATUS_VHD_MISSING_CHANGE_TRACKING_INFORMATION";
                case unchecked((NtStatusCodes)0xC03A0031): return "STATUS_VHD_RESIZE_WOULD_TRUNCATE_DATA";
                case unchecked((NtStatusCodes)0xC03A0032): return "STATUS_VHD_COULD_NOT_COMPUTE_MINIMUM_VIRTUAL_SIZE";
                case unchecked((NtStatusCodes)0xC03A0033): return "STATUS_VHD_ALREADY_AT_OR_BELOW_MINIMUM_VIRTUAL_SIZE";
                case unchecked((NtStatusCodes)0x803A0001): return "STATUS_QUERY_STORAGE_ERROR";
                case unchecked((NtStatusCodes)0x803F0001): return "STATUS_GDI_HANDLE_LEAK";
                case unchecked((NtStatusCodes)0xC0400001): return "STATUS_RKF_KEY_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0400002): return "STATUS_RKF_DUPLICATE_KEY";
                case unchecked((NtStatusCodes)0xC0400003): return "STATUS_RKF_BLOB_FULL";
                case unchecked((NtStatusCodes)0xC0400004): return "STATUS_RKF_STORE_FULL";
                case unchecked((NtStatusCodes)0xC0400005): return "STATUS_RKF_FILE_BLOCKED";
                case unchecked((NtStatusCodes)0xC0400006): return "STATUS_RKF_ACTIVE_KEY";
                case unchecked((NtStatusCodes)0xC0410001): return "STATUS_RDBSS_RESTART_OPERATION";
                case unchecked((NtStatusCodes)0xC0410002): return "STATUS_RDBSS_CONTINUE_OPERATION";
                case unchecked((NtStatusCodes)0xC0410003): return "STATUS_RDBSS_POST_OPERATION";
                case unchecked((NtStatusCodes)0xC0410004): return "STATUS_RDBSS_RETRY_LOOKUP";
                case unchecked((NtStatusCodes)0xC0420001): return "STATUS_BTH_ATT_INVALID_HANDLE";
                case unchecked((NtStatusCodes)0xC0420002): return "STATUS_BTH_ATT_READ_NOT_PERMITTED";
                case unchecked((NtStatusCodes)0xC0420003): return "STATUS_BTH_ATT_WRITE_NOT_PERMITTED";
                case unchecked((NtStatusCodes)0xC0420004): return "STATUS_BTH_ATT_INVALID_PDU";
                case unchecked((NtStatusCodes)0xC0420005): return "STATUS_BTH_ATT_INSUFFICIENT_AUTHENTICATION";
                case unchecked((NtStatusCodes)0xC0420006): return "STATUS_BTH_ATT_REQUEST_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0420007): return "STATUS_BTH_ATT_INVALID_OFFSET";
                case unchecked((NtStatusCodes)0xC0420008): return "STATUS_BTH_ATT_INSUFFICIENT_AUTHORIZATION";
                case unchecked((NtStatusCodes)0xC0420009): return "STATUS_BTH_ATT_PREPARE_QUEUE_FULL";
                case unchecked((NtStatusCodes)0xC042000A): return "STATUS_BTH_ATT_ATTRIBUTE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC042000B): return "STATUS_BTH_ATT_ATTRIBUTE_NOT_LONG";
                case unchecked((NtStatusCodes)0xC042000C): return "STATUS_BTH_ATT_INSUFFICIENT_ENCRYPTION_KEY_SIZE";
                case unchecked((NtStatusCodes)0xC042000D): return "STATUS_BTH_ATT_INVALID_ATTRIBUTE_VALUE_LENGTH";
                case unchecked((NtStatusCodes)0xC042000E): return "STATUS_BTH_ATT_UNLIKELY";
                case unchecked((NtStatusCodes)0xC042000F): return "STATUS_BTH_ATT_INSUFFICIENT_ENCRYPTION";
                case unchecked((NtStatusCodes)0xC0420010): return "STATUS_BTH_ATT_UNSUPPORTED_GROUP_TYPE";
                case unchecked((NtStatusCodes)0xC0420011): return "STATUS_BTH_ATT_INSUFFICIENT_RESOURCES";
                case unchecked((NtStatusCodes)0xC0421000): return "STATUS_BTH_ATT_UNKNOWN_ERROR";
                case unchecked((NtStatusCodes)0xC0430001): return "STATUS_SECUREBOOT_ROLLBACK_DETECTED";
                case unchecked((NtStatusCodes)0xC0430002): return "STATUS_SECUREBOOT_POLICY_VIOLATION";
                case unchecked((NtStatusCodes)0xC0430003): return "STATUS_SECUREBOOT_INVALID_POLICY";
                case unchecked((NtStatusCodes)0xC0430004): return "STATUS_SECUREBOOT_POLICY_PUBLISHER_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0430005): return "STATUS_SECUREBOOT_POLICY_NOT_SIGNED";
                case unchecked((NtStatusCodes)0x80430006): return "STATUS_SECUREBOOT_NOT_ENABLED";
                case unchecked((NtStatusCodes)0xC0430007): return "STATUS_SECUREBOOT_FILE_REPLACED";
                case unchecked((NtStatusCodes)0xC0430008): return "STATUS_SECUREBOOT_POLICY_NOT_AUTHORIZED";
                case unchecked((NtStatusCodes)0xC0430009): return "STATUS_SECUREBOOT_POLICY_UNKNOWN";
                case unchecked((NtStatusCodes)0xC043000A): return "STATUS_SECUREBOOT_POLICY_MISSING_ANTIROLLBACKVERSION";
                case unchecked((NtStatusCodes)0xC043000B): return "STATUS_SECUREBOOT_PLATFORM_ID_MISMATCH";
                case unchecked((NtStatusCodes)0xC043000C): return "STATUS_SECUREBOOT_POLICY_ROLLBACK_DETECTED";
                case unchecked((NtStatusCodes)0xC043000D): return "STATUS_SECUREBOOT_POLICY_UPGRADE_MISMATCH";
                case unchecked((NtStatusCodes)0xC043000E): return "STATUS_SECUREBOOT_REQUIRED_POLICY_FILE_MISSING";
                case unchecked((NtStatusCodes)0xC043000F): return "STATUS_SECUREBOOT_NOT_BASE_POLICY";
                case unchecked((NtStatusCodes)0xC0430010): return "STATUS_SECUREBOOT_NOT_SUPPLEMENTAL_POLICY";
                case unchecked((NtStatusCodes)0xC0EB0001): return "STATUS_PLATFORM_MANIFEST_NOT_AUTHORIZED";
                case unchecked((NtStatusCodes)0xC0EB0002): return "STATUS_PLATFORM_MANIFEST_INVALID";
                case unchecked((NtStatusCodes)0xC0EB0003): return "STATUS_PLATFORM_MANIFEST_FILE_NOT_AUTHORIZED";
                case unchecked((NtStatusCodes)0xC0EB0004): return "STATUS_PLATFORM_MANIFEST_CATALOG_NOT_AUTHORIZED";
                case unchecked((NtStatusCodes)0xC0EB0005): return "STATUS_PLATFORM_MANIFEST_BINARY_ID_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0EB0006): return "STATUS_PLATFORM_MANIFEST_NOT_ACTIVE";
                case unchecked((NtStatusCodes)0xC0EB0007): return "STATUS_PLATFORM_MANIFEST_NOT_SIGNED";
                case unchecked((NtStatusCodes)0xC0E90001): return "STATUS_SYSTEM_INTEGRITY_ROLLBACK_DETECTED";
                case unchecked((NtStatusCodes)0xC0E90002): return "STATUS_SYSTEM_INTEGRITY_POLICY_VIOLATION";
                case unchecked((NtStatusCodes)0xC0E90003): return "STATUS_SYSTEM_INTEGRITY_INVALID_POLICY";
                case unchecked((NtStatusCodes)0xC0E90004): return "STATUS_SYSTEM_INTEGRITY_POLICY_NOT_SIGNED";
                case unchecked((NtStatusCodes)0xC0E90005): return "STATUS_SYSTEM_INTEGRITY_TOO_MANY_POLICIES";
                case unchecked((NtStatusCodes)0xC0E90006): return "STATUS_SYSTEM_INTEGRITY_SUPPLEMENTAL_POLICY_NOT_AUTHORIZED";
                case unchecked((NtStatusCodes)0xC0E90007): return "STATUS_SYSTEM_INTEGRITY_REPUTATION_MALICIOUS";
                case unchecked((NtStatusCodes)0xC0E90008): return "STATUS_SYSTEM_INTEGRITY_REPUTATION_PUA";
                case unchecked((NtStatusCodes)0xC0E90009): return "STATUS_SYSTEM_INTEGRITY_REPUTATION_DANGEROUS_EXT";
                case unchecked((NtStatusCodes)0xC0E9000A): return "STATUS_SYSTEM_INTEGRITY_REPUTATION_OFFLINE";
                case unchecked((NtStatusCodes)0xC0EA0001): return "STATUS_NO_APPLICABLE_APP_LICENSES_FOUND";
                case unchecked((NtStatusCodes)0xC0EA0002): return "STATUS_CLIP_LICENSE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0EA0003): return "STATUS_CLIP_DEVICE_LICENSE_MISSING";
                case unchecked((NtStatusCodes)0xC0EA0004): return "STATUS_CLIP_LICENSE_INVALID_SIGNATURE";
                case unchecked((NtStatusCodes)0xC0EA0005): return "STATUS_CLIP_KEYHOLDER_LICENSE_MISSING_OR_INVALID";
                case unchecked((NtStatusCodes)0xC0EA0006): return "STATUS_CLIP_LICENSE_EXPIRED";
                case unchecked((NtStatusCodes)0xC0EA0007): return "STATUS_CLIP_LICENSE_SIGNED_BY_UNKNOWN_SOURCE";
                case unchecked((NtStatusCodes)0xC0EA0008): return "STATUS_CLIP_LICENSE_NOT_SIGNED";
                case unchecked((NtStatusCodes)0xC0EA0009): return "STATUS_CLIP_LICENSE_HARDWARE_ID_OUT_OF_TOLERANCE";
                case unchecked((NtStatusCodes)0xC0EA000A): return "STATUS_CLIP_LICENSE_DEVICE_ID_MISMATCH";
                case unchecked((NtStatusCodes)0xC0440001): return "STATUS_AUDIO_ENGINE_NODE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0440002): return "STATUS_HDAUDIO_EMPTY_CONNECTION_LIST";
                case unchecked((NtStatusCodes)0xC0440003): return "STATUS_HDAUDIO_CONNECTION_LIST_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0440004): return "STATUS_HDAUDIO_NO_LOGICAL_DEVICES_CREATED";
                case unchecked((NtStatusCodes)0xC0440005): return "STATUS_HDAUDIO_NULL_LINKED_LIST_ENTRY";
                case unchecked((NtStatusCodes)0x00E70000): return "STATUS_SPACES_REPAIRED";
                case unchecked((NtStatusCodes)0x00E70001): return "STATUS_SPACES_PAUSE";
                case unchecked((NtStatusCodes)0x00E70002): return "STATUS_SPACES_COMPLETE";
                case unchecked((NtStatusCodes)0x00E70003): return "STATUS_SPACES_REDIRECT";
                case unchecked((NtStatusCodes)0xC0E70001): return "STATUS_SPACES_FAULT_DOMAIN_TYPE_INVALID";
                case unchecked((NtStatusCodes)0xC0E70003): return "STATUS_SPACES_RESILIENCY_TYPE_INVALID";
                case unchecked((NtStatusCodes)0xC0E70004): return "STATUS_SPACES_DRIVE_SECTOR_SIZE_INVALID";
                case unchecked((NtStatusCodes)0xC0E70006): return "STATUS_SPACES_DRIVE_REDUNDANCY_INVALID";
                case unchecked((NtStatusCodes)0xC0E70007): return "STATUS_SPACES_NUMBER_OF_DATA_COPIES_INVALID";
                case unchecked((NtStatusCodes)0xC0E70009): return "STATUS_SPACES_INTERLEAVE_LENGTH_INVALID";
                case unchecked((NtStatusCodes)0xC0E7000A): return "STATUS_SPACES_NUMBER_OF_COLUMNS_INVALID";
                case unchecked((NtStatusCodes)0xC0E7000B): return "STATUS_SPACES_NOT_ENOUGH_DRIVES";
                case unchecked((NtStatusCodes)0xC0E7000C): return "STATUS_SPACES_EXTENDED_ERROR";
                case unchecked((NtStatusCodes)0xC0E7000D): return "STATUS_SPACES_PROVISIONING_TYPE_INVALID";
                case unchecked((NtStatusCodes)0xC0E7000E): return "STATUS_SPACES_ALLOCATION_SIZE_INVALID";
                case unchecked((NtStatusCodes)0xC0E7000F): return "STATUS_SPACES_ENCLOSURE_AWARE_INVALID";
                case unchecked((NtStatusCodes)0xC0E70010): return "STATUS_SPACES_WRITE_CACHE_SIZE_INVALID";
                case unchecked((NtStatusCodes)0xC0E70011): return "STATUS_SPACES_NUMBER_OF_GROUPS_INVALID";
                case unchecked((NtStatusCodes)0xC0E70012): return "STATUS_SPACES_DRIVE_OPERATIONAL_STATE_INVALID";
                case unchecked((NtStatusCodes)0xC0E70013): return "STATUS_SPACES_UPDATE_COLUMN_STATE";
                case unchecked((NtStatusCodes)0xC0E70014): return "STATUS_SPACES_MAP_REQUIRED";
                case unchecked((NtStatusCodes)0xC0E70015): return "STATUS_SPACES_UNSUPPORTED_VERSION";
                case unchecked((NtStatusCodes)0xC0E70016): return "STATUS_SPACES_CORRUPT_METADATA";
                case unchecked((NtStatusCodes)0xC0E70017): return "STATUS_SPACES_DRT_FULL";
                case unchecked((NtStatusCodes)0xC0E70018): return "STATUS_SPACES_INCONSISTENCY";
                case unchecked((NtStatusCodes)0xC0E70019): return "STATUS_SPACES_LOG_NOT_READY";
                case unchecked((NtStatusCodes)0xC0E7001A): return "STATUS_SPACES_NO_REDUNDANCY";
                case unchecked((NtStatusCodes)0xC0E7001B): return "STATUS_SPACES_DRIVE_NOT_READY";
                case unchecked((NtStatusCodes)0xC0E7001C): return "STATUS_SPACES_DRIVE_SPLIT";
                case unchecked((NtStatusCodes)0xC0E7001D): return "STATUS_SPACES_DRIVE_LOST_DATA";
                case unchecked((NtStatusCodes)0xC0E7001E): return "STATUS_SPACES_ENTRY_INCOMPLETE";
                case unchecked((NtStatusCodes)0xC0E7001F): return "STATUS_SPACES_ENTRY_INVALID";
                case unchecked((NtStatusCodes)0xC0E70020): return "STATUS_SPACES_MARK_DIRTY";
                case unchecked((NtStatusCodes)0xC0E70021): return "STATUS_SPACES_PD_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC0E70022): return "STATUS_SPACES_PD_LENGTH_MISMATCH";
                case unchecked((NtStatusCodes)0xC0E70023): return "STATUS_SPACES_PD_UNSUPPORTED_VERSION";
                case unchecked((NtStatusCodes)0xC0E70024): return "STATUS_SPACES_PD_INVALID_DATA";
                case unchecked((NtStatusCodes)0xC0E70025): return "STATUS_SPACES_FLUSH_METADATA";
                case unchecked((NtStatusCodes)0xC0E70026): return "STATUS_SPACES_CACHE_FULL";
                case unchecked((NtStatusCodes)0xC0500003): return "STATUS_VOLSNAP_BOOTFILE_NOT_VALID";
                case unchecked((NtStatusCodes)0xC0500004): return "STATUS_VOLSNAP_ACTIVATION_TIMEOUT";
                case unchecked((NtStatusCodes)0xC0500005): return "STATUS_VOLSNAP_NO_BYPASSIO_WITH_SNAPSHOT";
                case unchecked((NtStatusCodes)0xC0510001): return "STATUS_IO_PREEMPTED";
                case unchecked((NtStatusCodes)0xC05C0000): return "STATUS_SVHDX_ERROR_STORED";
                case unchecked((NtStatusCodes)0xC05CFF00): return "STATUS_SVHDX_ERROR_NOT_AVAILABLE";
                case unchecked((NtStatusCodes)0xC05CFF01): return "STATUS_SVHDX_UNIT_ATTENTION_AVAILABLE";
                case unchecked((NtStatusCodes)0xC05CFF02): return "STATUS_SVHDX_UNIT_ATTENTION_CAPACITY_DATA_CHANGED";
                case unchecked((NtStatusCodes)0xC05CFF03): return "STATUS_SVHDX_UNIT_ATTENTION_RESERVATIONS_PREEMPTED";
                case unchecked((NtStatusCodes)0xC05CFF04): return "STATUS_SVHDX_UNIT_ATTENTION_RESERVATIONS_RELEASED";
                case unchecked((NtStatusCodes)0xC05CFF05): return "STATUS_SVHDX_UNIT_ATTENTION_REGISTRATIONS_PREEMPTED";
                case unchecked((NtStatusCodes)0xC05CFF06): return "STATUS_SVHDX_UNIT_ATTENTION_OPERATING_DEFINITION_CHANGED";
                case unchecked((NtStatusCodes)0xC05CFF07): return "STATUS_SVHDX_RESERVATION_CONFLICT";
                case unchecked((NtStatusCodes)0xC05CFF08): return "STATUS_SVHDX_WRONG_FILE_TYPE";
                case unchecked((NtStatusCodes)0xC05CFF09): return "STATUS_SVHDX_VERSION_MISMATCH";
                case unchecked((NtStatusCodes)0xC05CFF0A): return "STATUS_VHD_SHARED";
                case unchecked((NtStatusCodes)0xC05CFF0B): return "STATUS_SVHDX_NO_INITIATOR";
                case unchecked((NtStatusCodes)0xC05CFF0C): return "STATUS_VHDSET_BACKING_STORAGE_NOT_FOUND";
                case unchecked((NtStatusCodes)0xC05D0000): return "STATUS_SMB_NO_PREAUTH_INTEGRITY_HASH_OVERLAP";
                case unchecked((NtStatusCodes)0xC05D0001): return "STATUS_SMB_BAD_CLUSTER_DIALECT";
                case unchecked((NtStatusCodes)0xC05D0002): return "STATUS_SMB_GUEST_LOGON_BLOCKED";
                case unchecked((NtStatusCodes)0xC05D0003): return "STATUS_SMB_NO_SIGNING_ALGORITHM_OVERLAP";
                case unchecked((NtStatusCodes)0xC0E80000): return "STATUS_SECCORE_INVALID_COMMAND";
                case unchecked((NtStatusCodes)0xC0450000): return "STATUS_VSM_NOT_INITIALIZED";
                case unchecked((NtStatusCodes)0xC0450001): return "STATUS_VSM_DMA_PROTECTION_NOT_IN_USE";
                case unchecked((NtStatusCodes)0xC0EC0000): return "STATUS_APPEXEC_CONDITION_NOT_SATISFIED";
                case unchecked((NtStatusCodes)0xC0EC0001): return "STATUS_APPEXEC_HANDLE_INVALIDATED";
                case unchecked((NtStatusCodes)0xC0EC0002): return "STATUS_APPEXEC_INVALID_HOST_GENERATION";
                case unchecked((NtStatusCodes)0xC0EC0003): return "STATUS_APPEXEC_UNEXPECTED_PROCESS_REGISTRATION";
                case unchecked((NtStatusCodes)0xC0EC0004): return "STATUS_APPEXEC_INVALID_HOST_STATE";
                case unchecked((NtStatusCodes)0xC0EC0005): return "STATUS_APPEXEC_NO_DONOR";
                case unchecked((NtStatusCodes)0xC0EC0006): return "STATUS_APPEXEC_HOST_ID_MISMATCH";
                case unchecked((NtStatusCodes)0xC0EC0007): return "STATUS_APPEXEC_UNKNOWN_USER";
                case unchecked((NtStatusCodes)0xC0EC0008): return "STATUS_APPEXEC_APP_COMPAT_BLOCK";
                case unchecked((NtStatusCodes)0xC0EC0009): return "STATUS_APPEXEC_CALLER_WAIT_TIMEOUT";
                case unchecked((NtStatusCodes)0xC0EC000A): return "STATUS_APPEXEC_CALLER_WAIT_TIMEOUT_TERMINATION";
                case unchecked((NtStatusCodes)0xC0EC000B): return "STATUS_APPEXEC_CALLER_WAIT_TIMEOUT_LICENSING";
                case unchecked((NtStatusCodes)0xC0EC000C): return "STATUS_APPEXEC_CALLER_WAIT_TIMEOUT_RESOURCES";
                case unchecked((NtStatusCodes)0xC0240000): return "STATUS_QUIC_HANDSHAKE_FAILURE";
                case unchecked((NtStatusCodes)0xC0240001): return "STATUS_QUIC_VER_NEG_FAILURE";
                case unchecked((NtStatusCodes)0xC0240002): return "STATUS_QUIC_USER_CANCELED";
                case unchecked((NtStatusCodes)0xC0240003): return "STATUS_QUIC_INTERNAL_ERROR";
                case unchecked((NtStatusCodes)0xC0240004): return "STATUS_QUIC_PROTOCOL_VIOLATION";
                case unchecked((NtStatusCodes)0xC0240005): return "STATUS_QUIC_CONNECTION_IDLE";
                case unchecked((NtStatusCodes)0xC0240006): return "STATUS_QUIC_CONNECTION_TIMEOUT";
                case unchecked((NtStatusCodes)0xC0240007): return "STATUS_QUIC_ALPN_NEG_FAILURE";
                case unchecked((NtStatusCodes)0xC0460001): return "STATUS_IORING_REQUIRED_FLAG_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0460002): return "STATUS_IORING_SUBMISSION_QUEUE_FULL";
                case unchecked((NtStatusCodes)0xC0460003): return "STATUS_IORING_VERSION_NOT_SUPPORTED";
                case unchecked((NtStatusCodes)0xC0460004): return "STATUS_IORING_SUBMISSION_QUEUE_TOO_BIG";
                case unchecked((NtStatusCodes)0xC0460005): return "STATUS_IORING_COMPLETION_QUEUE_TOO_BIG";
                case unchecked((NtStatusCodes)0xC0460006): return "STATUS_IORING_SUBMIT_IN_PROGRESS";
                case unchecked((NtStatusCodes)0xC0460007): return "STATUS_IORING_CORRUPT";
            }

            return "Unknown";
        }
    }
}
