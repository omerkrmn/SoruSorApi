import 'package:sorusor/core/constants/application_constant.dart';
import 'package:sorusor/core/services/api_service.dart';

class RemoteDataSource {
  static final RemoteDataSource _instance =
      RemoteDataSource._internal(ApiService(ApplicationConstant.API_URL));
  final ApiService apiService;

  RemoteDataSource._internal(this.apiService);

  factory RemoteDataSource(ApiService apiService) {
    return _instance;
  }

  Future<List<dynamic>> fetchData(String endpoint) async {
    final response = await apiService.get(endpoint);
    return response as List<dynamic>;
  }

  Future<Map<String, dynamic>> sendData(
      String endpoint, Map<String, dynamic> data) async {
    return await apiService.post(endpoint, data);
  }

  Future<Map<String, dynamic>> updateData(
      String endpoint, Map<String, dynamic> data) async {
    return await apiService.put(endpoint, data);
  }
}
