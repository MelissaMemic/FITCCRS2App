// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'komisija.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Komisija _$KomisijaFromJson(Map<String, dynamic> json) => Komisija(
      json['komisijaId'] as int,
      json['ime'] as String,
      json['prezime'] as String,
      json['email'] as String,
      $enumDecode(_$UlogeKomisijeEnumMap, json['role']),
      json['kategorija'] == null
          ? null
          : Kategorija.fromJson(json['kategorija'] as Map<String, dynamic>),
      json['kategorijaId'] as int,
    );

Map<String, dynamic> _$KomisijaToJson(Komisija instance) => <String, dynamic>{
      'komisijaId': instance.komisijaId,
      'kategorijaId': instance.kategorijaId,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'email': instance.email,
      'role': _$UlogeKomisijeEnumMap[instance.role]!,
      'kategorija': instance.kategorija?.toJson(),
    };

const _$UlogeKomisijeEnumMap = {
  UlogeKomisije.clan: 0,
  UlogeKomisije.predsjednik: 1,
};
