import 'package:sorusor/data/datasources/remote_data_source.dart';
import 'package:sorusor/data/models/user_dto.dart';

class UserRepository {
  final RemoteDataSource remoteDataSource;

  UserRepository(this.remoteDataSource);

  Future<List<UserDto>> getAllUsers() async {
    var endpoint = "user/CreateOneUser";
    final json = await remoteDataSource.fetchData(endpoint);
    return json
        .map((item) => UserDto.fromJson(item as Map<String, dynamic>))
        .toList();
  }

  Future<void> createUser(UserDto data) async {
    var endpoint = "user/CreateOneUser";
    await remoteDataSource.sendData(endpoint, {
      'userName': data.userName,
      'password': data.password,
      'nickName': data.nickName,
      'mail': data.mail
    });
  }
}
