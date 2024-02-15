// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

User _$UserFromJson(Map<String, dynamic> json) => User(
      json['userId'] as int,
      json['firstName'] as String?,
      json['lastName'] as String?,
      json['username'] as String?,
      $enumDecodeNullable(_$GenderEnumMap, json['gender']),
      json['birthDate'] == null
          ? null
          : DateTime.parse(json['birthDate'] as String),
      json['image'] as String?,
      json['email'] as String?,
      json['webSite'] as String?,
      json['phone'] as String?,
      json['createDate'] == null
          ? null
          : DateTime.parse(json['createDate'] as String),
    );

Map<String, dynamic> _$UserToJson(User instance) => <String, dynamic>{
      'userId': instance.userId,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'username': instance.username,
      'gender': _$GenderEnumMap[instance.gender],
      'birthDate': instance.birthDate?.toIso8601String(),
      'image': instance.image,
      'email': instance.email,
      'webSite': instance.webSite,
      'phone': instance.phone,
      'createDate': instance.createDate?.toIso8601String(),
    };

const _$GenderEnumMap = {
  Gender.male: 0,
  Gender.female: 1,
};
