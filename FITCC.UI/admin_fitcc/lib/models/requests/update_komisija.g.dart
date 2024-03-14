// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'update_komisija.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

KomisijaUpdateRequest _$KomisijaUpdateRequestFromJson(
        Map<String, dynamic> json) =>
    KomisijaUpdateRequest(
      json['ime'] as String?,
      json['prezime'] as String?,
      json['email'] as String?,
      $enumDecode(_$UlogeKomisijeEnumMap, json['role']),
      json['kategorijaId'] as int?,
    );

Map<String, dynamic> _$KomisijaUpdateRequestToJson(
        KomisijaUpdateRequest instance) =>
    <String, dynamic>{
      'ime': instance.ime,
      'prezime': instance.prezime,
      'email': instance.email,
      'role': _$UlogeKomisijeEnumMap[instance.role]!,
      'kategorijaId': instance.kategorijaId,
    };

const _$UlogeKomisijeEnumMap = {
  UlogeKomisije.clan: 0,
  UlogeKomisije.predsjednik: 1,
};
