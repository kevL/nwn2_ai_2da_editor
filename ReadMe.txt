nwn2_ai_2da_editor
A HenchSpells.2da editor for TonyK's Companion and Monster AI 2.2

--
ver 1
2018 jun 23

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
integers they can cause conflicts when accessed by the CoreAI scripts.

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

--
General Description and Use

On the left is the spell-tree. The ID of each spell should correspond to its
SpellID in Spells.2da.

The editor is subdivided into 7 pages:
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
