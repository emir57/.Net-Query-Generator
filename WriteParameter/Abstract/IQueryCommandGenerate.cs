namespace WriteParameter.Abstract
{
    public interface IQueryCommandGenerate
    {
        string GenerateInsertQuery();
        string GenerateUpdateQuery();
        string GenerateDeleteQuery();
    }
}
