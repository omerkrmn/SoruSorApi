import 'package:sorusor/data/models/user_dto.dart';
import 'package:sorusor/data/repositories/user_repository.dart';

class CreateUser {
  final UserRepository userRepository;

  CreateUser(this.userRepository);

  Future<void> execute(UserDto userDto) async {
    try {
      await userRepository.createUser(userDto);
    } catch (e) {
      print('Error in PostUserData: $e');
      throw Exception('Failed to post user data');
    }
  }
}
