import 'package:sorusor/core/services/api_service.dart';

class RemoteDataSource {
  final ApiService apiService;

  RemoteDataSource(this.apiService);

  Future<List<dynamic>> fetchData(String endpoint) async {
    final response = await apiService.get(endpoint);
    return response as List<dynamic>;
  }

  Future<Map<String, dynamic>> sendData(
      String endpoint, Map<String, dynamic> data) async {
    return await apiService.post(endpoint, data);
  }
}
