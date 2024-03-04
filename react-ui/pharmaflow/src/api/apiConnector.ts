import axios, { AxiosError, AxiosResponse } from "axios";
import { PharmacyDto } from "../models/pharmacyDto";
import { API_BASE_URL } from "../config"

const apiConnector = {

    getPharmacies: async (): Promise<PharmacyDto[]> => {
        try {
            const response: AxiosResponse<PharmacyDto[]> =
                await axios.get(`${API_BASE_URL}/Pharmacy`);
            const pharmacies = response.data.map(pharmacy => ({
                ...pharmacy
            }));
            return pharmacies;
        } catch (error) {
            const e = error as AxiosError; // Cast the error to the AxiosError type
            if (e.response) {
                // Now TypeScript knows that e.response exists and is of type AxiosResponse
                console.error(e.response.data);
                console.error(e.response.status);
                console.error(e.response.headers);
            } else {
                // Handle the case where the error does not have a response (network error, timeout, etc.)
                console.error(e.message);
            }
            throw e; // If you still want to throw the error after logging

        }
    },

    getPharmacyById: async (pharmacyId: string): Promise<PharmacyDto | undefined> => {
        try {

            const response = await axios.get<PharmacyDto>(`${API_BASE_URL}/Pharmacy/${[pharmacyId]}`);
            return response.data;
        } catch (error) {
            console.log(error);
            throw error;
        }
    },

    createPharmacy: async (pharmacy: PharmacyDto): Promise<void> => {
        try {
            await axios.post<number>(`${API_BASE_URL}/Pharmacy`, pharmacy)
        } catch (error) {
            console.log(error);
            throw error;
        }
    },

    editPharmacy: async (pharmacy: PharmacyDto): Promise<void> => {
        try {
            await axios.put<number>(`${API_BASE_URL}/Pharmacy/${pharmacy.pharmacyId}`, pharmacy)
        } catch (error) {
            console.log(error);
            throw error;
        }
    },

    deletePharmacy: async (pharmacyId: number): Promise<void> => {
        try {
            await axios.delete<number>(`${API_BASE_URL}/Pharmacy/${pharmacyId}`)
        } catch (error) {
            console.log(error);
            throw error;
        }
    }
}

export default apiConnector;