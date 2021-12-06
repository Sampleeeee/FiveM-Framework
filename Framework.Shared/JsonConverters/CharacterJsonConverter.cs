using System;
using Framework.Shared.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Framework.Shared.JsonConverters;

public class CharacterJsonConverter : JsonConverter
{
	public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
	{
		if ( value is not Character character ) return;

		writer.WriteStartObject();
		writer.WritePropertyName( "FirstName" );
		writer.WriteValue( character.FirstName );

		writer.WritePropertyName( "LastName" );
		writer.WriteValue( character.LastName );

		writer.WritePropertyName( "Gender" );
		writer.WriteValue( character.Gender );

		writer.WritePropertyName( "DateOfBirth" );
		writer.WriteValue( character.DateOfBirth );

		writer.WritePropertyName( "Cash" );
		writer.WriteValue( character.Cash );

		writer.WritePropertyName( "Bank" );
		writer.WriteValue( character.Bank );

		writer.WritePropertyName( "DirtyMoney" );
		writer.WriteValue( character.DirtyMoney );

		writer.WritePropertyName( "Hunger" );
		writer.WriteValue( character.Hunger );
		
		writer.WritePropertyName( "Thirst" );
		writer.WriteValue( character.Thirst );

		writer.WritePropertyName( "Thirst" );
		writer.WriteValue( character.Thirst );

		writer.WritePropertyName( "Height" );
		writer.WriteValue( character.Height );

		writer.WritePropertyName( "Weight" );
		writer.WriteValue( character.Weight );
	}

	public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
	{
		if ( objectType != typeof( Character ) ) return existingValue;

		var jObject = JObject.Load( reader );

		return new Character
		{
			DateOfBirth = DateTime.Parse( jObject.ReadFromJson<string>( "DateOfBirth" ) ),
			FirstName = jObject.ReadFromJson<string>( "FirstName" ),
			DirtyMoney = jObject.ReadFromJson<int>( "DirtyMoney" ),
			LastName = jObject.ReadFromJson<string>( "LastName" ),
			Gender = jObject.ReadFromJson<Gender>( "Gender" ),
			Hunger = jObject.ReadFromJson<int>( "Hunger" ),
			Thirst = jObject.ReadFromJson<int>( "Thirst" ),
			Height = jObject.ReadFromJson<int>( "Height" ),
			Weight = jObject.ReadFromJson<int>( "Weight" ),
			Cash = jObject.ReadFromJson<int>( "Cash" ),
			Bank = jObject.ReadFromJson<int>( "Bank" )
		};
	}

	public override bool CanConvert( Type objectType ) =>
		objectType == typeof( Character );
}