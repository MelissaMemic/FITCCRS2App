// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'upsert_kriterij.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

KriterijUpsertRequest _$KriterijUpsertRequestFromJson(
        Map<String, dynamic> json) =>
    KriterijUpsertRequest(
      json['naziv'] as String,
      json['vrijednost'] as String,
      json['kategorijaId'] as int,
    );

Map<String, dynamic> _$KriterijUpsertRequestToJson(
        KriterijUpsertRequest instance) =>
    <String, dynamic>{
      'naziv': instance.naziv,
      'vrijednost': instance.vrijednost,
      'kategorijaId': instance.kategorijaId,
    };
