// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'insert_komisija.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

KomisijaInsertRequest _$KomisijaInsertRequestFromJson(
        Map<String, dynamic> json) =>
    KomisijaInsertRequest(
      json['ime'] as String?,
      json['prezime'] as String?,
      json['email'] as String?,
      $enumDecode(_$UlogeKomisijeEnumMap, json['role']),
      json['kategorijaId'] as int?,
    );

Map<String, dynamic> _$KomisijaInsertRequestToJson(
        KomisijaInsertRequest instance) =>
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
