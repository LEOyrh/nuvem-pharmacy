export interface PharmacyDto {
    pharmacyId: number | undefined,
    name: string,
    address: string,
    city: string,
    state: string,
    zip: string,
    numberOfFilledPrescriptions: number,
    createdDate: Date,
    updatedDate: Date
}