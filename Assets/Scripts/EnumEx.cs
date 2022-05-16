using System;
using System.Collections.Generic;

namespace ScrollViewTest
{
    public static class EnumEx
    {
        public static IEnumerable<Enum> GetFlags( this Enum enumToCheck )
        {
            foreach( Enum value in Enum.GetValues( enumToCheck.GetType() ) )
                if( enumToCheck.HasFlag( value ) )
                    yield return value;
        }
    }

}
