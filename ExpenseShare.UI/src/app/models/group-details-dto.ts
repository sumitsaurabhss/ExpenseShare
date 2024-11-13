export interface GroupDetailsDto {
    id: string;
    name: string;
    description: string;
    memberIds: string[];
    memberNames: string[];
    memberDuesIds: string[];
    memberDues: number[];
    expenseIds: string[];
    expenseDescriptions: string[];
    expenseAmounts: number[];
}
