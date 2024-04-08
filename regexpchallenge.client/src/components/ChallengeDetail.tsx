import { useEffect, useState } from 'react';
import { useLoaderData } from 'react-router-dom';
import { Example } from './Example';
import { ChallengeDetailsDto } from '../dtos/ChallengeDetailsDto';

// eslint-disable-next-line @typescript-eslint/no-explicit-any
export async function challengeDetailLoader({ params }: any): Promise<number> {
    return +params.id;
}

export default function ChallengeDetail() {
    const [regexpInput, setRegexpInput] = useState('\\w+');
    const [challenge, setChallenge] = useState<ChallengeDetailsDto>({
        id: 0,
        name: '',
        description: '',
        examples: [],
    });
    const id = useLoaderData() as number;
    useEffect(() => {
        fetchChallengeDetail(id as number);
    }, [id]);

    async function fetchChallengeDetail(id: number) {
        const response = await fetch(`/challenges/${id}`);
        const data = await response.json();
        setChallenge(data);
    }
    let regexp: RegExp | undefined;
    try {
        regexp = new RegExp(regexpInput, 'g');
    } catch (e) {
        // regexp remains undefined which means it's invalid
    }

    return (
        <div className="d-flex flex-column gap-2">
            <h2>{challenge.name}</h2>
            <p>{challenge.description}</p>
            <div className="d-flex flex-column">
                <label htmlFor="regexp">Regular expression</label>
                <input
                    id="regexp"
                    value={regexpInput}
                    onChange={(e) => {
                        setRegexpInput(e.target.value);
                    }}
                />
                {!regexp && <div className="text-danger">Invalid regular expression</div>}
            </div>
            <label>Examples</label>
            {challenge.examples.map((example) => {
                return (
                    <Example
                        key={example.id}
                        example={example}
                        isEditable={false}
                        isEditing={false}
                        isRemovable={false}
                        regexp={regexp}
                        togglePreviewEdit={() => {}}
                        remove={() => {}}
                        input={() => {}}
                    />
                );
            })}
            {/* <div className="d-flex justify-content-end mt-2">
                <Link className="btn btn-outline-secondary" to="/">
                    Back
                </Link>
                <button className="btn btn-primary ms-2">Submit</button>
            </div> */}
        </div>
    );
}
