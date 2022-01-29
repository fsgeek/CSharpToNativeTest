# C# to Native Test

My goal in building this was to provide an easy-to-debug environment for enabling cross-language support on Windows.
Specifically, my goal was to permit invoking Windows native OS calls (Nt/Zw functions) from managed code.

My primary motivation for doing so is that because of the type of work that I have done for years
(Windows kernel development) I know how to do things via the native API that are difficult to do via the Win32 API.
Admittedly many of these things Microsoft (and others) have mitigated over the years, but I am not motivated to
find random collections of dissimilar APIs to achieve tasks I know how to achieve already using the native APIs.

The Windows native API is actually fairly coherent, with a common interface model that includes useful features
like counted 16-bit Unicode strings, inherently asynchronous I/O, and access to a wide range of features that
are used to implement other common APIs.  I suspect this work won't be useful to others, but it is useful to me.

## Native API

The Windows native API consists of functions that start with the Nt or Zw prefix in almost all cases; the actual
interface for these dynamically generates the system call code needed to reach the corresponding kernel mode
system call implementation.  Thus, unlike UNIX or Linux, where system calls have published numbers, the Windows
system calls do not publish the system call number.  Thus, to ensure interoperability across versions, all Windows
programs use a dynamic link library, ntdll.dll, to invoke the correct system call.  Others have described this
process in greater detail - Windows actually supports multiple system call tables (up to four last time I checked)
and I have seen situations where as many as three are in use: one for the OS itself, one for the Win32 kernel API,
and one for IIS.  I don't think IIS uses one these days, but I admit I haven't checked.

At any rate, the native API itself is only quasi-documented.  The actual header file that gets generated as part
of the Windows build process was (and presumably still is) called **zwapi.h**.  Versions of this file have been
leaked a number of times over the years and I can see multiple (around 5,000 when I just looked) references to zwapi
on [Github.com](Github.com).  Most of these relate to the Windows native API.

A fair bit of this API is exposed in the [Windows Driver Kit](https://docs.microsoft.com/en-us/windows-hardware/drivers/download-the-wdk).
At one point zwapi.h was actually included in the EWDK ("Enterprice Windows Driver Kit,") which is a stand-alone driver development kit
that includes a stand-alone collection of tools, headers, and examples for building device drivers for Windows.

Three key files for extracting bits of the zwapi.h are wdm.h, ntddk.h, and ntifs.h.  Only the APIs needed for these are actually exposed,
and since most of my work has been done with file systems related technologies, I've learned to use them all in building applications for
invoking file system functionality that could not be exercised via the Win32 APIs.

Microsoft has published a few of these (e.g., [NtCreateFile](https://docs.microsoft.com/en-us/windows/win32/api/winternl/nf-winternl-ntcreatefile)).
The NtCreateFile API is needed to be able to use extended attributes, pre-allocation of files, security settings, and the widest range of names supported
by the Windows kernel, including "open by ID" names.

In user mode, the Nt/Zw functions (exported by ntdll.dll) of the same name **are the same code**.  So if I call NtCreateFile or ZwCreateFile, it invokes
the same entry point.  In _kernel mode_ the Nt/Zw functions **are not the same**.  The Nt version is an invocation of the system service _without_
a re-entry into the OS.  The Zw version is an invocation of the system service _through the system call process_ and thus represents a re-entry into the OS.
For kernel mode development this distinction is really critical because "previous mode" indicates "user" for the Nt version and "kernel" for the Zw version.
This is often used for making security decisions ("if previous mode is kernel then trust them.")

For my purposes, I use them interchangeably in this library. Mostly I do this to attempt avoiding naming confusion in my own head.

## Native call library

My native call library is written in C and dynamically loads the native Nt calls via the Win32 function
[LoadLibrary](https://docs.microsoft.com/en-us/cpp/build/loadlibrary-and-afxloadlibrary) - to load ntdll.dll, and 
[GetProcAddress](https://docs.microsoft.com/en-us/cpp/build/getprocaddress).  Ironically, those are implemented
on top of ntdll.dll as well.  In addition to being the native API library, it is _also_ the "program loader" and
handles program startup, dynamic linking to DLLs, and other critical functionality around how programs interact
with the OS.

Before I ended up writing this package, I tried a number of other packages, such as the PInvoke package (available via NuGet).  I found
the experience frustrating because the support was minimal in nature, did not work with the current version(s) of C#, and made debugging
difficult.  The approach I've taken introduces an "extra level of indirection" - the c library is itself a DLL that is then dynamically
invoked from C# through the Interop services layer - rather than invoking things from ntdll.dll directly.  My rationale for this
was to make it easy for me to "see" what was being sent to the native API.  C# abstracts away how data is stored in memory and even though
it can often be convinced to do so in the same fashion as C does, this is not automatic and difficult to ascertain what it is doing.

Thus, it is really easy for me to actually display what I'm seeing in the native library, debug accordingly, and then finish linking up
the system call.  I'm not overly concerned about the additional call overhead but someone who is could easily adapt my work so that it
invokes ntdll.dll directly.

The _other_ problem I ran into is that I found some native calls would not load.  For example, I found that `NtCreateFile` did not
load at some point (STATUS_ACCESS_DENIED).  I ended up doing call tracing with [ProcMon](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)
and first noticed that the thing I was trying to open was never even attempted ("\??\C:" in my case).  Further analysis of the
trace showed me that the error was being returned from the runtime becuase it could not find NtCreateFile inside ntdll.dll.
I further found that it was _not_ using the same ntdll.dll, but instead some ntdll.dll that appeared to be part of the runtime environment.

My C library uses the standard Win32 API and that in turn looks in the standard locations. That works around this problem as well.  This was my original
motivation for separating things; the ability to easily debug data structure layout was just one additional plus.

I also built a script (in a Jupyter notebook, actually) that takes ntstatus.h (from the Windows SDK or WDK) and generates C# code
so the symbolic names are available _and_ so that the numeric values can be mapped back to a symbolic name (there are two duplicates, the
script includes one of them and adds the second name as a comment in the code it generates.)  The notebook makes it easy to reproduce this
later. I have considered extending this to the other data structures available as well but at least for now I have not done so.  I suspect
I could also do something similar with the Zw APIs as well.  Again, for the time being I've just been manually adding them.

## C# wrapper

There's not much of a wrapper around the C# code at this point.  I'm no C# expert and I suspect much of what I'm trying to do could be
done in a more automated fashion. My goal was to enable me building services for collecting system activity and loading it up into
a database for analysis, not in making this more generalizable. Still, I think this is likely to be useful in the future, so I'm trying
not to cripple it, either.
