
namespace Indaleko
{
    //
    // The purpose of the activity log is to provide a generalized interface for storing information
    // into the activity log.  Someone using this shouldn't need to know where/how the activity log
    // is maintained.
    //
    // Note that this is a singleton, since I don't envision having multiple activity logs.
    //
    public class ActivityLog
    {
        //
        // Having a static configuration is not flexible, but it is expedient.
        //
        public static void ConfigureActivityLog(ActivityLog Log)
        {
            throw new NotImplementedException("ActivityLog is a base class.");
        }
    }


}

