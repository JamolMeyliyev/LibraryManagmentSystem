namespace LibraryManagmentSystem.LogicLayer;

public class NotFoundException:Exception
{
    public NotFoundException(string message) : base(message) { }
}
