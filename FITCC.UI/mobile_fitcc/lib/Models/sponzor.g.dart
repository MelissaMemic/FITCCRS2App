// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'sponzor.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Sponzor _$SponzorFromJson(Map<String, dynamic> json) => Sponzor(
      json['sponzorId'] as int,
      json['naziv'] as String,
      json['godina'] as int?,
      json['skategorijeId'] as int,
      json['kategorijaId'] as int?,
    );

Map<String, dynamic> _$SponzorToJson(Sponzor instance) => <String, dynamic>{
      'sponzorId': instance.sponzorId,
      'naziv': instance.naziv,
      'godina': instance.godina,
      'skategorijeId': instance.skategorijeId,
      'kategorijaId': instance.kategorijaId,
    };
