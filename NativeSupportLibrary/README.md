# Native Support Library

This is my current (February 2022) attempt at constructing a general purpose
library for permitting C# use of NT native calls.  Since I've been using native
calls for decades at this point, I'm fairly comfortable with them and they
provide access to native Windows OS services that are often unavailable or
obfuscated.

This isn't new and I'm not claiming my approach to this is better.  I just built
something that works for me:

* C# calls that mirror the native calls but use standard class objects for their
  interface rather than the native data structures needed.

* Data structures that match the _name_ of the corresponding native structure
  (more or less) and handle marshaling (and unmarshaling) between the C# class
  structure and the native data structure.

* A C code library that dynamically links to the native call (from ntdll.dll)
  that simplifies debugging (since I can "see" what is being sent to the
  native call, rather than trying to debug STATUS_INVALID_PARAMETER.)

February 1, 2022.

## C# Calls

The idea is that I can have a C# function called "NtCreateFile" that is declared
to take class objects of the relevant time and behave like C# code expects
things to behave; NtCreateFile isn't really the optimal example, since there are
quite a few examples of doing this.  NtQueryEaFile might be a better option or
NtQuerySecurityObject.

My _ultimate_ goal was to (1) add the ability to dynamically query the USN
journal from NTFS; and (2) add the ability to use the mount manager to map from
devices back to the familiar drive letters that users expect to see.

Using some scripting, I did construct a complete list (as of the latest SDK/WDK)
of all the status return codes in ntstatus.h so the symbolic names can be used
in the C# code. I _also_ generated an inverse mapping layer (from the numeric
code to the symbolic name) because I find that vastly more useful when
debugging.

## Data Types

I'm sure there are better ways to do this, but I wanted to build something that
would generally work and that I could understand and control.

The basic idea is that C# wants to manage memory, while C libraries expect to do
it themselves.  There is considerable friction between these two models.  C#
permits creating "unmanaged memory".

There is an inherent efficiency at using in-place data when possible and most of
the native call work I saw to use PInvoke did try to do this.  I spent too much
time trying to generalize this to a broader range of types and finally decided
that I'd prefer to have a general model that I can apply, even if it is runtime
less efficient.

So, I'm using a marshaling approach:

* A data structure has C# definitions for the data that is managed by a class
  that matches the name of the NT native data structure (LARGE_INTEGER,
  OBJECT_ATTRIBUTES, SECURITY_DESCRIPTOR, ACL, etc.)

* Each one has a common model for an implicit cast operator to an IntPtr.

* The library calls are declared to take IntPtrs.  When invoked with the object,
  the implicit conversion will ensure marshaling the data into the relevant
  format.

* The destructor function cleans up the marshaling buffer.

* If the class object supports data update, there is versioning information. At
  present I only have constructed versioning information for input parameters
  (OBJECT_ATTRIBUTES) and have not done so for output parameters (though that
  sure would be a good idea.)  The idea is that if the version numbers are the
  same and the marshaling buffer exists, then there's no reason to re-marshal.
  If the version numbers are different then the data is marshaled and the
  marshaled version number is set to the data version number.
  Some care here is required, but my goal was to restrict it to the support
  library itself.

I'm sure this isn't as fast as it could be.  I don't care.  It seems to be
generalizing well - I've not seen anyone else deal with the security descriptor
and security qos bits of the object attributes structure.  I went down that path
far enough to think I had a viable model: ACLs have a list of ACE entries that
can be marshaled, albeit painfully.  I should be able to plumb that in with
testing to invoke
[RtlValidAcl](https://github.com/zhuhuibeishadiao/ntoskrnl/blob/master/Rtl/acledit.c)

Since security descriptors and acls aren't required for what I'm doing right
now, I'm going to set it aside and move on.  It _may_ be useful in the future,
in which case I can revisit this.

## C library

This is here to simplify debugging more than anything else.  I can "see" (or
print) what is being passed between C# and the native call.  I did find it was
also useful for testing data structures as I worked through this code.

The library is _not_ complete.
