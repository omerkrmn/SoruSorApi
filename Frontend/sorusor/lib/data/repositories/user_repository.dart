import 'package:sorusor/data/datasources/remote_data_source.dart';
import 'package:sorusor/data/models/user_dto.dart';

class UserRepository {
  final RemoteDataSource remoteDataSource;

  UserRepository(this.remoteDataSource);

  Future<List<UserDto>> getSampleData(String endpoint) async {
    final json = await remoteDataSource.fetchData(endpoint);
    return json
        .map((item) => UserDto.fromJson(item as Map<String, dynamic>))
        .toList();
  }

  Future<void> postSampleData(String endpoint, UserDto data) async {
    await remoteDataSource.sendData(endpoint, {
      'userName': data.userName,
      'password': data.password,
      'nickName': data.nickName,
      'mail': data.mail
    });
  }
}
