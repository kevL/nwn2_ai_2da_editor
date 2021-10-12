using System;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Struct that holds data of each spell in HenchSpells.2da.
	/// </summary>
	/// <remarks>This data can change when the Apply-btn is clicked (but only if
	/// the spell-data has in fact been changed ofc).
	/// 
	/// 
	/// This is the data that gets saved to file on File|Save.</remarks>
	struct Spell
	{
		public int id;
		public string label;

		public int   spellinfo;
		public int   targetinfo;
		public float effectweight;
		public int   effecttypes;
		public int   damageinfo;
		public int   savetype;
		public int   savedctype;

		// NOTE: The following fields are not saved to file ->

		/// <summary>
		/// bitwise int that holds flags for changed fields (also colors the
		/// tree-node red if not 0)
		/// </summary>
		public int differ;

		/// <summary>
		/// boolean used (along with the differ) to warn if there is modified
		/// data when exiting the app (also colors the tree-node blue if true).
		/// Set true by the Apply buttons (on local spell or by global
		/// edit-operation) or by inserting labels; cleared by saving
		/// HenchSpells.2da
		/// </summary>
		public bool isChanged;
	}

	/// <summary>
	/// Struct that holds changed data of any spell that has been modified in
	/// the editor.
	/// </summary>
	/// <remarks>These structs get created and deleted on-the-fly as stuff
	/// changes in the editor.</remarks>
	struct SpellChanged
	{
		public int   spellinfo;
		public int   targetinfo;
		public float effectweight;
		public int   effecttypes;
		public int   damageinfo;
		public int   savetype;
		public int   savedctype;
	}


	/// <summary>
	/// Struct that holds data of each race in HenchRacial.2da.
	/// </summary>
	/// <remarks>This data can change when the Apply-btn is clicked (but only if
	/// the race-data has in fact been changed ofc).
	/// 
	/// 
	/// This is the data that gets saved to file on File|Save.</remarks>
	struct Race
	{
		public int id;
		public string label;

		public int flags;
		public int feat1;
		public int feat2;
		public int feat3;
		public int feat4;
		public int feat5;

		// NOTE: The following fields are not saved to file ->

		/// <summary>
		/// bitwise int that holds flags for changed fields (also colors the
		/// tree-node red if not 0)
		/// </summary>
		public int differ;

		/// <summary>
		/// boolean used (along with the differ) to warn if there is modified
		/// data when exiting the app (also colors the tree-node blue if true).
		/// Set true by the Apply buttons (on local race or by global
		/// edit-operation) or by inserting labels; cleared by saving
		/// HenchRacial.2da
		/// </summary>
		public bool isChanged;
	}

	/// <summary>
	/// Struct that holds changed data of any race that has been modified in
	/// the editor.
	/// </summary>
	/// <remarks>These structs get created and deleted on-the-fly as stuff
	/// changes in the editor.</remarks>
	struct RaceChanged
	{
		public int flags;
		public int feat1;
		public int feat2;
		public int feat3;
		public int feat4;
		public int feat5;
	}


	/// <summary>
	/// Struct that holds data of each class in HenchClasses.2da.
	/// </summary>
	/// <remarks>This data can change when the Apply-btn is clicked (but only if
	/// the class-data has in fact been changed ofc).
	/// 
	/// 
	/// This is the data that gets saved to file on File|Save.</remarks>
	struct Class
	{
		public int id;
		public string label;

		public int flags;
		public int feat1;
		public int feat2;
		public int feat3;
		public int feat4;
		public int feat5;
		public int feat6;
		public int feat7;
		public int feat8;
		public int feat9;
		public int feat10;
		public int feat11;

		// NOTE: The following fields are not saved to file ->

		/// <summary>
		/// bitwise int that holds flags for changed fields (also colors the
		/// tree-node red if not 0)
		/// </summary>
		public int differ;

		/// <summary>
		/// boolean used (along with the differ) to warn if there is modified
		/// data when exiting the app (also colors the tree-node blue if true).
		/// Set true by the Apply buttons (on local class or by global
		/// edit-operation) or by inserting labels; cleared by saving
		/// HenchClasses.2da
		/// </summary>
		public bool isChanged;
	}

	/// <summary>
	/// Struct that holds changed data of any class that has been modified in
	/// the editor.
	/// </summary>
	/// <remarks>These structs get created and deleted on-the-fly as stuff
	/// changes in the editor.</remarks>
	struct ClassChanged
	{
		public int flags;
		public int feat1;
		public int feat2;
		public int feat3;
		public int feat4;
		public int feat5;
		public int feat6;
		public int feat7;
		public int feat8;
		public int feat9;
		public int feat10;
		public int feat11;
	}
}
