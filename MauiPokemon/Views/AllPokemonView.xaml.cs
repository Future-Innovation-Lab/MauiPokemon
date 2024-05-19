using MauiPokemon.ViewModel;

namespace MauiPokemon.Views;

public partial class AllPokemonView : ContentPage
{
    public AllPokemonView(AllPokemonViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ((AllPokemonViewModel)BindingContext).OnAppearing();
    }
}