using System;
using System.ComponentModel;
using CitizenFX.Core;
using Framework.Shared.Inventory;
using Framework.Shared.Jobs;
using Framework.Shared.JsonConverters;
using Newtonsoft.Json;

namespace Framework.Shared;

[JsonConverter( typeof( CharacterJsonConverter ) )]
public class Character
{
    public Player Player { get; set; }
    public Ped Ped => Player.Character;

    #region Name

    public string FullName => $"{FirstName} {LastName}";

    private string _firstName;
    public string FirstName
    {
        get => _firstName;
        set => _firstName = value;
    }

    private string _lastName;

    public string LastName
    {
        get => _lastName;
        set => _lastName = value;
    }

    #endregion
    #region Money
    
    private int _cash;
    public int Cash
    {
        get => _cash;
        set => _cash = value;
    }

    private int _bank;
    public int Bank
    {
        get => _bank;
        set => _bank = value;
    }

    private int _dirtyMoney;
    public int DirtyMoney
    {
        get => _dirtyMoney;
        set => _dirtyMoney = value;
    }

    #endregion
    #region Vitals

    private int _hunger;

    public int Hunger
    {
        get => _hunger;
        set => _hunger = value;
    }

    private int _thirst;

    public int Thirst
    {
        get => _thirst;
        set => _thirst = value;
    }

    #endregion
    #region Character Information

    private DateTime _dateOfBirth;
    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        set => _dateOfBirth = value;
    }
    
    public int Age => DateTime.Now.Year - DateOfBirth.Year;

    private Gender _gender;
    public Gender Gender
    {
        get => _gender;
        set => _gender = value;
    }

    private int _height;

    /// <summary>
    /// The height of the character, in inches
    /// </summary>
    public int Height
    {
        get => _height;
        set => _height = value;
    }

    private int _weight;

    /// <summary>
    /// The weight of the character, in pounds
    /// </summary>
    public int Weight
    {
        get => _weight;
        set => _weight = value;
    }

    #endregion
    #region Jobs
    
    public BaseJob Job { get; set; }
    public BaseJobGrade JobGrade { get; set; }
    
    #endregion

    public ItemInventory ItemInventory { get; set; }

    public Character() { }
    
    public Character( Player pl, ItemInventory inventory = null )
    {
        Player = pl;

        ItemInventory = inventory ?? new ItemInventory( this );
        ItemInventory.Owner = this;
    }
}

public enum Gender
{
    [Description("Male")] Male,
    [Description("Female")] Female
}