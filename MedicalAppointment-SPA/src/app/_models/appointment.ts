import { Department } from "./department";
import { Doctor } from "./doctor";
import { Patient } from "./patient";

export interface Appointment {
    appointmentId: number;
    appointmentDate: Date;
    symptoms: string;
    patientId?: number;
    patient?: Patient;
    doctorId?: number;
    doctor?: Doctor;
    departmentId?: number;
    department?: Department;
}
