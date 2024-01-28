namespace LibraryManagmentSystem.LogicLayer;
public class EntityExistsException:Exception
{
    public EntityExistsException(string message) : base(message) { }
}
