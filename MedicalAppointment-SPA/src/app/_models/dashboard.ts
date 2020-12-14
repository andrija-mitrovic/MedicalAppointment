import { AppointmentReport } from "./appointmentReport";
import { BloodGroupReport } from "./bloodGroupReport";
import { DoctorReport } from "./doctorReport";
import { GenderReport } from "./genderReport";
import { PatientReport } from "./patientReport";

export interface Dashboard {
    bloodGroupReport: BloodGroupReport;
    appointmentReport: AppointmentReport;
    doctorReport: DoctorReport;
    patientReport: PatientReport;
    genderPatientReport: GenderReport;
    genderDoctorReport: GenderReport;
}
