using System.ComponentModel;
using Framework.Shared.JsonConverters;
using Newtonsoft.Json;

namespace Framework.Shared.Items.Bases;

[JsonConverter( typeof( BaseItemJsonConverter ) )]
[TypeConverter( typeof( BaseItemTypeConverter ) )]
public abstract class BaseItem
{
    public string UniqueId => GetType().FullName;
    
    public abstract string Name { get; }
    public abstract string Description { get; }

    public virtual int Weight => 1;
    public virtual int StackSize => 1;

    public virtual bool Illegal => false;
    public virtual bool PremiumOnly => false;
    public virtual string ImageUrl => string.Empty;

    public override bool Equals( object obj ) =>
        this.UniqueId == ( obj as BaseItem )?.UniqueId;
}