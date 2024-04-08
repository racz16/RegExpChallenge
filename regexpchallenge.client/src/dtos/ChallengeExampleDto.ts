import { ChallengeExampleMatchDto } from './ChallengeExampleMatchDto';

export interface ChallengeExampleDto {
    id: number;
    example: string;
    matches: ChallengeExampleMatchDto[];
}
