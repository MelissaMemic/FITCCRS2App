

import 'package:json_annotation/json_annotation.dart';
part 'upsert_kriterij.g.dart';

@JsonSerializable()
class KriterijUpsertRequest {
   String naziv;
   String vrijednost;
   int kategorijaId;


  KriterijUpsertRequest(
    this.naziv,
    this.vrijednost,
    this.kategorijaId);

  factory KriterijUpsertRequest.fromJson(Map<String, dynamic> json) =>
      _$KriterijUpsertRequestFromJson(json);

  Map<String, dynamic> toJson() => _$KriterijUpsertRequestToJson(this);
}
