using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StoreApp.Models.Base;

public enum Mode
{
    Insert,
    Update,
    Delete
}

public abstract class BusinessModel<T> : INotifyPropertyChanged
    where T : BusinessModel<T>
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // Optional: Helper to set property and raise event
    protected bool SetProperty<TValue>(ref TValue field, TValue value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    private bool isDeleted = false;
    public bool IsDeleted
    {
        get => isDeleted;
        set => SetProperty(ref isDeleted, value);
    }
    //public bool IsDeleted()
    //{
    //    return isDeleted;
    //}

    public void MarkAsDeleted()
    {
        isDeleted = true;
    }
    public void MarkAsNotDeleted()
    {
        isDeleted = false;
    }
    private int id;
    public int Id
    {
        get => id;
        set => SetProperty(ref id, value);
    }
    private Errors errors = new Errors();
    public Errors Errors
    {
        get => errors;
        set => SetProperty(ref errors, value);
    }

    public virtual bool Validate(Mode mode)
    {
        bool retVal = true;
        switch (mode)
        {
            case Mode.Insert:
                if (Id > 0)
                {
                    retVal = false;
                    throw new ArgumentException("Id should not be greater than zero.", nameof(Id));
                }
                break;
            case Mode.Update:
            case Mode.Delete:
                if (Id <= 0)
                {
                    retVal = false;
                    throw new ArgumentException("Id must be greater than zero.", nameof(Id));
                }
                break;
        }
        return retVal;
    }

    internal void AddError(string propertyName, string errorMessage)
    {
        errors.Add(propertyName, errorMessage);
    }
}

public class Errors : List<Error>
{
    public void Add(string propertName, string message)
    {
        Add(new Error { PropertyName = propertName, Message = message });
    }
    public void AddError(Error error)
    {
        if (error != null)
        {
            base.Add(error);
        }
    }
    public bool HasErrors()
    {
        return this.Any();
    }
}

public class Error : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // Optional: Helper to set property and raise event
    protected bool SetProperty<TValue>(ref TValue field, TValue value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    private string propertyName = string.Empty;
    public string PropertyName
    {
        get => propertyName;
        set => SetProperty(ref propertyName, value);
    }
    private string message = string.Empty;
    public string Message
    {
        get => message;
        set => SetProperty(ref message, value);
    }
}