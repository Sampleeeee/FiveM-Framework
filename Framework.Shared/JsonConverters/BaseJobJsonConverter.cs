using System;
using System.ComponentModel;
using System.Globalization;
using Framework.Shared.Extensions;
using Framework.Shared.Items.Bases;
using Framework.Shared.Jobs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Framework.Shared.JsonConverters;

public class BaseJobJsonConverter : JsonConverter
{
    public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
    {
        if ( value is not BaseJob job ) return;

        writer.WriteStartObject();

        writer.WritePropertyName( "UniqueId" );
        writer.WriteValue( job.UniqueId );

        writer.WriteEndObject();
    }

    public override object ReadJson( JsonReader reader, Type objectType, object existingValue,
        JsonSerializer serializer )
    {
        if ( objectType != typeof( BaseJob ) ) return existingValue;

        var jObject = JObject.Load( reader );
        return Utility.GetJob( jObject.ReadFromJson<string>( "UniqueId" ) );
    }

    public override bool CanConvert( Type objectType ) =>
        objectType == typeof( BaseJob );
}

public class BaseJobTypeConverter : TypeConverter
{
    public override bool CanConvertFrom( ITypeDescriptorContext context, Type sourceType ) =>
        sourceType == typeof( string );

    public override bool CanConvertTo( ITypeDescriptorContext context, Type sourceType ) =>
        sourceType == typeof( string );

    public override object ConvertTo( ITypeDescriptorContext context, CultureInfo culture, object value,
        Type destinationType )
    {
        if ( destinationType != typeof( string ) ) return null;
        return value is not BaseJob job ? null : job.UniqueId;
    }


    public override object ConvertFrom( ITypeDescriptorContext context, CultureInfo culture, object value )
    {
        return value is not string val ? null : Utility.GetJob( val );
    }
}

public class BaseJobGradeJsonConverter : JsonConverter
{
    public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
    {
        if ( value is not BaseJobGrade grade ) return;

        writer.WriteStartObject();

        writer.WritePropertyName( "UniqueId" );
        writer.WriteValue( grade.UniqueId );

        writer.WriteEndObject();
    }

    public override object ReadJson( JsonReader reader, Type objectType, object existingValue,
        JsonSerializer serializer )
    {
        if ( objectType != typeof( BaseJobGrade ) ) return existingValue;

        var jObject = JObject.Load( reader );
        return Utility.GetJobGrade( jObject.ReadFromJson<string>( "UniqueId" ) );
    }

    public override bool CanConvert( Type objectType ) =>
        objectType == typeof( BaseJobGrade );
}

public class BaseJobGradeTypeConverter : TypeConverter
{
    public override bool CanConvertFrom( ITypeDescriptorContext context, Type sourceType ) =>
        sourceType == typeof( string );

    public override bool CanConvertTo( ITypeDescriptorContext context, Type sourceType ) =>
        sourceType == typeof( string );

    public override object ConvertTo( ITypeDescriptorContext context, CultureInfo culture, object value,
        Type destinationType )
    {
        if ( destinationType != typeof( string ) ) return null;
        return value is not BaseJobGrade grade ? null : grade.UniqueId;
    }
    
    public override object ConvertFrom( ITypeDescriptorContext context, CultureInfo culture, object value )
    {
        return value is not string val ? null : Utility.GetJobGrade( val );
    }
}