import { BloodGroup } from "./bloodGroup";

export interface Patient {
    patientId: number;
    firstName: string;
    lastName: string;
    phoneNumber: string;
    email: string;
    dateOfBirth: Date;
    gender: string;
    bloodGroupId?: number;
    bloodGroup?: BloodGroup;
}
