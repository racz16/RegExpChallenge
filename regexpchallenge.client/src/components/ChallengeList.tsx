import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { ChallengeListDto } from '../dtos/ChallengeListDto';

export default function ChallengeList() {
    const [challenges, setChallenges] = useState<ChallengeListDto[]>([]);
    useEffect(() => {
        fetchChallenges();
    }, []);

    async function fetchChallenges() {
        const response = await fetch('/challenges');
        const data = await response.json();
        setChallenges(data);
    }

    return (
        <div className="d-flex flex-column gap-4">
            {challenges.map((c) => (
                <div className="card p-3" key={c.id}>
                    <h2>{c.name}</h2>
                    <p>{c.description}</p>
                    <Link className="btn btn-outline-primary align-self-end" to={`/regex-challenges/${c.id}`}>
                        Open
                    </Link>
                </div>
            ))}
        </div>
    );
}
