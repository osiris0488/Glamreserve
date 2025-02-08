using System.Threading.Tasks;

public class AuthService
{
	private readonly HttpClient _http;
	private readonly NavigationManager _navigation;
	private readonly ILocalStorageService _localStorage;

	public AuthService(HttpClient http, NavigationManager navigation, ILocalStorageService localStorage)
	{
		_http = http;
		_navigation = navigation;
		_localStorage = localStorage;
	}

	public async Task<bool> Login(LoginRequest request)
	{
		var response = await _http.PostAsJsonAsync("api/auth/login", request);
		if (!response.IsSuccessStatusCode) return false;

		var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
		await _localStorage.SetItemAsync("authToken", loginResponse.Token);
		return true;
	}

	public async Task Logout()
	{
		await _localStorage.RemoveItemAsync("authToken");
		_navigation.NavigateTo("/login");
	}
}
