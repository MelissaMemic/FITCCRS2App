import 'package:json_annotation/json_annotation.dart';
import 'package:mobile_fitcc/Models/enums/gender.dart';

part 'user.g.dart';

@JsonSerializable(explicitToJson: true)
class User {
  int userId;
  String? firstName;
  String? lastName;
  String? username;
  Gender? gender; 
  DateTime? birthDate;
  String? image;
  String? email;
  String? webSite;
  String? phone;
  DateTime? createDate;

  User(
     this.userId,
    this.firstName,
    this.lastName,
    this.username,
    this.gender,
     this.birthDate,
    this.image,
    this.email ,
    this.webSite,
    this.phone,
     this.createDate
  );

  factory User.fromJson(Map<String, dynamic> json) => _$UserFromJson(json);

  Map<String, dynamic> toJson() => _$UserToJson(this);
}
