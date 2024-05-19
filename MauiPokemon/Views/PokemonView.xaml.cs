using MauiPokemon.ViewModel;

namespace MauiPokemon.Views;

public partial class PokemonView : ContentPage
{
	public PokemonView(PokemonViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ((PokemonViewModel)BindingContext).OnAppearing();
    }
}