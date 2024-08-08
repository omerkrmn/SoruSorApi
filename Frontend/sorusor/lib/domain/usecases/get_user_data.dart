import 'package:sorusor/data/models/user_dto.dart';
import 'package:sorusor/data/repositories/user_repository.dart';

class GetUserData {
  final UserRepository userRepository;

  GetUserData(this.userRepository);

  Future<List<UserDto>> execute(String endpoint) async {
    try {
      return await userRepository.getSampleData(endpoint);
    } catch (e) {
      print('Error in GetUserData: $e');
      throw Exception('Failed to load user data');
    }
  }
}
