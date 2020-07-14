nwn2_ai_2da_editor
A Hench*.2da editor for TonyK's Companion and Monster AI 2.2

- not entirely compatible with the SoZ AI but it should cut mustard

--
ver 1.3.0
2018 dec 10

--
Overview

First of all what this is not: a 2da row-editor. It does not create, delete, or
copy 2da rows. It is, rather, a bitwise editor (largely) for three specific
2da-files: HenchSpells.2da, HenchRacial.2da, and HenchClasses.2da. Most of the
entries in those files are integers that are used by the CoreAI in a bitwise
way; this application reads and writes the bits of those integers.

If you want to add/delete rows from the Hench* 2da files it should be done with
a text-editor or preferably a 2da row-editor. Only the row ID # is required,
followed by blank fields "****" in the other columns, so that it's a valid 2da-
file. This editor should then be able to open such a file.

Note that if you're adding rows to HenchSpells.2da their IDs need to be kept in
sync with Spells.2da, if adding rows to HenchRacial.2da they need to be kept in
sync with RacialSubtypes.2da, and if to HenchClasses.2da ... Classes.2da.

ps. The CoreAI for Neverwinter Nights 2 is contained in scripts that start with
"hench".

--
Requirements

Windows w/ .NET 3.5 (installed and/or enabled)
See: https://docs.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows-10
If you're running the toolset okay then there should be no worries about that.
Although the toolset technically uses .NET 2.0, a computer that's not a relic
ought have it covered w/ .NET 3.5 already.

This is a standalone application. It requires no ini-files nor does it read or
write to the Windows Registry.

GIT repo: https://github.com/kevL/nwn2_ai_2da_editor

Note for developers: A logfile.txt will be created by debug-builds only.

--
Manifest

nwn2_ai_2da_editor.exe - the executable
ReadMe.txt - this doc

--
Prologue

I dread trying to write this.

This application exposes all the bits that are available to the CoreAI via
HenchSpells.2da. At least I think it does; if it doesn't please let me know and
I'll expose those also.

The CoreAI scripts determine what uncontrolled characters/creatures are going to
do. By far the most complicated routines deal with deciding what spells to cast.
Data about spells and, by extension, feats is stored in HenchSpells.2da -- the
data is stored in integers that are composed of bitwise values.

This allows a lot of data to be stored in little space, and operations can be
performed quickly.

But not only does that make the data complicated to deal with -- and this is the
part I dread -- several of the integers have been multi-purposed, so that
'DamageInfo' isn't necessarily about damage-info, nor are 'SaveType' and
'SaveDCType' necessarily about saves or save-DCs. 'EffectTypes' is also
multi-purposed into beneficial and detrimental effects, and like the other
integers this can cause conflicts when accessed by the CoreAI scripts.

Since resolving potential issues would involve tracing every bit through the
CoreAI scripts, I adopted a policy of exposing every bit that's possible even
though they can and do overlap/conflict when their constants appear in different
bit-groups. To give an easy example, a spell can be assigned the effect-type

HENCH_EFFECT_TYPE_AC_INCREASE (beneficial)

which is the same bit as

HENCH_EFFECT_TYPE_ENTANGLE (detrimental)

and the CoreAI will hopefully figure out which meaning is intended based on
other data for the spell. In the above example its meaning is relatively
straightforward since it's based on the 'SpellInfo' spelltype value. But other
bit-conflicts are not as obvious.

So ... what you should see in the editor are groups that are colored default
(usually black text but it depends on your OS settings) -- always okay to change
-- green if the integer should be thought of as of that group and should be okay
to change, or red if the integer should NOT be thought of as of that group and
so should be left alone.

Note: 'that group' is usually based on the 'SpellInfo' spelltype value but not
always.

For another example, the 'SaveType' bit

HENCH_SPELL_SAVE_TYPE_NOTSELF_FLAG (cannot be cast on or does not affect the caster)

can be and more or less is grabbed by the AI willy-nilly. Yet the other bits in
its group seem to be used for attack-type spells exclusively.

Again I've designed the aesthetics of the editor to show bit-variables as green
if they are generally acceptable to toggle on/off, and red if they are not. If
you toggle a red-variable it can (and usually does) screw up the integer. But
since I have not confidently traced all combinations or usages in the scripts,
all possibilities have been kept exposed for tinkering -- but I suggest that you
actually look through the CoreAI scripts to see how a particular bit-value is
used before doing anything haphazard ....

AT PRESENT THE COLORS ARE MERELY GUIDELINES. They are still inaccurate and I
hope to put further efforts toward this aspect of the editor. The most egregious
case is the 'DamageInfo' page: the Detrimental and Beneficial groups often show
both green, which is a contradiction on the face of it. Further, groups that do
not make sense to use at all are often still displayed in green ....

So play around until you can weave your way though it -- just don't take the
colors too seriously yet.

--
General Description and Use

On the left is the spell-tree. The ID of each spell should correspond to its
SpellID in Spells.2da.

The editor divides HenchSpells.2da into 7 pages:
SpellInfo
TargetInfo
EffectWeight
EffectTypes
DamageInfo
SaveType
SaveDCType

Those correspond to the columns in HenchSpells.2da. Each of them boils down to
an integer, except EffectWeight which is a float.

The cached value is displayed on the reset button on each page. The cached value
is updated by clicking the "apply this spell's data" button at the bottom of
each page. If the cache is different than the currently modified value, its text
is displayed in red. Clicking apply should change its color to black (or your OS
default) to indicate that the cache has been updated to current.

The node on the spell-tree to the left will change to red if the cache is dirty
(ie, there are unapplied modifications) and then to blue if any changed data has
been applied to the spell.

Once applied, spell-data can no longer be reset to its original state. There is
no undo.

Beneath the reset button is the current value of the integer (or float for
EffectWeight). It can be changed in the textbox, but this isn't recommended
(except for EffectWeight) -- the point of the editor is in fact to make such
changes with much less hassle.

To the right of the reset button is the current value in both hexadecimal and
binary. To the right of those is a button that will zero the current value.

The body of each page is comprised of various bit-groupings that are relevant to
the integer. The labels of the groups are prefixed with their bit-masks in
hexadecimal; if you read bits, this can help identify potential conflicts
between bit-groups (discussed above).

IMPORTANT: Do not leave a text-field blank -- put in a "0" at least. I have not
implemented error-checking for that so it could leave the editor in an uncertain
state if a text-field is left completely blank. Also, don't put silly characters
into text-fields, use digits only (negative values may be allowed, depending on
if it makes sense, and a decimal-point for float values is allowed). If values
appear to go screwy, try selecting a different spell-node and re-selecting the
spell you're working with -- that ought refresh the fields while preserving your
current modifications.

Saving to file will ask to commit any unapplied modifications (ie, only
legitimately cached data will get saved). A successful save will change the
color of any blue spell-nodes back to the default color. Spells with modified
data will remain red however.

--
TODO: Describe exactly what all the bits do.

--
Tips

1. A spell does not have to be described exactly for the AI to use it (many are
in fact not exactly detailed by HenchSpells.2da -- and it wouldn't be hard to
design a new spell that actually can't be detailed exactly). The spells Stone
Body and Iron Body, for example, are given the spelltype

HENCH_SPELL_INFO_SPELL_TYPE_POLYMORPH

but of course neither is a real Polymorph spell -- I don't know why, you'd have
to trace the spelltype through the core scripts and get a gist of why those
spells should be treated as Polymorphs (it could be related to the increased
spell-failure which might hint to the AI not cast it on arcane spellcasters).
Further, neither has the bit flagged

HENCH_AC_CHECK_MOVEMENT_SPEED_DECREASE

yet both spells impose a 50% speed reduction. So, rather, think that what you're
doing in the editor is -- not describing a spell exactly -- but simply making
suggestions about what sorts of things should be considered regarding its use.

You could even get clever and deliberately misrepresent a spell to induce the AI
to use it differently.

2. The editor is not able to add or delete rows in the 2das. So to add a new
spell/race/class it needs to be added to the 2da itself with your favorite 2da-
or text-editor before opening it in this app. Do NOT use double-quotes at all
since I haven't implemented code that deals with double-quotes; the editor will
(or ought) rather error-out if it finds any. A new row needs only its row # in
the first column, followed by "****" fields in the following columns to be
valid (although providing a label for rows in HenchSpells.2da is helpful of
course).

3. CoreAI version. The so-called CoreAI Version is actually version-data that is
held in each entry. The default value in the CoreAI is "22". The version will be
checked automatically by the editor when a 2da gets loaded. If it's a blank
spell-entry then no version is assigned. But if it's a race- or class-entry then
the default version is assigned even if the entry is otherwise blank. This is
done to maintain consistency with what I see in the Hench*.2da files already.

Version-data can be changed under Options|Set CoreAI version. It is not
suggested to ever do so unless you've looked at the CoreAI scripts and have a
reasonable degree of confidence about what it does.

--
Concerning HenchRacial and HenchClasses Info

The data in HenchRacial.2da and HenchClasses.2da is much less complicated than
that in HenchSpells.2da. When either of the former is loaded in the editor, only
the first tab contains necessary information while the subsequent pages hold
data for FeatSpells - Feat information that is relevant to the Race or Class.

The "has FeatSpells" checkbox must be toggled on for the AI to make use of any
FeatSpells that are defined on the subsequent pages.

Note that, unlike HenchSpells, the HenchRacial and HenchClasses 2das do not
contain label-information. The editor can get de jure labels out of
RacialSubtypes.2da and Classes.2da respectively, however; in the Options menu
choose either or both "path RacialSubtypes.2da" and "path Classes.2da" and point
the dialog that appears to the appropriate 2da. The node-tree on the left of the
editor should fill-in with corresponding labels for loaded (Sub)Races/Classes.

If a check appears beside a "path" menuitem, it means that label-data of that
type is currently loaded. Simply uncheck the item to clear the labels (if you
pathed to the wrong 2da or whatever). The check beside the item should disappear
allowing new label-data to be loaded if you wish.

That is not a robust mechanism -- it's your responsibility, not mine or this
application's -- but it is a binding requirement for the AI to work correctly.
The row IDs of Spells.2da need to be kept in sync with the rows of
HenchSpells.2da, and the row IDs of RacialSubtypes.2da and Classes.2da need to
be kept in sync with HenchRacial.2da and HenchClasses.2da respectively.

By the way, under Options you'll also see "path Spells.2da" and "path Feat.2da".
If you point their dialogs to Spells.2da and Feat.2da respectively, labels for
any spell- and feat-IDs should also appear in the editor.

Unlike the paths for RacialSubtypes and Classes, any labels for spells and feats
do not refresh automatically in the editor. Simply click a different node on
the node-tree (on the left side of the editor) and click back to the entry that
you're working on, or simply toggle a bit on and off again, and any loaded
spell/feat labels should then display.

Note that the label-data is not stored between runs of the editor; it goes
~poof~ when the editor closes. (I don't want to deal with config-files.)

The above instructions assume that RacialSubtypes.2da, Classes.2da, Spells.2da,
and Feat.2da have been broken out of the NwN2 installation-folder. Tip: Copy
those four 2das along with working copies of the Hench*.2da files to a scratch-
folder (I use the "nwn2_ai_2da_editor" folder itself) for ease and convenience;
then copy any edited hench-files back to where they ought go when required. It's
sort of up to you to understand how this can work as a back-up mechanism also.

Did I mention always make back-ups before editing the Hench*.2da files ....

--
Option: insert spell labels

HenchSpells.2da could or not have a column that's titled "Label". The 2das that
ship with NwN2 do not, nor do those in TonyK's Companion and Monster AI. Pain's
Neverworker app, however, can output HenchSpells.2da with a "Label" column for
readability; it is not used by NwN2 itself. This editor can open and save either
format of HenchSpells.2da, further if Spells.2da has been pathed, 'insert spell
labels' under Options can copy and insert the labels from Spells.2da. Note that
the editor will create a "Label" column regardless - so it's recommended to
insert labels and Save (after backing up the file first) else the previously
missing column will simply be filled with "****" fields.
