import { ChallengeExampleDto } from './ChallengeExampleDto';

export interface ChallengeDetailsDto {
    id: number;
    name: string;
    description: string;
    examples: ChallengeExampleDto[];
}
