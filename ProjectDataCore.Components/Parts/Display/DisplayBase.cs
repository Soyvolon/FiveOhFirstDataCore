﻿using ProjectDataCore.Data.Structures.Model.Page;

namespace ProjectDataCore.Components.Parts.Display;

public class DisplayBase : ParameterBase
{
    protected class DisplayEditModel
	{
        public Guid Key { get; init; }
        public string? Label { get; set; }
        public string Property { get; set; }
        public bool StaticProperty { get; set; }
        public string? FormatString { get; set; }

        public DisplayEditModel(DisplayComponentSettings settings)
		{
            Key = settings.Key;
            Label = settings.Label;
            Property = settings.PropertyToEdit;
            StaticProperty = settings.StaticProperty;
            FormatString = settings.FormatString;
        }
	}

    [Parameter]
    public DisplayComponentSettings? ComponentData { get; set; }

    protected DisplayEditModel? EditModel { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (ComponentData is not null)
        {
            LoadScopedUser(ComponentData.UserScopeId);
            await LoadDisplayValueAsync();
        }
    }

    protected override async Task RemoveCurrentDisplay()
    {
        if (ComponentData is not null)
        {
            var res = await PageEditService.DeleteDisplayComponentAsync(ComponentData.Key);

            if (CallRefreshRequest is not null)
                await CallRefreshRequest.Invoke();
        }
    }

    protected override void StartEdit()
	{
        if (ComponentData is not null)
        {
            EditModel = new(ComponentData);
            StateHasChanged();
        }
	}

    protected override void CancelEdit()
	{
        EditModel = null;
        StateHasChanged();
	}

    protected override async Task SaveEdit()
    {
        if(EditModel is not null)
		{
            var res = await PageEditService.UpdateDisplayComponentAsync(EditModel.Key, x =>
            {
                x.Label = Optional.FromValue(EditModel.Label);
                x.PropertyToEdit = EditModel.Property;
                x.StaticProperty = EditModel.StaticProperty;
                x.FormatString = Optional.FromValue(EditModel.FormatString);
            });

            EditModel = null;

            if (CallRefreshRequest is not null)
                await CallRefreshRequest.Invoke();
		}
    }

    #region Parameter Scope
    protected override async Task LoadDisplayValueAsync()
    {
        if (ComponentData is not null)
        {
            if (ComponentData.StaticProperty)
            {
                LoadStaticProperty();
            }
            else
            {
                await LoadDynamicPropertyAsync();
            }
        }
    }

    protected override void LoadStaticProperty()
    {
        if (ScopedUser is not null && ComponentData is not null
            && ComponentData.PropertyToEdit is not null)
        {
            var typ = ScopedUser.GetType();
            var p = typ.GetProperty(ComponentData.PropertyToEdit);
            if (p is not null)
            {
                var val = p.GetValue(ScopedUser);

                var s = Convert.ToString(val);

                DisplayValue = string.Format(ComponentData.FormatString ?? "{0}", s);
            }
        }
    }

    protected override async Task LoadDynamicPropertyAsync()
    {
        // TODO
    }
    #endregion
}