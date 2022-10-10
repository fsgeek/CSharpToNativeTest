# Notes on Local Drive Indexing

Working through the local drive indexer for Windows has been interesting because it shows
both the complexity of the APIs introduced in Windows NT over the past 30 years - which is
not really so different than other operating systems (e.g., Linux.)  Perhaps more a matter
of _degree_ than anything else.

However, it has also forced me to think about a couple of things:

* How do I enable simple anonymization.  It is _much_ easier to share datasets
  when the interesting data has been removed.  File names are one source of such
  data.  Do I perform a substitution of some sort?  Strip the file name
  information and see what we can do _emph_ without it? The latter might help
  address concerns regarding security.  Still, we have to worry that things like
  secondary metadata might also matter. Think "extended attributes" and
  "alternate data streams" for example.

* What's the right data model here?  I could just mush everything together into
  big blobs but that seems, at best, _inelegant_.  However that seems to
  undermine the original premise of this work: _relationships_ are important.
  So, the fact a set of objects are gathered together into a storage location
  seems like a relationship I don't want to lose.  Similarly, time-series
  relationships, such as causal relationships so important in Provenance,
  shouldn't be lost.

  - For example, if I overwrite a file, it's file identifier (i-node number or
    whatever you want to call it) won't change, so the file identifier ties
    things together.  However, _most_ editors actually don't work that way -
    they do a "write a new copy" and "rename" model.  That's certainly true for
    both Windows _and_ UNIX/Linux systems.  A key reason for this is that it
    minimizes the likelihood of data loss: rename is a small, usually atomic
    operation, while writing changes to a file is a series of steps where part
    of the file contents are updated/stored.  Thus, it is about failure
    recovery.

  - Windows explicitly has a "tunnel cache" that preserves certain file
    attributes across a delete/create and rename scenario.  For example, FastFat
    preserves both the short file name and the creation timestamps.  But in
    such cases the file ID changes.

* How do I identify each of these objects? Part of the observation here is not
  to fall into the trivial metric ("same file" versus "not same file") because
  that won't allow us to exttract addtiional insight.  Instead, what I want to
  do is show that _some_ characteristics remained the same while others changed.
  For example:

  - In the case above of the classic edit cycle where a new file is created and
    then atomically renamed onto the old file, the file identifiers are
    different yet they are related.  The operation of such a transformation will
    be captured in the activity data (since there will be a rename operation to
    tie them together) but on Windows at least that creation timestamp will also
    tie them together.  NTFS with it's high precision (100ns) timestamps
    suggests another way of finding potentially interesting files.

  - One of the "features" I added into my local indexer was computing a SHA-512
    hash value for the contents of the file. Files that have the same SHA-512
    hash value are, with high probability, likely to have the same content.  So,
    when I see two files that share hash values _and_ length, it's plausible to
    argue they have the same data contents.  If this is a file that has had some
    metadata stripped away there's insight: oh look, you copied this onto a USB
    stick with ExFAT but when that file was stored on NTFS it had a
    **::Zone_Identifier** stream, which implies it was downloaded from an
    internet location.  Now we can "fill in the blanks."

Even on a single local system there is a dizzying array of information that
could be saved.  The configuration of the system, its attached hardware, serial
numbers, OS versions, etc.  I looked at capturing some of this, but I concluded
it wasn't a good use of time _for now_ though it could be a useful addition as I
move from single system to multi-system analysis.

Thus, what I am looking at doing is separating out certain characteristics:

* Every distinct object is given its own identifier, say a UUID.
* Objects _can_ have a content based name (hence the SHA-512 hash value).
* Metadata related to an object is a distinct entity and shows its relationship
  to it's object.  For example:
  - The _name_ of a file establishes a time when that name was valid and a
    containing relationship (capturing the file/directory enumeration). When
    files are moved a new name object gets created.  This also allows for files
    that have multiple names (**hard links**) and referential names (**soft
    links**).
  - The _hash_ of a file (or "stream" for NTFS where files are made up of zero
    or more "data streams") represents an alternative way of locating said file.
    I suspect this will become useful when we start looking at files across
    storage silos/domains, since that could be used to see causal flows (for
    example) as files are moved via a communications channel such as cloud
    storage, removable storage, or even e-mail.
  - The _location_ of a file.  That's really a property of the object itself,
    tying it to an actual instance.  Such information should be captured
* This is _indexing_ and we must always be cognizant of the fact the underlying
  object could be inaccessible (temporarily _or_ permanently.)

So, it sure sounds like I want somewhat loose coupling of the information. I am
also quite sure that I will get this wrong.

One upside to breaking apart names from file identity is that it should make
anonymizing the data easier.  Some information (e.g., partial name matches)
would be lost, but relationships that one _can_ find with anonymized data will
still support the underlying premise of my research (e.g., that this is useful)
since non-anonymous data should be _better_ than anonymous data.

Thus, I am proposing having the following distinct collections:

* Machine Collection - this is where machine specific information would be
  stored.  I haven't given too much thought as to how this should be organized,
  so I'll leave it to grow organically.  For now, at least, I'll likely just
  store some basic information.
* Storage Collection - this is where I'll define the boundaries of a specific
  storage silo.  Note that this will allow for:
  * Parent/child relationships: think partitions versus disk drives
  * Collective relationships: think RAID sets

  Again, I don't want to overthink this but I can see data that will be useful
  here, for example tying the physical device information to the logical device
  information ("gee /dev/sdb happens to be a Samsung 980 Pro 1TB SSD, Serial
  Number XXXYYYZZZ" or "drive q: happens to be a Lexar 32GB USB 3.0 storage
  device").
* Object Collection - this is where I'll put information about the objects
  themselves.  At a minimum this should consist of a _location_ - since I'm only
  indexing actual objects at some fixed location at a given point in time.
* Object Attributes - this is where I'll put information about the attributes
  associated with a given object.  These will identify the object with which the
  attributes are associated, some sort of timestamp, an identification of the
  source of the attributes, and then a list of attributes. The purpose of having
  a "source" is so we can figure out how to normalize the data.
* Name Collection - this is where I will put information that captures object
  names and associates them with a set of one or more objects.
* Activity Data Collection - this will capture "what happened" information.  I
  have discussed this data previously and I'll be generalizing from that model,
  which I will (re)-capture below.

## Records

I previously decided on a fairly generic structure for capturing activity data
that I would like to extend to all of these data types/sources.  One _reason_
for this is to make it at least possible to address the data normalization
problem.  Normalizing data is quite a large swamp: it is definitely a difficult
problem, but it is also a problem that is not terribly useful at this point in
my own work.  Since I am collecting data from a small set of sources I can focus
on doing as little data normalization at this point as possible.  However, I do
not want to disallow the possibility of extracting normalized data in the
future.  Thus, each record captured in the database will consist of:

* **Raw data**.  This is data in whatever format the original agent capturing the
  data chooses to capture it.
* **Agent Identifier**. This identifies _what_ agent it was that captured it.
  The idea is that this will allow post-hoc processing of information and
  extracting it into a normalized format that can be subsequently used.  I had
  originally thought of adding a version number there, but I don't know that it
  is really necessary to do so.  An agent that wants to have version numbering
  can include it in their own raw data.
* **Attributes**.  These are _always_ in normalized form.  I haven't defined
  what that form but I have not seen any overwhelmingly complex issues around
  this thus far so I'll charge ahead for now. What I would suggest are:
  * Timestamps in some canonical form from an agreed upon starting date.  The
    obvious ones from which to choose have all been used.  The choice is pretty
    much arbitrary.
  * Alphabet encodings in a mutually agreed format.  I'd suggest UTF-8 since
    that seems to have "won the war" (versus Windows NT's decision to go with
    Unicode-16.)
  * I'm sure there will be others, but for now, I'll leave them be, making
    choices as I go along.
  * Hash values will be SHA-512. I have made this choice because (1) they're
    less likely to collide than SHA-256; and (2) they're faster to compute than
    SHA-256.  The choice is fairly arbitrary though and I don't think it matters
    with respect to the focus of my work.

I'm _not_ going to define the format of that raw data.  I'll leave that to the
agent.  Agent Identifiers can just be UUIDs since they can be decentrally
created with minimal chance of collision. I expect to control the format of
attributes more carefully, choosing a particular format when appropriate.

## Data Model

Beyond the local drive indexing is the question of what the data model should
be.  I have less of a sense for this, but in general my thinking as of now is
that the data model should:

* Capture existing known relationships.  For example the obvious ones like
  "contained by" and/or "containing".  While the original motivation for this is
  the directory/file relationship, it should capture other containing
  relationships as well:
  * Storage silo.  For local drives that would be the logical volume.  For
    remote storage that likely associates with the exposed storage unit of the
    remote.  For example NFS would be the share, AFS would be the volume, Google
    Drive and Dropbox might be the account - they distinguish between personal
    storage, team storage, and enterprise storage (for example).
  * Hmm.  There have to be more but I'm drawing a blank at the moment.  So I'll
    leave this TBD.
* Allow surfacing "attributes" that can then be used to identify and capture
  additional new relationships.  I have suggested a few previously, but things
  like:
  * Files that have some common EA or alternate data stream.  This _seems_ to
    fall into the category of something that might be collected into a sparse
    index.
  * Files that have been associated with a particular action.  For example, if
    a human performs a search it seems like it could be beneficial to store the
    results of said search.  The classic example here would be "I performed a
    grep operation and found certain files."  I know that I find myself
    repeating searches.  Given that brute force search is _expensive_ (even
    within just a single storage silo) it seems reasonable to save the results
    (even if it is transient/temporary.)
  * Version relationships.  Arangodb does have explicit versions for documents
    so it might make sense to try and exploit that (though that doesn't preclude
    other models, does it.)

My general sense is that I am going to get this wrong.  Some of this stems from
my lack of experience using the tools and some of it is that I don't really know
what will turn out to be _important_.  So, I expect this will evolve and become
more specific over time.
