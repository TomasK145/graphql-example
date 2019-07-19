using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class GenreType : EnumerationGraphType<Data.Genre>
    {
        public GenreType()
        {
            Name = "Genre";
            Description = "The genre of book";
        }
    }
}
